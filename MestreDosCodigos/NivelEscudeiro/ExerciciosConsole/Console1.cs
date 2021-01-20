using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NivelEscudeiro.ExerciciosConsole
{
    [Description("Console - Exercício 1")]
    public class Console1: IExecutar
    {
        private decimal ValorA;
        private decimal ValorB;
        public void Executar()
        {
            ImprimirDescricaoExercicio();            

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

        private void ImprimirDescricaoExercicio()
        {            
            Console.WriteLine(@"
Console - Exercício 1

Crie uma aplicação, que receba os valores A e B. Mostre de forma simples, como utilizar variáveis e manipular dados.

-Some esses 2 valores;
-Faça uma subtração do valor A - B;
-Divida o valor B por A;
-Multiplique o valor A por B;
-Imprima os valores de entrada, informado se o número é par ou ímpar;
-Imprima todos os resultados no console, de forma que o usuário escolha a ação desejada.
---------------------------------------------------------------------------------------------------------------------------

");
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
