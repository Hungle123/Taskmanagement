using System;
using System.Collections.Generic;
using System.IO;
namespace ManagerUse
{
    public class UserRepository
    {
        public const string NameText = "Name:";
        public const string EmailText = "Email:";

        /// <summary>
        /// Create list infomation Users include name and email
        /// </summary>
        public List<User> Users { get; set; }

        /// <summary>
        /// Create Constructor for class UserReponsive
        /// </summary>
        private UserRepository() { }

        /// <summary>
        /// The instance of this class
        /// </summary>
        private static UserRepository _instance;

        /// <summary>
        /// Create method excute GetInstance
        /// </summary>
        /// <returns></returns>
        public static UserRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UserRepository();
            }
            return _instance;
        }

        /// <summary>
        /// Read file user.txt and get infomation name and email for users
        /// </summary>
        /// <returns></returns>
        public List<User> ReadText()
        {
            Users = new List<User>();
            var name = "";
            try
            {
                var textInfo = new StreamReader("user.txt");
                string infoUsers;
                while ((infoUsers = textInfo.ReadLine()) != null)
                {
                    var line = infoUsers.Trim();
                    var startWithName = line.StartsWith(NameText);
                    var startWithEmail = line.StartsWith(EmailText);

                    if (startWithName)
                    {
                        var indexOfValue = NameText.Length;
                        name = line.Substring(indexOfValue).Trim();
                    }
                    else if (startWithEmail)
                    {
                        var indexOfValue = EmailText.Length;
                        var email = line.Substring(indexOfValue).Trim();
                        Users.Add(new User(name, email));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read");
                Console.WriteLine(e.Message);
            }
            return Users;
        }

        /// <summary>
        /// Search userName for User on the list Users
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>                          
        public User Search(string userName)
        {
            User result = null;
            // ReSharper disable once InvertIf
            if (userName != null)
            {
                userName = userName.ToLower();
                // ReSharper disable once LoopCanBePartlyConvertedToQuery
                foreach (var user in Users)
                {
                    // ReSharper disable once InvertIf
                    if (user.Name.ToLower() == (userName))
                    {
                        result = user;
                        break;
                    }
                }
            }
            return result;
        }
    }
}

