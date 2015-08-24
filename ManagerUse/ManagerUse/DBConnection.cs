
using System.Data.SqlClient;

namespace ManagerUse
{
    public class DbConnection
    {
        public SqlConnection DbConnect;

        /// <summary>
        /// Connect with Database 
        /// </summary>
        public void ConnectDatabase()
        {
            DbConnect = new SqlConnection
            {
                ConnectionString = "Data Source=localhost;Initial Catalog =TaskManagermant;User ID = sa;Password = hungle123"
            };
            DbConnect.Open();
        }
    }
}
