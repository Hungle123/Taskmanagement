using System.Security.Principal;

namespace ManagerUse
{
    public class User: IPrincipal, IIdentity
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string AuthenticationType
        {
            get { return ""; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public int Role { get; set; }

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
        /// <param name="password"></param>
        /// <param name="address"></param>
        /// <param name="role"></param>
        public User(int id, string name, string email, string password, string address, int role)
        {
            UserId = id;
            Name = name;
            Email = email;
            Password = password;
            Address = address;
            Role = role;
        }

        public bool IsInRole(string role)
        {
            throw new System.NotImplementedException();
        }

        public IIdentity Identity
        {
            get { return this; }
        }
    }
}
