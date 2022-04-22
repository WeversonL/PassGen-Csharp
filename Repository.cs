using System;
using MySql.Data.MySqlClient;

public class Repository
{
    private MySqlCommand cmd;
    private readonly Connection connection = new();
    private string StrSQL;

    public void insertData(string usuario, string senha, string aplicacao)
    {
        if (!connection.getStatus())
            try
            {
                connection.connect();
            }
            catch (Exception e)
            {
                Console.WriteLine($"--- ERRO ---\n\n{e}");
            }

        StrSQL = "INSERT INTO Passwords (user, password, application) VALUES (@USER, @PASSWORD, @APPLICATION)";

        cmd = new MySqlCommand(StrSQL, connection.connect());
        cmd.Parameters.AddWithValue("@USER", usuario);
        cmd.Parameters.AddWithValue("@PASSWORD", senha);
        cmd.Parameters.AddWithValue("@APPLICATION", aplicacao);
        cmd.ExecuteNonQuery();
        connection.disconnect();
    }

    public MySqlDataReader getData()
    {
        if (!connection.getStatus())
            try
            {
                connection.connect();
            }
            catch (Exception e)
            {
                Console.WriteLine($"--- ERRO ---\n\n{e}");
            }

        StrSQL = "SELECT * FROM Passwords";
        cmd = new MySqlCommand(StrSQL, connection.connect());
        cmd.ExecuteNonQuery();

        MySqlDataReader myReader;
        myReader = cmd.ExecuteReader();
        try
        {
            while (myReader.Read())
            {
                Console.Write("APP: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(myReader.GetString(3));
                Console.ResetColor();

                Console.Write("\nUSER: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(myReader.GetString(1));
                Console.ResetColor();

                Console.Write("\nPASS: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(myReader.GetString(2) + "\n");
                Console.ResetColor();

                Console.WriteLine("".PadLeft(50, '-'));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        connection.disconnect();
        return myReader;
    }
}