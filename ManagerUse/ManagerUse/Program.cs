using System;
namespace ManagerUse
{
    class Program
    {
        static void Main()
        {
            var taskRepository = TaskRepository.GetIntance();
            var tasks = taskRepository.ReadText();
            foreach (var task in tasks)
            {
                Console.WriteLine(task.CompletedPercent);
            }
            Console.ReadLine();
        }

    }
}


