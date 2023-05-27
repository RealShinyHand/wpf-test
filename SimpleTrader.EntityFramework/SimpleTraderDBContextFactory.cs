using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.EntityFramework
{
    public class SimpleTraderDBContextFactory : IDesignTimeDbContextFactory<SimpleTraderDBContext>
    {
        //매개변수를 통해 런타임 시 설정을 다르게 할 수 있음
        public SimpleTraderDBContext CreateDbContext(string[]? args= null)
        {
            var options = new DbContextOptionsBuilder<SimpleTraderDBContext>();
           
            string userName = "sa";
            string password = "qwer1234";
            string connectionString = $"Server=localhost;Database=SimpleTraderDB;Trusted_Connection=True; uid = ${userName}; Password = ${password};TrustServerCertificate=True";

            options.UseSqlServer(connectionString);
            //new PooledDbContextFactory<SimpleTraderDBContext>(options.Options).;
            return new SimpleTraderDBContext(options.Options);
        }
    }
}
