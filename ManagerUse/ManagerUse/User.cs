
namespace ManagerUse
{
    public class User
    {
        public string Name
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public User() { }

        /// <summary>
        /// Create method constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

    }
}
