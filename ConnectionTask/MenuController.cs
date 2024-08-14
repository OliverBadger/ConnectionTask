

namespace ConnectionTask
{
    static class MenuController
    {
        public static void DisplayMenu()
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

        }

        private static void CreateSelection()
        {

        }

        private static void ReadSelection()
        {

        }

        private static void UpdateSelection()
        {

        }

        private static void DeleteSelection()
        {

        }
    }
}
