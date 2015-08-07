using System;

namespace ManagerUse
{    
    class Program
    {
        static void Main()
        {
            
            /* User personOne = new User();
               User personTwo = new User();

            personOne.SetInformation("John", "John@america.com");
            personOne.Display();

            personTwo.SetInformation("Nick", "Nick@clearpathdevelopment.com");
            personTwo.Display(); 
             * */

            UserRepository content = new UserRepository();
            content.ReadText();
            content.Display(); 
             

            Console.ReadKey();
        }
    }
}
