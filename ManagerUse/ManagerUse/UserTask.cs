using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ManagerUse
{
    class UserTask : DbConnection
    {

        /// <summary>
        /// View list UserTask in UserTask Table
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

        public void InsertUserTask(int id, int userId, int taskId)
        {
            ConnectDatabase();
            using (var insertUserTask = new SqlCommand("dbo.insertUserTask", DbConnect))
            {
                try
                {
                    insertUserTask.Parameters.AddWithValue("@ID", id);
                    insertUserTask.Parameters.AddWithValue("@UserID", userId);
                    insertUserTask.Parameters.AddWithValue("@TaskID", taskId);
                    insertUserTask.CommandType = CommandType.StoredProcedure;
                    insertUserTask.ExecuteNonQuery();
                    Console.WriteLine("insert Done !");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Message: " + ex.Message);
                }
                finally
                {
                    insertUserTask.Dispose();
                }
            }
        }

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
                    Console.WriteLine("update Complate !");
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

        public void DeleteUserTask(int id)
        {
            ConnectDatabase();
            using (var deleteUserTask = new SqlCommand("dbo.deleteUserTask", DbConnect))
            {
                try
                {
                    deleteUserTask.Parameters.AddWithValue("@ID", id);
                    deleteUserTask.CommandType = CommandType.StoredProcedure;
                    deleteUserTask.ExecuteNonQuery();
                    Console.WriteLine("delete Done !");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Message: " + ex.Message);
                }
                finally
                {
                    deleteUserTask.Dispose();
                }
            }
        }
    }
}
