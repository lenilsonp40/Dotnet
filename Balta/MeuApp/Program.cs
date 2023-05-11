using System;

namespace MeuApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int idade = 18;
            int maioridade = 21;
            int idadeMaxima = 65;

            if (idade >= maioridade && idade < idadeMaxima)
            {
                Console.WriteLine("É Diferente");
            }
            else
            {
                Console.WriteLine("É igual");
            }

            Console.WriteLine("Finalizou o programa");
        }
    }
}


