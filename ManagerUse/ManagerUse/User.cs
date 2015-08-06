using System;

namespace ManagerUse
{
    class User
    {
        public string Name { get; set; }
        public string Email { get; set; }

        // Constructor that takes no argument
        public void SetInformation(string name, string email)
        {
            Name = name;
            Email = email;
        }

        //This is method display infomation for user
        public void Display()
        {
            Console.WriteLine("Name for user: {0}", Name);
            Console.WriteLine("Email for user: {0}", Email);
        }
    }
}
