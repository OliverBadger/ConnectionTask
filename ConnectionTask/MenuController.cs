

using Microsoft.Data.SqlClient;

namespace ConnectionTask
{
    static class MenuController
    {
        public static void DisplayMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("""
                    1: Create in Database
                    2: Read the Database
                    3: Update in Database
                    4: Delete in Database

                    9: Exit
                    Please select an option:  
                    """);
                byte input = Convert.ToByte(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        CreateSelection();
                        break;
                    case 2:
                        ReadSelection();
                        break;
                    case 3:
                        UpdateSelection();
                        break;
                    case 4:
                        DeleteSelection();
                        break;
                    case 9:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static void CreateSelection()
        {
            Console.WriteLine("Enter the Movie Title:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the Release Year:");
            int releaseYear = Convert.ToInt32(Console.ReadLine());

            string sql = "INSERT INTO Movies (title, release_year) VALUES (@title, @releaseYear)";

            using (SqlConnection conn = DBConnection.Connect())
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@releaseYear", releaseYear);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Movie added to the database.");
            }
        }

        private static void ReadSelection()
        {
            string sql = "SELECT * FROM Movies";

            using (SqlConnection conn = DBConnection.Connect())
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}, Title: {reader["title"]}, Release Year: {reader["release_year"]}");
                }
                reader.Close();
            }
        }

        private static void UpdateSelection()
        {
            Console.WriteLine("Enter the ID of the movie to update:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the new Title:");
            string newTitle = Console.ReadLine();

            Console.WriteLine("Enter the new Release Year:");
            int newReleaseYear = Convert.ToInt32(Console.ReadLine());

            string sql = "UPDATE Movies SET title = @newTitle, release_year = @newReleaseYear WHERE id = @id";

            using (SqlConnection conn = DBConnection.Connect())
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@newTitle", newTitle);
                cmd.Parameters.AddWithValue("@newReleaseYear", newReleaseYear);
                cmd.Parameters.AddWithValue("@id", id);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Movie updated successfully.");
                }
                else
                {
                    Console.WriteLine("Movie not found.");
                }
            }
        }

        private static void DeleteSelection()
        {
            Console.WriteLine("Enter the ID of the movie to delete:");
            int id = Convert.ToInt32(Console.ReadLine());

            string sql = "DELETE FROM Movies WHERE id = @id";

            using (SqlConnection conn = DBConnection.Connect())
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Movie deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Movie not found.");
                }
            }
    }
}
