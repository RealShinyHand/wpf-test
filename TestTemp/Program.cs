// See https://aka.ms/new-console-template for more information
using SimpleTrader.Domain.Models;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Service;
using util;

Console.WriteLine("Hello, World!");
GenericDataService<User> dataService = new GenericDataService<User>(new SimpleTraderDBContextFactory());
User user1 = new User()
{
    UserName = "Test1",
    Email = "teset@Email.com"
};

User user2 = new User()
{
    UserName = "Test2",
};
Task<User> user1R = dataService.Create(user1);
Task<User> user2R = dataService.Create(user2);

UtilClass.PrintResult(user1R.Result);
UtilClass.PrintResult(user2R.Result);

Console.WriteLine("유저 리스트");
IEnumerable<User> user =  dataService.GetAll().Result;
user.ToList<User>().ForEach(UtilClass.PrintResult);

Console.WriteLine("삭제할 id 입력 : ");
String? input = Console.ReadLine();
bool result = int.TryParse(input, out int inputId);

if (result)
{
    dataService.Delete(inputId).Wait();
}

Console.WriteLine("수정할 id 입력 : ");
input = Console.ReadLine();
result = int.TryParse(input, out  inputId);
if (result)
{
    Console.Write("수정할 id 입력 : ");
    string un = Console.ReadLine();
    string em = Console.ReadLine();
    User updatedUser = new User()
    {
        UserName = un,
        Email = em
    };
    dataService.Update(inputId, updatedUser);
}
namespace util
{
    public class UtilClass
    {
        private static int _count;
        static UtilClass()
        {
            _count = 0;
        }
        internal static void PrintResult(User user)
        {
            Console.WriteLine($"{_count}. user 출력 ");
            Console.WriteLine($"{nameof(user.Id)} : {user.Id}");
            Console.WriteLine($"{nameof(user.UserName)} : {user.UserName} ");
            Console.WriteLine($"{nameof(user.Email)} : {user.Email}");
        }
    }
}