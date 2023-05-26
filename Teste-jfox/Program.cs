// Implemente uma função em C# que receba uma lista de números inteiros e retorne a soma de todos os números pares na lista.

using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<int> numeros = new List<int>() { 15, 25, 36, 49, 60, 64, 18, 7, 2, 4 };
        int resultadoPares = SomarNumerosPares(numeros);
        Console.WriteLine("a soma de todos os números pares na lista: " + resultadoPares);
    }

    public static int SomarNumerosPares(List<int> numeros)
    {
        int soma = 0;
        foreach (int numero in numeros)
        {
            if (numero % 2 == 0)
            {
                soma += numero;
            }
        }
        return soma;
    }
}
