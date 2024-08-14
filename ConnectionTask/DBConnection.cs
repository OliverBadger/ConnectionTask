using Microsoft.Data.SqlClient;


namespace ConnectionTask
{
    static class DBConnection
    {
        static void Connect()
        {
            string server = "127.0.0.1,1433";
            string database = "MovieStore";
            string username = "SA";
            //string password = Environment.GetEnvironmentVariable("DBPassword").ToString();
            string password = "P455word123!";

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "127.0.0.1,1433";
            builder.InitialCatalog = "MovieStore";
            builder.TrustServerCertificate = true;
            builder.UserID = "SA";
            builder.Password = "P455word123!";

            /* Either Connection String is Applicable */
            string connectionString = $"Server = {server};" +
                $"TrustServerCertificate = True; Database = {database};" +
                $"User Id = {username}; Password = {password};";

            connectionString = builder.ConnectionString;

            string table = "Movies";

            var sql = $"SELECT * FROM {table}";
            string tableName = "";
            string columnDetails = "";
            string sqlAdd = $"""
            INSERT INTO {tableName} 
            """;

            var conn = new SqlConnection(connectionString);

            conn.Open();

            var cmd = new SqlCommand(sql, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader["title"]}");
            }

            reader.Close();
            Console.WriteLine(conn);
            conn.Close();
        }
    }
}
