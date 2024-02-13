namespace Habbit_Tracker;

using Microsoft.Data.Sqlite;

class Program
{
    internal static string connectionString = @"Data Source=habit-tracker.db";

    static void Main(string[] args)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();

            tableCmd.CommandText = @"CREATE TABLE IF NOT EXISTS drinking_water (
                             Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                             Date TEXT,
                             Quantity INTEGER)";


            tableCmd.ExecuteNonQuery();
            connection.Close();
        }

        getUserInput();
    }

    internal static void getUserInput()
    {
        Console.Clear();

        bool closeApp = false;

        while (closeApp == false)
        {
            Console.WriteLine("MAIN MENU" +
                              "\n\n What would you like to do?" +
                              "\n\n 1. View all Records" +
                              "\n 2. Edit all Records" +
                              "\n 3. Insert a Record" +
                              "\n 4. Delete a Record" +
                              "\n 5. Press 0 To Exit." +
                              "\n-----------------------------------------------\n");

            string command = Console.ReadLine();

            switch (command)
            {
                case "0":
                {
                    closeApp = true;
                    Environment.Exit(0);
                    break;
                }

                case "1":
                    Read.GetAllRecords();
                    Console.ReadKey();
                    break;

                case "2":
                    Update.Edit();
                    break;

                case "3":
                    Insert.insertIntoDatabase();
                    break;

                case "4":
                    Delete.DeleteEntry();
                    break;

                default:
                    Console.WriteLine("Invalid Option, Please Try Again.");
                    break;
            }
        }
    }
}