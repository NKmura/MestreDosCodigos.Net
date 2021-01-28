using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NivelEscudeiro.POO
{
    [Description("POO - Exercício 2")]
    public class POO2 : IExecutar
    {
        public void Executar()
        {
            ImprimirDescricaoExercicio();            

            var pessoa = new Pessoa(
                "Maria das Graças",
                new DateTime(1975, 1, 3),
                1.56m
                );

            pessoa.ImprimirPessoa();
        }

        private void ImprimirDescricaoExercicio()
        {
            Console.WriteLine(@"
POO - Exercício 2
Crie uma classe para representar uma pessoa:

-Crie os atributos privados de nome, data de nascimento e altura.
-Crie os métodos públicos necessários para sets e gets e também um método para imprimir todos dados de uma pessoa.
-Crie um método para calcular a idade da pessoa.
-Imprima os dados via console.
---------------------------------------------------------------------------------------------------------------------
");
        }
    }


    public class Pessoa
    {
        private string Nome { get; set; }
        private DateTime DataNascimento { get; set; }
        private decimal Altura { get; set; }

        public Pessoa(string nome, DateTime dataNascimento, decimal altura)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Altura = altura;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public string ObterNome()
        {
            return Nome;
        }

        public void AlterarNascimento(DateTime dataNascimento)
        {
            DataNascimento = dataNascimento;
        }

        public DateTime ObterDataDeNascimento()
        {
            return DataNascimento;
        }

        public void AlterarAltura(decimal altura)
        {
            Altura = altura;
        }

        public decimal ObterAltura()
        {
            return Altura;
        }

        public int CalcularIdadeNaData(DateTime? dataBaseCalculo = null)
        {            
            var idade  = new DateTime(
                (dataBaseCalculo ?? DateTime.Now).Subtract(DataNascimento)                
                .Ticks).Year-1;
            return idade;
        }

        public void ImprimirPessoa()
        {
            Console.WriteLine("-----------------------PESSOA-------------------------");
            Console.WriteLine($"Nome: {this.Nome}");
            Console.WriteLine($"Nascimento: {this.DataNascimento.ToShortDateString()}");
            Console.WriteLine($"Altura: {this.Altura}");
            Console.WriteLine($"Idade: {this.CalcularIdadeNaData()}");
            Console.WriteLine("------------------------------------------------------");
        }

    }

}
