using System;

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

        public User User { get; set; }

        public TaskState State { get; set; }

        public string ComplateedPercent { get; set; }

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
        /// <param name="complateedPercent"></param>
        public Task(string name, string description, TaskType type, User user, TaskState state, string complateedPercent)
        {
            Name = name;
            Description = description;
            Type = type;
            User = user;
            State = state;
            ComplateedPercent = complateedPercent;
        }

        /// <summary>
        ///   Create method check parameters user have same with user in the task
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Boolean ContainUser(User user)
        {
            if (User != null && user !=null)
            {
                if (User.Name == user.Name)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
