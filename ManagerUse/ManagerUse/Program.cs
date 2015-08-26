using System;
namespace ManagerUse
{
    class Program
    {
        static void Main()
        {
            var result = TaskRepository.GetIntance();
            result.UpdateTask(4,"Task 5","Toto Something 5",2,3,89);
            Console.ReadLine();
        }

    }
}


