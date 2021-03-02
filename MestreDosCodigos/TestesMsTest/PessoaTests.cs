using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NivelEscudeiro.POO;
using System;

namespace TestesMsTest
{
    [TestClass]
    public class PessoaTests
    {
        private Faker _faker;
        public PessoaTests ()
        {
            _faker = new Faker();
        }

        [TestMethod]
        public void DeveInstanciarPessoaCorretamente()
        {
            var pessoaEsperada = new
            {
                Nome = _faker.Name.FullName(),
                DataNascimento = new DateTime(1990, 1, 1),
                Altura = _faker.Random.Decimal(1, 2)
            };

            var pessoa = new Pessoa(
                pessoaEsperada.Nome,
                pessoaEsperada.DataNascimento,
                pessoaEsperada.Altura
                );

            Assert.AreEqual(pessoaEsperada.Nome, pessoa.Nome);
            Assert.AreEqual(pessoaEsperada.DataNascimento, pessoa.DataNascimento);
            Assert.AreEqual(pessoaEsperada.Altura, pessoa.Altura);
        }

        [TestMethod]
        public void SePessoaNasceuEm91Em2021DevePossuir29Anos()
        {
            var pessoa = InstanciarPessoa();
            pessoa.DataNascimento = new DateTime(1991, 8, 4);
            var idade = pessoa.CalcularIdadeNaData(new DateTime(2021, 1, 28));
            Assert.AreEqual(idade, 29);
        }

        private Pessoa InstanciarPessoa()
        {
            return new Pessoa(
              _faker.Name.FullName(),
              new DateTime(1990, 1, 1),
              _faker.Random.Decimal(1, 2)
          );
        }

    }
}
