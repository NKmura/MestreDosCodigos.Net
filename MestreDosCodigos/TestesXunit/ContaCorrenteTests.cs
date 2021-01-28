using Bogus;
using NivelEscudeiro.POO;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestesXUnit
{
    public class ContaCorrenteTests
    {
        private readonly Faker _faker;

        public ContaCorrenteTests()
        {
            _faker = new Faker();
        }

        [Fact]
        public void DeveSacarCorretamente()
        {            
            var cc = CriarConta();
            var valorSaque = cc.ObterSaldo() * 0.01d;
            var saldoEsperado = cc.ObterSaldo() - cc.ObterTaxa() - valorSaque;

            cc.Sacar(valorSaque);
            Assert.Equal(saldoEsperado, cc.ObterSaldo());
        }

        [Fact]
        public void DeveDepositarCorretamente()
        {
            var cc = CriarConta();
            var valorDeposito = cc.ObterSaldo() * 0.3d;
            var saldoEsperado = cc.ObterSaldo() - cc.ObterTaxa() + valorDeposito;

            cc.Depositar(valorDeposito);
            Assert.Equal(saldoEsperado, cc.ObterSaldo());
        }

        private ContaCorrente CriarConta()
        {
            double saldo = _faker.Random.Int(1000, 10000);
            double taxa = saldo * 0.02d;

            return new ContaCorrente(
                "12345-7",
                saldo,
                taxa
                );
        }
    }
}
