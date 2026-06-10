using Microsoft.Data.SqlClient;
using System.Data;

namespace Asignacion1.DatabaseHelper
{
    public static class DatabaseSql
    {
        private static String connectionString = "Data Source=MSI\\SQLEXPRESS;Database=AdventureWorks2025;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Command Timeout=0";
        private static SqlConnection conn;

        public static SqlConnection getConnection()
        {
            return conn;
        }

        public static DataTable executeStoredProcedure(string sp)
        {
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp;
                cmd.Connection = conn;

                cmd.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }
    }
}
