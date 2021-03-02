using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NivelEscudeiro.POO;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestesMsTest
{
    [TestClass]
    public class ContaCorrenteTests
    {
        private readonly Faker _faker;

        public ContaCorrenteTests()
        {
            _faker = new Faker();
        }

        [TestMethod]
        public void Sacar_SeTiver500ETaxaFor10_ESolicitar300_DeveRestar190()
        {
            var cc = CriarConta(500,10);
            var valorSaque = 300;
            var saldoEsperado = 190;

            cc.Sacar(valorSaque);
            Assert.AreEqual(saldoEsperado, cc.ObterSaldo());
        }

        [TestMethod]
        public void Depositar_SeSaldoFor100ETaxaFor20_EDepositar100_DeveTerSaldo180()
        {
            var cc = CriarConta(100,20);
            var valorDeposito = 100;
            var saldoEsperado = 180;

            cc.Depositar(valorDeposito);
            Assert.AreEqual(saldoEsperado, cc.ObterSaldo());
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
