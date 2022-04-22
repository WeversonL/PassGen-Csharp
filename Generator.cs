using System;
using System.Text;

public class Generator
{
    private static readonly Random rand = new();
    private static readonly StringBuilder password = new();
    private int sort;

    public string generatePassword(string caracteres, int length)
    {
        password.Clear();
        for (var i = 0; i < length; i++)
        {
            sort = rand.Next(0, caracteres.Length - 1);
            password.Append(caracteres[sort]);
        }

        return password.ToString();
    }
}