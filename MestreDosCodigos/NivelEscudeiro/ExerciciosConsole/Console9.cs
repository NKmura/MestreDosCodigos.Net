using System;
using System.Collections.Generic;
using System.Linq;

namespace NivelEscudeiro.ExerciciosConsole
{
    public class Console9: IExecutar
    {
        public List<int> Inteiros { get; set; } = new List<int>();
        private Random Randomizador { get; set; } = new Random();
        public void Executar()
        {
            Console.WriteLine("Console - Exercício 9");
            Console.WriteLine("");
            int quantidade = 0;
            while (quantidade <= 0)
            {
                Console.Write("Informe a quantidade de elementos que deverão ser randomizados para a lista: ");
                Int32.TryParse(Console.ReadLine(), out quantidade);
            }
            PopularLista(quantidade);

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

        private void PopularLista(int quantidadeDeElementos)
        {
            Console.WriteLine("");
            Console.WriteLine("Randomizando elementos...");
            
            for (int i = 0; i < quantidadeDeElementos; i++)
            {
                var numeroRandomizado = Randomizador.Next(1, 1000);
                if(!Inteiros.Contains(numeroRandomizado)) Inteiros.Add(Randomizador.Next(1, 1000));
            }
            Console.WriteLine("Randomização finalizada...");
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
