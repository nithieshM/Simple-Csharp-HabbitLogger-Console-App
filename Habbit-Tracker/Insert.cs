using System.Globalization;
using Microsoft.Data.Sqlite;

namespace Habbit_Tracker;

public class Insert
{
    internal static void insertIntoDatabase()
    {
        string Date = GetDateInput();

        int Quantity = Numberinput("Enter the number of glasses, no floating point or decimals allowed.");
        
        using (var connection = new SqliteConnection(Program.connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();

            tableCmd.CommandText = $"INSERT INTO drinking_water(Date, Quantity) VALUES('{Date}', {Quantity})";

            tableCmd.ExecuteNonQuery();
            connection.Close();
        }
    }

    internal static string GetDateInput()
    {
        Console.WriteLine("\n Enter the date in the format dd-mm-yyyy. Type 0 to return to the main menu.");

        string DateInput = Console.ReadLine();

        if (DateInput == "0")
        {
            Program.getUserInput();
        }

        while (!DateTime.TryParseExact(DateInput, "dd-MM-yyyy", CultureInfo.InvariantCulture,
                   DateTimeStyles.None, out _))
        {
            Console.WriteLine("\n Invalid Date Format, Format : dd-mm-yyyy. Type 0 to return to main menu. Try Again,");
            DateInput = Console.ReadLine();
        }

        return DateInput;
    }

    internal static int Numberinput(string message)
    {
        Console.WriteLine(message);

        string numberInput = Console.ReadLine();

        if (numberInput == "0")
        {
            Program.getUserInput();
        }

        int finalInput = Convert.ToInt32(numberInput);

        return finalInput;
    }
}