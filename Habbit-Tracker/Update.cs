using Microsoft.Data.Sqlite;

namespace Habbit_Tracker;

internal class Update
{
    internal static void Edit()
    {
        Console.Clear();
        Read.GetAllRecords();

        var EditRecordId = Insert.Numberinput("Enter the record ID you want to edit/update.");

        using (var connection = new SqliteConnection(Program.connectionString))
        {
            connection.Open();
            
            var checkCmd = connection.CreateCommand();
            checkCmd.CommandText = $"SELECT EXISTS(SELECT 1 FROM drinking_water WHERE Id = {EditRecordId})";
            int checkquery = Convert.ToInt32(checkCmd.ExecuteScalar());

            if (checkquery == 0)
            {
                Console.WriteLine($"Record with {EditRecordId} does not exist");
                connection.Close();
                Edit();
            }

            string date = Insert.GetDateInput();
            int quanitity = Insert.Numberinput("Please enter the number of glasses.");
            
            var tableCmd = connection.CreateCommand();
            tableCmd.CommandText = 
                $"UPDATE drinking_water SET date = '{date}', quantity = {quanitity} WHERE Id = '{EditRecordId}'";

            tableCmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}