using System;
using System.Data;
using MySql.Data.MySqlClient;

public class conexao{
    private static string server = "localhost";
    private static string user = "PassGenApp";
    private static string pwd = "78964254";
    private static string database = "PassGen";
    private static string stringConect = $"server={server};user={user};pwd={pwd};database={database};SslMode=none";
    private MySqlConnection con;

    public conexao(){
        con = new MySqlConnection(stringConect);
    }
    
    public MySqlConnection conectar(){
        if (con.State == ConnectionState.Closed){
            try{
                con.Open();
            } catch (Exception e){
                Console.WriteLine($"--- ERRO ---\n\n{e}");
            }
        }
        return con;
    }

    public void desconectar(){
        if (con.State == ConnectionState.Open){
            try{
                con.Close();
            } catch (Exception e){
                Console.WriteLine($"--- ERRO ---\n\n{e.Message}");
            }
        }
    }

    public Boolean getStatus(){
        if(con.State == ConnectionState.Open){
            return true;
        } else{
            return false;
        }
    }
}

