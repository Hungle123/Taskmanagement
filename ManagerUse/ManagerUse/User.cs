
namespace ManagerUse
{
    public class User
    {
        public string Name { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// Create method constructor no parameter
        /// </summary>
        public User() { }

        public User(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Create method constructor two parameters name and email
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
