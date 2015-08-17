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

        List<User> Users { get; set; }

        public string State { get; set; }

        public int ComplateedPercent { get; set; }


        /// <summary>
        /// Create Contructor for class Task
        /// </summary>

        public Task() { }

        public Task(string name, string description, TaskType type, List<User> users, string state, int complateedPercent)
        {
            
            Name = name;
            Description = description;
            Type = type;
            Users = users;
            State = state;
            ComplateedPercent = complateedPercent;
        }
    }
}
