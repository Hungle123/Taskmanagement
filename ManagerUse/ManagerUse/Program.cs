using System;
namespace ManagerUse
{
    class Program
    {
        static void Main()
        {
            var user = UserRepository.GetInstance();
            var result = user.CheckEmail("Nick@clearpathdevelopment.com");
            Console.WriteLine(result);
            Console.ReadLine();
        }

    }
}


