using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NivelEscudeiro.ExerciciosConsole
{    
    public class Console2: IExecutar
    {
        private int Iteracoes;
        private List<Funcionario> Funcionarios = new List<Funcionario>();

        public void Executar()
        {
            Console.WriteLine("Console - Exercicio 2");
            while (Iteracoes <= 0)
            {
                Iteracoes = GetIntInput("Informe a quantidade de iterações: ");
            }

            for (int i = 0; i < Iteracoes; i++)
            {
                Funcionarios.Add(LerFuncionario(i));
            }

            var maiorSalario = Funcionarios.OrderByDescending(x => x.Salario).FirstOrDefault();
            var menorSalario = Funcionarios.OrderBy(x => x.Salario).FirstOrDefault();

            Console.WriteLine();
            Console.WriteLine("Respostas");
            Console.WriteLine($"Maior salário: {maiorSalario.Nome} [{maiorSalario.Salario.ToString("C")}]");
            Console.WriteLine($"Menor salário: {menorSalario.Nome} [{menorSalario.Salario.ToString("C")}]");
        }

        private Funcionario LerFuncionario(int iteracao)
        {
            Console.WriteLine();
            Console.WriteLine($"Funcionario {iteracao+1} ");
            Console.Write("Nome: ");
            var nome = Console.ReadLine();
            decimal salario=0;
            while (salario <= 0)
            {
                salario = GetDecimalInput("Salário: ");
            }

            return new Funcionario(nome, salario);
        }


        private int GetIntInput(string mensagem)
        {
            Console.Write(mensagem);
            Int32.TryParse(Console.ReadLine(), out int valor);
            return valor;
        }

        private decimal GetDecimalInput(string mensagem)
        {
            Console.Write(mensagem);
            Decimal.TryParse(Console.ReadLine(), out decimal valor);
            return valor;
        }        
    }

    internal class Funcionario
    {
        public string Nome { get; set; }
        public decimal Salario { get; set; }

        public Funcionario(string nome, decimal salario)
        {
            Nome = nome;
            Salario = salario;
        }
    }
}

