using System;
using System.Collections.Generic;

namespace ManagerUse
{
    class Program
    {
        static void Main()
        {
            var taskReponsive = TaskRepository.GetIntance();
            taskReponsive.ReadText();
            var results = taskReponsive.GetUserTasks(new User("Hung"), TaskState.Done);
            foreach (var result  in results)
            {
                Console.WriteLine(result.Name);  
            }
            Console.ReadLine();
        }

    }
}


