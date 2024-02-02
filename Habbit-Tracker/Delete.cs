using Microsoft.Data.Sqlite;

namespace Habbit_Tracker;

public class Delete
{
    internal static void DeleteEntry()
    {
        Console.Clear();
        Read.GetAllRecords();
        
        var recordId = Insert.Numberinput("Enter the Id you want to delete. Press 0 to return to main menu.");

        using (var connection = new SqliteConnection(Program.connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();
            tableCmd.CommandText = $"DELETE from drinking_water WHERE Id = '{recordId}'";

            int rowCount = tableCmd.ExecuteNonQuery();

            if (rowCount == 0)
            {
                Console.WriteLine($"The specified record {recordId} doesnt exist.");
                DeleteEntry();
            }
            connection.Close();
        }
        
        Console.WriteLine($"The specified recordId {recordId} was successfully deleted.")
        Program.getUserInput();
    }
}