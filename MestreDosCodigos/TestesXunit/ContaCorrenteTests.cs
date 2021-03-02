using Bogus;
using NivelEscudeiro.POO;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestesXUnit
{
    //colocar o nome mais acertivo nos nomes 
    public class ContaCorrenteTests
    {
        private readonly Faker _faker;

        public ContaCorrenteTests()
        {
            _faker = new Faker();
        }

        [Fact]
        public void Sacar_SeTiver500ETaxaFor10_ESolicitar300_DeveRestar190()
        {            
            var cc = CriarConta(500, 10);
            var valorSaque = 300;
            var saldoEsperado = 190;

            cc.Sacar(valorSaque);
            Assert.Equal(saldoEsperado, cc.ObterSaldo());
        }

        [Fact]
        public void Depositar_SeSaldoFor100ETaxaFor20_EDepositar100_DeveTerSaldo180()
        {
            var cc = CriarConta(100,20);
            var valorDeposito = 100;
            var saldoEsperado = 180;

            cc.Depositar(valorDeposito);
            Assert.Equal(saldoEsperado, cc.ObterSaldo());
        }

        private ContaCorrente CriarConta(double saldo, double taxa)
        {           
            return new ContaCorrente(
                "12345-7",
                saldo,
                taxa
                );
        }
    }
}
