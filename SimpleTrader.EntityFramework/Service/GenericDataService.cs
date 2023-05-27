using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.EntityFramework.Service
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly SimpleTraderDBContextFactory _contextFactory;
        public GenericDataService(SimpleTraderDBContextFactory context)
        {
            _contextFactory = context;
        }
        //async 쓰는 거에 의문을 가질 수 있다.
        //async/await을 이해하기 위해서는 Task를 이해해야하고
        //Task를 이해하기 위해서는 ThreadPool을 이해해야함
        //동기와 다르게 위 구문을 사용한 작업은 별도로 마련된 ThreadPool에 의해
        //실행되어 메인 쓰레드와는 별개로 동작, 메인 쓰레드의 블럭킹 감소 ==> 성능향상
        public async Task<T> Create(T entity)
        {
            using(SimpleTraderDBContext context = _contextFactory.CreateDbContext(args:null)) {
                //DBContext를 얻어온다.
                var createdEntity = await context.Set<T>().AddAsync(entity);
                //너무 추상화 되있지 않나....
                //DB 어느 셋에 엔티티 추가
                //ValueTask는 Task 가 참조 타입에 한정되어 primitive 타입의 힙 메모리 소모에 대한 대안 
                await context.SaveChangesAsync();
                //비동기로 변경된 내용 DB 적용
                return createdEntity.Entity;
            }
            
        }

        public async Task<bool> Delete(int id)
        {
            using (SimpleTraderDBContext context = _contextFactory.CreateDbContext(args: null))
            {
                T? entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                //First 계열은 1..2, Single은 2>= result count 일시 에러
                if (entity is null)
                {
                    return false;
                }
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<T> Get(int id)
        {
            using (SimpleTraderDBContext context = _contextFactory.CreateDbContext(args: null))
            {
                T? entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                //First 계열은 1..2, Single은 2>= result count 일시 에러
                return entity ?? null ;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using(SimpleTraderDBContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entityList = await  context.Set<T>().ToListAsync();
                return entityList;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (SimpleTraderDBContext context = _contextFactory.CreateDbContext(args: null))
            {

                entity.Id = id;
                context.Set<T>().Update(entity);

                await context.SaveChangesAsync();
                return entity;
            }
        }
    }
}
