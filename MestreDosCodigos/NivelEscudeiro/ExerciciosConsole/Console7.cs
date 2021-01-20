using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace NivelEscudeiro.ExerciciosConsole
{
    [Description("Console - Exercício 7")]
    public class Console7: IExecutar
    {
        public void Executar()
        {
            ImprimirDescricaoExercicio();                        

            Console.WriteLine("Informe 4 números inteiros maiores que 0:");
            var numeros = new List<int>();

            while (numeros.Count < 4)
            {
                Console.Write($"Número {numeros.Count+1}: ");
                Int32.TryParse(Console.ReadLine(), out int numero);
                if (numero > 0) numeros.Add(numero);
            }

            var numerosPares = numeros.Where(x => x % 2 == 0);
            Console.WriteLine($"Soma dos números pares: {(numerosPares.Count() > 0 ? numerosPares.Sum() : 0)}");
        }

        private void ImprimirDescricaoExercicio()
        {
            Console.WriteLine(@"
Console - Exercício 7
Faça uma aplicação ler 4 números inteiros e calcular a soma dos que forem pares.
------------------------------------------------------------------------------------
");

        }
    }
}
