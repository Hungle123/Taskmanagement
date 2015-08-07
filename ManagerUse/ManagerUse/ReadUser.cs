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
            try
            {
                infoUsers = File.ReadAllLines(@"C:\Users\dn00001\Documents\GitHub\Taskmanagement\user.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read");
                Console.WriteLine(e.Message);
            }
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
