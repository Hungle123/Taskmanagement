using System;
using System.IO;

namespace ManagerUse
{
    public class UserRepository
    {
        public string[] infoUsers;
        public string result;

        // This id method read list of user from a text file
        public string ReadText()
        {
            try
            {
                infoUsers = File.ReadAllLines(@"C:\Users\dn00001\Documents\GitHub\Taskmanagement\user.txt");
                foreach (var infoUser in infoUsers)
                {
                    result += infoUser + "\n";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read");
                Console.WriteLine(e.Message);
            }
            
           return result.Trim();
        }
    }
}
