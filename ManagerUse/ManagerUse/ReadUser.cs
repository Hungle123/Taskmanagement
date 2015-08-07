using System;
using System.IO;

namespace ManagerUse
{  
    class ReadUser
    {
        public string[] infoUsers;

        // This id method read list of user from a text file
        public void ReadText()
        {
            infoUsers = File.ReadAllLines(@"C:\Users\dn00001\Documents\GitHub\Taskmanagement\user.txt");
        }

        // This is a method display infomation of user froma text file
        public void Display()
        {
           Console.WriteLine("Content a text file: ");
            foreach (var infoUser in infoUsers)
            {
                  Console.WriteLine("\t" +infoUser);
            }
        }
    }
}
