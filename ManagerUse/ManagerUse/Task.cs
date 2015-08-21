using System.Collections.Generic;

namespace ManagerUse
{
    /// <summary>
    /// Create enum for Task Type
    /// </summary>
    public enum TaskType
    {
        Bug,
        Feature,
    }

    /// <summary>
    /// Create enum for Task State
    /// </summary>
    public enum TaskState
    {
        ToDo,
        Doing,
        Done,
        Tested
    }

    public class Task
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public TaskType Type { get; set; }

        public List<User> Users { get; set; }

        public TaskState State { get; set; }

        public int CompletedPercent { get; set; }

        /// <summary>
        /// Create method constructor no parameters
        /// </summary>
        public Task() { }

        /// <summary>
        /// Create method constructer parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="type"></param>
        /// <param name="user"></param>
        /// <param name="state"></param>
        /// <param name="completedPercent"></param>
        public Task(string name, string description, TaskType type, List<User> user, TaskState state, int completedPercent)
        {
            Name = name;
            Description = description;
            Type = type;
            Users = user;
            State = state;
            CompletedPercent = completedPercent;
        }

        /// <summary>
        ///   Create method check parameters user have same with user in the task
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ContainUser(User name)
        {
            // ReSharper disable once InvertIf
            if (Users != null && name != null)
            {
                // ReSharper disable once LoopCanBeConvertedToQuery
                foreach (var user in Users)
                {
                    if (user.Name == name.Name)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
