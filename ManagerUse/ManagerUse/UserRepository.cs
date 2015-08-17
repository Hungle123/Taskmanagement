using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ManagerUse
{
    public class UserRepository : User
    {
        public string InfoUsers;
        public const string NameText = "Name:";
        public const string EmailText = "Email:";
        public List<User> Users { get; set; }

        public UserRepository(string name, string email)
            : base(name, email)
        {
        }
        /// <summary>
        /// Create Comtructor for class UserReponsive
        /// </summary>
        public UserRepository() { }

        /// <summary>
        /// Read file userName.txt and save infomation userName with list users
        /// </summary>
        /// <returns></returns>
        public List<User> ReadText()
        {
            Users = new List<User>();
            try
            {
                var textInfo = new StreamReader(@"C:\Users\dn00001\Documents\GitHub\Taskmanagement\user.txt");
                while ((InfoUsers = textInfo.ReadLine()) != null)
                {
                    var line = InfoUsers.Trim();
                    var startWithName = line.StartsWith(NameText);
                    var startWithEmail = line.StartsWith(EmailText);

                    if (startWithName)
                    {
                        var indexOfValue = NameText.Length;
                        Name = line.Substring(indexOfValue).Trim();
                    }
                    else if (startWithEmail)
                    {
                        var indexOfValue = EmailText.Length;
                        Email = line.Substring(indexOfValue).Trim();
                        Users.Add(new User(Name, Email));
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
        public User Search(string userName)
        {
            UserRepository info = new UserRepository();
            var users = info.ReadText();
            int countName = 0;
            foreach (var user in users)
            {
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                userName = textInfo.ToLower(userName);
                userName = textInfo.ToTitleCase(userName);
                if (System.Text.RegularExpressions.Regex.IsMatch(user.Name, userName,
                    System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    countName ++;
                }
            }
            if (countName > 0) return null;
            return null;
        }
    }
}

