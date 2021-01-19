using System;
using System.Collections.Generic;
using System.Text;

namespace NivelEscudeiro.ExerciciosConsole
{
    public class Console1: IExecutar
    {
        private decimal ValorA;
        private decimal ValorB;
        public void Executar()
        {
            Console.WriteLine("Console - Exercício 1 ");

            while (ValorA <=0)
            {
                ValorA = GetInput("Informe um número maior que 0 para o valor A:");
            }

            while (ValorB <= 0)
            {
                ValorB = GetInput("Informe um número maior que 0 para o valor B:");
            }
            Console.WriteLine();
            Console.WriteLine("Resultados");
            Console.WriteLine($"Subtração: {ValorA - ValorB}");
            Console.WriteLine($"Divisão: {ValorA / ValorB}");
            Console.WriteLine($"Multiplicação: {ValorA * ValorB}");
            Console.WriteLine($"ValorA ({ValorA}) : {ValorA.EhParOuImpar()}");
            Console.WriteLine($"ValorB ({ValorB}) : {ValorB.EhParOuImpar()}");
        }

        private int GetInput(string mensagem)
        {            
            Console.Write(mensagem);
            int.TryParse(Console.ReadLine(), out int valor);
            return valor;
        }
    }

    public static class DecimalExtensions
    {
        public static string EhParOuImpar(this decimal valor)
        {
            return valor % 2 == 0 ? "Par" : "Ímpar";
        }
    }
}
