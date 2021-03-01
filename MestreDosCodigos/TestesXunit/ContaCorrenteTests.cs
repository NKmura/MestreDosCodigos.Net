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
        public void DeveSacarCorretamente()
        {            
            var cc = CriarConta();
            var valorSaque = Math.Round((cc.ObterSaldo() * 0.01d),2);
            var saldoEsperado = Math.Round((cc.ObterSaldo() - cc.ObterTaxa() - valorSaque),2);

            cc.Sacar(valorSaque);
            Assert.Equal(saldoEsperado, cc.ObterSaldo());
        }

        [Fact]
        public void DeveDepositarCorretamente()
        {
            var cc = CriarConta();
            var valorDeposito = Math.Round((cc.ObterSaldo() * 0.3d),2);
            var saldoEsperado = Math.Round((cc.ObterSaldo() - cc.ObterTaxa() + valorDeposito),2);

            cc.Depositar(valorDeposito);
            Assert.Equal(saldoEsperado, cc.ObterSaldo());
        }

        private ContaCorrente CriarConta()
        {
            double saldo = _faker.Random.Int(1000, 10000);
            double taxa = Math.Round((saldo * 0.02d),2);

            return new ContaCorrente(
                "12345-7",
                saldo,
                taxa
                );
        }
    }
}
