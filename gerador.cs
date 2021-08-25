using System;
using System.Text;
public class gerador{
    static Random rand = new Random();
    static StringBuilder password = new StringBuilder();
    int sort = 0;
    public string gerarSenha(string caracteres, int tamanho){
        password.Clear();
        for (int i = 0; i < tamanho; i++){ 
            sort = rand.Next(0, caracteres.Length - 1);
            password.Append(caracteres[sort]);
        }

        return password.ToString();
    }

}