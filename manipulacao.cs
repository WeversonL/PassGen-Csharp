using System;
using System.Data;
using MySql.Data.MySqlClient;

public class manipulacao{
    conexao con = new conexao();
    private MySqlCommand cmd;
    private string StrSQL;
    public void inserirDados(string usuario, string senha, string aplicacao){

        if (!con.getStatus()){
            try{
                con.conectar();
            } catch (Exception e){
                Console.WriteLine($"--- ERRO ---\n\n{e}");
            }
        }    
        StrSQL = "INSERT INTO Passwords (user, password, application) VALUES (@USER, @PASSWORD, @APPLICATION)";

        cmd = new MySqlCommand(StrSQL, con.conectar());
        //
        cmd.Parameters.AddWithValue("@USER",usuario);
        cmd.Parameters.AddWithValue("@PASSWORD",senha);
        cmd.Parameters.AddWithValue("@APPLICATION",aplicacao);
        //
        cmd.ExecuteNonQuery();
        //
        con.desconectar();
    }

    public MySqlDataReader obterDados(){

        if (!con.getStatus()){
            try{
                con.conectar();
            } catch (Exception e){
                Console.WriteLine($"--- ERRO ---\n\n{e}");
            }
        } 

        StrSQL = "SELECT * FROM Passwords";
        cmd = new MySqlCommand(StrSQL, con.conectar());
        cmd.ExecuteNonQuery();

        MySqlDataReader myReader;
        myReader= cmd.ExecuteReader();  //stop here
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

                Console.WriteLine("".PadLeft(50,'-'));
                
            }
        } catch(Exception e){
            Console.WriteLine(e);
        }

        con.desconectar();

        return myReader;

    }

    
}