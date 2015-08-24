namespace ManagerUse
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// Create method constructor no parameter
        /// </summary>
        public User() { }

        /// <summary>
        /// Create method constructor two parameters name and email
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        public User(int id, string name, string email)
        {
            UserId = id;
            Name = name;
            Email = email;
        }
    }
}
