using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerUser
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        
        // Constructor that takes no argument
        public User(){}
        public void SetUser(string name, string email)
        {
            Name = name;
            Email = email;
        } 

        public void DisplayUser()
        {
            Console.WriteLine("Name: {0} \n Email: {1}", Name, Email);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            User u = new User();
            User u2 = new User();
            u.SetUser("John","John@america.com");
            u.DisplayUser();
            u2.SetUser("Nick", "Nick@clearpathdevelopment.com");
            u2.DisplayUser();
            Console.ReadKey();
        }
    }
}
