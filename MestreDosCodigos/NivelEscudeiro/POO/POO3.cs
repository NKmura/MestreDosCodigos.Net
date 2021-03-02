using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NivelEscudeiro.POO
{
    [Description("POO - Exercício 3")]
    public class POO3 : IExecutar
    {
        private ContaCorrente ContaCorrente { get; set; } = new ContaCorrente("12345-6", 1000, 1);
        private ContaEspecial ContaEspecial { get; set; } = new ContaEspecial("98765-4", 500, 1000);
        public void Executar()
        {            
            int opcao = 0;
            while (opcao != (int)OpcoesPOO3Enum.Encerrar)
            {
                ImprimirDescricaoExercicio();
                ImprimirContas();
                opcao = ExibirMenu();
                ExecutarOpcao(opcao);
                if(opcao != (int)OpcoesPOO3Enum.Encerrar) Console.Clear();
            }
           
        }

        private void ImprimirContas()
        {
            Console.WriteLine("-------------------------------------CONTAS-------------------------------------");
            ContaCorrente.MostraDados();
            ContaEspecial.MostraDados();
            Console.WriteLine("---------------------------------------------------------------------------------");
        }

        private double LerValor()
        {
            double valor=0;

            while (valor <= 0)
            {
                Console.Write("Informe o valor: ");
                Double.TryParse(Console.ReadLine(), out valor);
            }
            return valor;
        }

        private ContaBancaria SelecionarConta()
        {
            int opcao = 0;

            Console.WriteLine(@"

---------------- Selectione a Conta -----------
1- Conta corrente
2- Conta especial
------------------------------------------------
");
            while (opcao != 1 && opcao !=2)
            {
                Console.Write("Conta: ");
                Int32.TryParse(Console.ReadLine(), out opcao);
            }
            if (opcao == 1) return ContaCorrente;
            else return ContaEspecial;            
        }

        private int ExibirMenu()
        {
            int opcao = 0;

            Console.WriteLine(@"

---------------- OPÇÕES -----------
1- Depositar
2- Sacar
3- Encerrar
-----------------------------------
");
            while(opcao<=0 || opcao > 3)
            {
                Console.Write("Opção: ");
                Int32.TryParse(Console.ReadLine(), out opcao);
            }
            return opcao;
        }

        private void ExecutarOpcao(int opcao)
        {            
            switch ((OpcoesPOO3Enum)opcao)
            {
                case OpcoesPOO3Enum.Depositar:
                    SelecionarConta().Depositar(LerValor());
                    break;
                case OpcoesPOO3Enum.Sacar:
                    SelecionarConta().Sacar(LerValor());
                    break;                
                case OpcoesPOO3Enum.Encerrar:
                    Console.WriteLine("Aplicação encerrada.");
                    break;
                
            }
        }

        private void ImprimirDescricaoExercicio()
        {
            Console.WriteLine(@"
POO - Exercício 3
Faça uma aplicação bancária.

-Crie uma classe abstrata ContaBancaria que contém como atributos, NumeroDaConta e Saldo. 
 E como métodos abstratos Sacar e Depositar que recebem um parâmetro do tipo double.
-Crie as classes ContaCorrente e ContaEspecial que herdam da ContaBancaria.
-A ContaCorrente possui um atributo taxaDeOperacao que é descontado sempre que um saque e um depósito são feitos.
-A ContaEspecial possui um atributo Limite que dá credito a mais para o correntista caso ele precise sacar mais que o saldo.
 Neste caso, o saldo pode ficar negativo desde que não ultrapasse o limite. Contudo isso não pode acontecer na classe ContaCorrente.
-Crie uma interface Imprimivel que declara um método MostrarDados, implemente em ambas as contas e imprima os dados em cada uma.
-Via console, abra 2 contas de cada tipo e execute todas as operações.
-----------------------------------------------------------------------------------------------------------
");
        }
    }

    internal enum OpcoesPOO3Enum: int
    {
        Depositar=1,
        Sacar=2,        
        Encerrar=3
    }

    public abstract class ContaBancaria
    {
        protected string NumeroDaConta { get; set; }
        protected double Saldo { get; set; }

        protected ContaBancaria(string numeroDaConta, double saldo)
        {
            NumeroDaConta = numeroDaConta;
            Saldo = saldo;
        }

        public double ObterSaldo()
        {
            return Saldo;
        }

        public abstract void Sacar(double valor);
        public abstract void Depositar(double valor);        
    }

    public class ContaCorrente: ContaBancaria, Imprimivel
    {
        public double TaxaDeOperacao { get; set; }

        public ContaCorrente(
            string numeroDaConta, 
            double saldo,
            double taxaDeOperacao) : base(numeroDaConta, saldo)
        {
            this.TaxaDeOperacao = taxaDeOperacao;
        }

        public double ObterTaxa()
        {
            return TaxaDeOperacao;
        }
        
        public override void Depositar(double valor)
        {
            if((this.Saldo+ valor - this.TaxaDeOperacao) > 0)
            {
                Saldo += valor-this.TaxaDeOperacao;
                Saldo = Math.Round(Saldo, 2);
                Console.WriteLine($"Depósito realizado: {valor.ToString("C")}.");
            }            
        }

        public override void Sacar(double valor)
        {
            if (this.Saldo -(valor + TaxaDeOperacao) >= 0)
            {
                this.Saldo -= (valor + TaxaDeOperacao);
                Saldo = Math.Round(Saldo, 2);
                Console.WriteLine($"Saque realizado: {valor.ToString("C")}.");                
            }
            else
            {
                Console.WriteLine($"Tentativa de saque: {valor.ToString("C")}. Saldo insuficiente. ");                
            }
        }

        public void MostraDados()
        {
            Console.WriteLine($"Conta corrente| Número: {this.NumeroDaConta}, Saldo: {this.Saldo.ToString("C")}, Taxa: {this.TaxaDeOperacao.ToString("C")}");            
        }
    }

    public class ContaEspecial : ContaBancaria, Imprimivel
    {
        private double Limite { get; set; }
        public ContaEspecial(
            string numeroDaConta, 
            double saldo,
            double limite) : base(numeroDaConta, saldo)
        {
            this.Limite = limite;
        }

        public override void Depositar(double valor)
        {
            this.Saldo += valor;
            Saldo = Math.Round(Saldo, 2);
            Console.WriteLine($"Depósito realizado: {valor.ToString("C")}.");
        }

        public override void Sacar(double valor)
        {
            if((Saldo-valor) >= (Limite * -1))
            {
                Saldo -= valor;
                Saldo = Math.Round(Saldo, 2);
                Console.WriteLine($"Saque realizado: {valor.ToString("C")}.");                
            }
            else
            {                
                Console.WriteLine($"Tentativa de saque: {valor.ToString("C")}. Saldo insuficiente.");
            }
        }

        public void MostraDados()
        {
            Console.WriteLine($"Conta especial| Número: {this.NumeroDaConta}, Saldo: {this.Saldo.ToString("C")}, Limite: {this.Limite.ToString("C")}");            
        }
    }

    public interface Imprimivel
    {
        void MostraDados();
    }

}
