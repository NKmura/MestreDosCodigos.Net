using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace NivelEscudeiro.ExerciciosConsole
{
    [Description("Console - Exercício 9")]
    public class Console9: IExecutar
    {
        public List<int> Inteiros { get; set; } = new List<int>();
        private Random Randomizador { get; set; } = new Random();
        public void Executar()
        {
            ImprimirDescricaoExercicio();                        
            int quantidade = 0;
            while (quantidade <= 0)
            {
                Console.Write("Informe a quantidade de elementos que deverão ser randomizados para a lista: ");
                Int32.TryParse(Console.ReadLine(), out quantidade);
            }
            LerValores(quantidade);

            Inteiros.Escrever("Todos elementos");

            Inteiros.OrderBy(x=> x).Escrever("Ordem crescente");

            Inteiros.OrderByDescending(x => x).Escrever("Ordem Decrescente");

            new List<int> { Inteiros.FirstOrDefault()}.Escrever("Primeiro elemento");

            new List<int> { Inteiros.LastOrDefault() }.Escrever("Último elemento");

            Inteiros = Inteiros.Prepend(Randomizador.Next(1, 100)).ToList();
            Inteiros.Escrever("Adicionado um elemento no início");

            Inteiros.Add(Randomizador.Next(1, 1000));
            Inteiros.Escrever("Adicionado um elemento no fim");

            Inteiros.RemoveAt(0);
            Inteiros.Escrever("Removido primeiro elemento");

            Inteiros.RemoveAt(Inteiros.Count() - 1);
            Inteiros.Escrever("Removido último elemento");

            Inteiros.Where(x => x % 2 == 0).Escrever("Números pares");

            Inteiros.Where(x => x % 2 == 1).Escrever("Números ímpares");

            Inteiros.ToArray();

        }

        private void ImprimirDescricaoExercicio()
        {
            Console.WriteLine(@"
Console - Exercício 9
Utilizando a biblioteca LINQ crie no console e execute:

-Crie uma lista que receba inteiros (randomizei a criação dos números para facilitar o teste).
-Imprimir todos os números da lista.
-Imprimir todos os números da lista na ordem crescente.
-Imprimir todos os números da lista na ordem decrescente.
-Imprima apenas o primeiro número da lista.
-Imprima apenas o ultimo número da lista.
-Insira um número no início da lista.
-Insira um número no final da lista.
-Remova o primeiro número.
-Remova o último número.
-Retorne apenas os números pares.
-Retorne apenas o número informado.
-Transforme todos os números da lista em um Array.
-----------------------------------------------------------------------------------------------------
");            
        }

        private void LerValores(int quantidadeDeElementos)
        {
            int valor;
            Console.WriteLine("Informe os números. Obs: numeros maiores ou iguais a 0.");
            Console.WriteLine("");
            for (int i = 0; i < quantidadeDeElementos; i++)
            {
                valor = -1;
                while (valor < 0)
                {
                    Console.Write($"Número [{i + 1}]:");
                    int.TryParse(Console.ReadLine(), out valor);
                }
                Inteiros.Add(valor);                
            }            
            Console.WriteLine();
        }

    }

    internal static class ListLongExtensions
    {
        public static void Escrever(this IEnumerable<int> lista, string titulo)
        {
            var numeros = string.Join(", ", lista.Select(n => n.ToString()));
            Console.WriteLine($"{titulo}: {numeros}.");
            Console.WriteLine();
        }
    }
}
