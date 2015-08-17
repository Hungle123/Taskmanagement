using System;
using System.Collections.Generic;
namespace ManagerUse
{
    class Program
    {

        /// <summary>
        /// method string extension
        /// </summary>                      
        static void Main()
        {

            UserRepository user = new UserRepository();
           // var infoUser = user.ReadText();
            //  foreach (var info in infoUser)
            //  {
            //    Console.WriteLine(info.Name);  
            //    Console.WriteLine(info.Email);  
           //   }
            user.Search("Khiem");

          Console.ReadLine();
        }
    }
}


