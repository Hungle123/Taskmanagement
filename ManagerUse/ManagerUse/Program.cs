using System;
namespace ManagerUse
{
    class Program
    {
        static void Main()
        {
            var result = TaskRepository.GetIntance();
            var tasks = result.ViewTask(1);
            foreach (var task in tasks)
            {
                Console.WriteLine(task.Name);
                Console.WriteLine(task.Description);
                Console.WriteLine(task.Type);
                Console.WriteLine(task.State);
                Console.WriteLine(task.CompletedPercent);
            }
            Console.ReadLine();
        }

    }
}


