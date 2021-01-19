using System;
using System.Collections.Generic;
using System.Text;

namespace NivelEscudeiro.POO
{
    public class POO3 : IExecutar
    {
        public void Executar()
        {
            Console.WriteLine("POO - Exercício 3");
            var contaCorrente = new ContaCorrente("12345-6", 1000, 1);

            contaCorrente.MostraDados();
            contaCorrente.Depositar(60);
            contaCorrente.MostraDados();
            contaCorrente.Sacar(850);
            contaCorrente.MostraDados();
            contaCorrente.Sacar(300);
            contaCorrente.MostraDados();

            var contaEspecial = new ContaEspecial("98765-4", 500, 1000);
            contaEspecial.MostraDados();
            contaEspecial.Depositar(30);
            contaEspecial.MostraDados();
            contaEspecial.Sacar(650);
            contaEspecial.MostraDados();
            contaEspecial.Sacar(1000);
            contaCorrente.MostraDados();
        }
    }

    internal abstract class ContaBancaria
    {
        protected string NumeroDaConta { get; set; }
        protected double Saldo { get; set; }

        protected ContaBancaria(string numeroDaConta, double saldo)
        {
            NumeroDaConta = numeroDaConta;
            Saldo = saldo;
        }

        public abstract void Sacar(double valor);
        public abstract void Depositar(double valor);
    }

    internal class ContaCorrente: ContaBancaria, Imprimivel
    {
        public double TaxaDeOperacao { get; set; }

        public ContaCorrente(
            string numeroDaConta, 
            double saldo,
            double taxaDeOperacao) : base(numeroDaConta, saldo)
        {
            this.TaxaDeOperacao = taxaDeOperacao;
        }
        
        public override void Depositar(double valor)
        {
            if((this.Saldo+ valor - this.TaxaDeOperacao) > 0)
            {
                Saldo += valor-this.TaxaDeOperacao;
                Console.WriteLine($"Depósito realizado: {valor.ToString("C")}");
            }            
        }

        public override void Sacar(double valor)
        {
            if (this.Saldo -(valor + TaxaDeOperacao) > 0)
            {
                this.Saldo -= (valor + TaxaDeOperacao);
                Console.WriteLine($"Saque realizado: {valor.ToString("C")}");
            }
            else
            {
                Console.WriteLine($"Tentativa de saque: {valor.ToString("C")}. Saldo insuficiente.");
            }
        }

        public void MostraDados()
        {
            Console.WriteLine("----------------------------Conta Corrente-----------------------");
            Console.WriteLine($"Número: {this.NumeroDaConta}");
            Console.WriteLine($"Saldo: {this.Saldo.ToString("C")}");
            Console.WriteLine($"Taxa: {this.TaxaDeOperacao.ToString("C")}");
            Console.WriteLine("-----------------------------------------------------------------");            
        }
    }

    internal class ContaEspecial : ContaBancaria, Imprimivel
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
            Console.WriteLine($"Depósito realizado: {valor.ToString("C")}");
        }

        public override void Sacar(double valor)
        {
            if((Saldo-valor) > (Limite * -1))
            {
                Saldo -= valor;
                Console.WriteLine($"Saque realizado: {valor.ToString("C")}");
            }
            else
            {
                Console.WriteLine($"Tentativa de saque: {valor.ToString("C")}. Saldo insuficiente.");
            }
        }

        public void MostraDados()
        {
            Console.WriteLine("----------------------------Conta Especial-----------------------");
            Console.WriteLine($"Número: {this.NumeroDaConta}");
            Console.WriteLine($"Saldo: {this.Saldo.ToString("C")}");
            Console.WriteLine($"Limite: {this.Limite.ToString("C")}");
            Console.WriteLine("-----------------------------------------------------------------");
        }
    }

    public interface Imprimivel
    {
        void MostraDados();
    }

}
