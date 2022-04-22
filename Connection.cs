using System;
using System.Data;
using MySql.Data.MySqlClient;

public class Connection
{
    private static readonly string server = "localhost";
    private static readonly string user = "PassGenApp";
    private static readonly string pwd = "78964254";
    private static readonly string database = "PassGen";

    private static readonly string stringConect =
        $"server={server};user={user};pwd={pwd};database={database};SslMode=none";

    private readonly MySqlConnection con;

    public Connection()
    {
        con = new MySqlConnection(stringConect);
    }

    public MySqlConnection connect()
    {
        if (con.State == ConnectionState.Closed)
            try
            {
                con.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine($"--- ERRO ---\n\n{e}");
            }

        return con;
    }

    public void disconnect()
    {
        if (con.State == ConnectionState.Open)
            try
            {
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"--- ERRO ---\n\n{e.Message}");
            }
    }

    public bool getStatus()
    {
        if (con.State == ConnectionState.Open)
            return true;
        return false;
    }
}