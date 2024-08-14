using Microsoft.Data.SqlClient;


namespace ConnectionTask
{
    static class DBConnection
    {
        public static SqlConnection Connect()
        {
            string server = "127.0.0.1,1433";
            string database = "MovieStore";
            string username = "SA";
            string password = "P455word123!";

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = server;
            builder.InitialCatalog = database;
            builder.TrustServerCertificate = true;
            builder.UserID = username;
            builder.Password = password;

            SqlConnection conn = new SqlConnection(builder.ConnectionString);
            conn.Open();
            return conn;
        }
    }
}
