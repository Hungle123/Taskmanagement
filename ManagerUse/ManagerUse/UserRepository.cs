using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ManagerUse
{
    public class UserRepository : DbConnection
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
            // var name = "";
            try
            {
                var textInfo = new StreamReader("user.txt");
                string infoUsers;
                //var i = 0;
                while ((infoUsers = textInfo.ReadLine()) != null)
                {
                    var line = infoUsers.Trim();
                    var startWithName = line.StartsWith(NameText);
                    var startWithEmail = line.StartsWith(EmailText);

                    if (startWithName)
                    {
                        //  var indexOfValue = NameText.Length;
                        //  name = line.Substring(indexOfValue).Trim();
                    }
                    else if (startWithEmail)
                    {
                        // var indexOfValue = EmailText.Length;
                        // var email = line.Substring(indexOfValue).Trim();
                        Users.Add(new User());
                    }
                    //  i++;
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

        /// <summary>
        /// View infomation for User
        /// </summary>
        /// <returns></returns>
        public List<User> ViewUser()
        {
            var listUser = new List<User>();
            ConnectDatabase();
            var viewCommand = new SqlCommand("dbo.selectUser", DbConnect) { CommandType = CommandType.StoredProcedure };
            using (var reader = viewCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = Convert.ToInt32(reader["UserID"]);
                    var name = Convert.ToString(reader["Name"]);
                    var email = Convert.ToString(reader["Email"]);
                    var passWord = Convert.ToString(reader["Password"]);
                    var addRess = Convert.ToString(reader["Address"]);
                    var role = Convert.ToInt32(reader["Role"]);
                    listUser.Add(new User(id, name, email, passWord, addRess, role));
                }
            }
            DbConnect.Close();
            return listUser;
        }


        /// <summary>
        /// insert user for table user
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="address"></param>
        /// <param name="role"></param>
        public void InsertUser(string name, string email, string password, string address, int role)
        {
            try
            {
                ConnectDatabase();
                var insertCommand = new SqlCommand("dbo.insertUser", DbConnect);
                insertCommand.Parameters.AddWithValue("@Name", name);
                insertCommand.Parameters.AddWithValue("@Email", email);
                insertCommand.Parameters.AddWithValue("@Password", password);
                insertCommand.Parameters.AddWithValue("@Address", address);
                insertCommand.Parameters.AddWithValue("@RoleID", role);
                insertCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    var userEmail = CheckEmail(email);
                    if (userEmail == false)
                    {
                        insertCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                DbConnect.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Update infomation for users
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="role"></param>
        /// <param name="password"></param>
        public void UpdateUser(int id, string name, string email, string password, string address, int role)
        {
            ConnectDatabase();
            var updateCommand = new SqlCommand("dbo.updateUser", DbConnect)
            {
                CommandType = CommandType.StoredProcedure
            };
            updateCommand.Parameters.AddWithValue("@UserID", id);
            updateCommand.Parameters.AddWithValue("@Name", name);
            updateCommand.Parameters.AddWithValue("@Email", email);
            updateCommand.Parameters.AddWithValue("@Password", password);
            updateCommand.Parameters.AddWithValue("@Address", address);
            updateCommand.Parameters.AddWithValue("@RoleID", role);
            updateCommand.ExecuteNonQuery();
            //DbConnect.Close();
        }

        /// <summary>
        /// delete user for Users
        /// </summary>
        /// <param name="id"></param>
        public void DeleteUser(int id)
        {
            ConnectDatabase();
            var deleteCommand = new SqlCommand("dbo.deleteUser", DbConnect);
            deleteCommand.Parameters.AddWithValue("@UserID", id);
            deleteCommand.CommandType = CommandType.StoredProcedure;
            deleteCommand.ExecuteNonQuery();
            DbConnect.Close();
        }

        public bool CheckEmail(string email)
        {
            ConnectDatabase();
            var result = false;
            var checkCommand = new SqlCommand("select Email from Users where Email = @Email", DbConnect);
            checkCommand.Parameters.AddWithValue("Email", email);
            var reader = checkCommand.ExecuteReader();
            if (reader.Read())
            {
                result = true;
            }
            return result;
        }
    }
}

