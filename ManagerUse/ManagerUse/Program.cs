using System;

namespace ManagerUse
{
    class Program
    {
        static void Main()
        {
            var taskReponsive = TaskRepository.GetIntance();
            taskReponsive.ReadText();
            taskReponsive.UserName();
            Console.ReadLine();
        }

    }
}


