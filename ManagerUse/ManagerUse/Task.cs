using System.Collections.Generic;

namespace ManagerUse
{

    enum TaskType
    {
        Bug,
        Feature,
    }

    class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }    
        public TaskType Type { get; set; }
        public List<User> Users { get; set; }
        public List<Task> State { get; set; }
        public float Completed { get; set; }

        public IList<Task> GetUserTasks(User user, Task state)
        {
            return null;
        } 
    }
}
