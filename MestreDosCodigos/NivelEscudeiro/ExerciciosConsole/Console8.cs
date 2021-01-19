using System;
using System.Collections.Generic;
using System.Linq;

namespace NivelEscudeiro.ExerciciosConsole
{
    public class Console8: IExecutar
    {
        private List<decimal> Numeros { get; set; } = new List<decimal>();

        public void Executar()
        {
            Console.WriteLine("Console - Exercício 8");
            Console.WriteLine();
            int opcao = 0;

            while (opcao != 4)
            {
                opcao = ExibirMenu();
                ExecutarAcao(opcao);
            }


        }

        private void ExecutarAcao(int opcao)
        {
            switch ((OpcoesConsole8Enum)opcao)
            {
                case OpcoesConsole8Enum.Ler:
                    LerNumeros();
                    break;
                case OpcoesConsole8Enum.EscreverCrescente:
                    EscreverCrescente();
                    break;
                case OpcoesConsole8Enum.EscreverDecrescente:
                    EscreverDecrescente();
                    break;
                case OpcoesConsole8Enum.Encerrar:
                    Console.WriteLine("Programa encerrado.");
                    break;                
            }            
        }

        private void EscreverCrescente()
        {
            Console.WriteLine("");
            Console.WriteLine("---------------------Números em ordem crescente------------------");
            var listaOrdenada = Numeros.OrderBy(x => x).ToList();
            listaOrdenada.ForEach(n => Console.WriteLine(n));
            Console.WriteLine("-----------------------------------------------------------------");            
        }

        private void EscreverDecrescente()
        {
            Console.WriteLine("");
            Console.WriteLine("---------------------Números em ordem decrescente------------------");
            var listaOrdenada = Numeros.OrderByDescending(x => x).ToList();
            listaOrdenada.ForEach(n => Console.WriteLine(n));
            Console.WriteLine("-----------------------------------------------------------------");
        }

        private int ExibirMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("---------------------OPÇÔES------------------");
            Console.WriteLine("|  1- Informar números                       |");
            Console.WriteLine("|  2- escrever em ordem crescente            |");
            Console.WriteLine("|  3- escrever em ordem decrescente          |");
            Console.WriteLine("|  4- Encerrar                               |");
            Console.WriteLine("---------------------------------------------");

            int opcao = 0;

            while (opcao < 1 || opcao > 4)
            {
                Console.Write("Opção: ");
                Int32.TryParse(Console.ReadLine(), out opcao);
            }

            return opcao;
        }

        private void LerNumeros()
        {
            Numeros = new List<decimal>();
            Console.WriteLine("");            
            int quantidade = 0;
            while (quantidade==0)
            {
                Console.Write("Quantidade de números a serem inseridos: ");
                Int32.TryParse(Console.ReadLine(), out quantidade);
            }

            Console.WriteLine("");
            while (Numeros.Count < quantidade)
            {
                Console.Write($"Número [{Numeros.Count+1}]: ");
                decimal valor = Decimal.MinValue;
                Decimal.TryParse(Console.ReadLine(), out  valor);
                if (valor != Decimal.MinValue) Numeros.Add(valor);
            }            
        }
    }

    public enum OpcoesConsole8Enum: int
    {
        Ler = 1,
        EscreverCrescente = 2,
        EscreverDecrescente =3,
        Encerrar = 4
    }
}
