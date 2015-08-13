using System;
using System.IO;

namespace ManagerUse
{
    public class TaskRepository
    {
        public string[] infoTasks;
        public string result;

        // This id method read list of tasks from a text file
        public string ReadText()
        {
            try
            {
                infoTasks = File.ReadAllLines(@"C:\Users\dn00001\Documents\GitHub\Taskmanagement\task.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read");
                Console.WriteLine(e.Message);
            }
            foreach (var infoTask in infoTasks)
            {
                result += infoTask + "\n";
            }
           return result.Trim();
        }
    }
}
