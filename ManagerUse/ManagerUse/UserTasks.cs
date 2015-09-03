
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ManagerUse
{
    public class UserTasks : DbConnection
    {
        /// <summary>
        ///   view data usertask manager
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<int> ViewUserTask(int id)
        {
            ConnectDatabase();
            var lists = new List<int>();
            var selectCommand = new SqlCommand("dbo.selectUserTask", DbConnect);
            selectCommand.Parameters.AddWithValue("@ID", id);
            selectCommand.CommandType = CommandType.StoredProcedure;
            using (var reader = selectCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader["ID"]);
                        var userId = Convert.ToInt32(reader["UserID"]);
                        var taskId = Convert.ToInt32(reader["TaskID"]);
                        lists.Add(id);
                        lists.Add(userId);
                        lists.Add(taskId);
                    }
                }
            }
            return lists;
        }

        /// <summary>
        ///     update usertask managser
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <param name="taskId"></param>
        public void UpdateUserTask(int id, int userId, int taskId)
        {
            ConnectDatabase();
            using (var updateUserTask = new SqlCommand("dbo.updateUserTask", DbConnect))
            {
                try
                {
                    updateUserTask.Parameters.AddWithValue("@ID", id);
                    updateUserTask.Parameters.AddWithValue("@UserID", userId);
                    updateUserTask.Parameters.AddWithValue("@TaskID", taskId);
                    updateUserTask.CommandType = CommandType.StoredProcedure;
                    updateUserTask.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Message: " + ex.Message);
                }
                finally
                {
                    updateUserTask.Dispose();
                }
            }
        }

        /// <summary>
        ///     Delete usertask manager
        /// </summary>
        /// <param name="id"></param>
        public void DeleteUserTask(int id)
        {
            ConnectDatabase();
            var deleteCommand = new SqlCommand("dbo.deleteUserTask", DbConnect)
            {
                CommandType = CommandType.StoredProcedure
            };
            deleteCommand.Parameters.AddWithValue("@ID", id);
            deleteCommand.ExecuteNonQuery();
        }

        /// <summary>
        ///     inset usertask managser
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="taskId"></param>
        public void InsertUserTask(int userId, int taskId)
        {
            ConnectDatabase();
            var insertCommand = new SqlCommand("dbo.insertUserTask", DbConnect)
            {
                CommandType = CommandType.StoredProcedure
            };
            insertCommand.Parameters.AddWithValue("@UserID", userId);
            insertCommand.Parameters.AddWithValue("@TaskID", taskId);
            insertCommand.ExecuteNonQuery();
        }
    }
}
