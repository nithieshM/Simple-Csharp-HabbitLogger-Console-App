using System.Globalization;
using Microsoft.Data.Sqlite;

namespace Habbit_Tracker;

internal static class Read
{
    internal static void GetAllRecords()
    {
        Console.Clear();

        using (var connection = new SqliteConnection(Program.connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();
            tableCmd.CommandText = $"SELECT * FROM drinking_water ";

            List<DrinkingWater> tableData = new();

            SqliteDataReader reader = tableCmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tableData.Add(
                        new DrinkingWater
                        {
                            Id = reader.GetInt32(0),
                            Date = DateTime.ParseExact(reader.GetString(1), "dd-MM-yyyy", CultureInfo.InvariantCulture),
                            Quantity = reader.GetInt32(2)
                        });
                }
            }
            else
            {
                Console.WriteLine("No Rows found. Add rows before using this command.");
            }

            connection.Close();

            foreach (var VARIABLE in tableData)
            {
                Console.WriteLine(
                    $"{VARIABLE.Id} - {VARIABLE.Date.ToString("dd-MM-yyyy")} - Quantity: {VARIABLE.Quantity}");
            }
        }
    }
}

public class DrinkingWater
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Quantity { get; set; }
}