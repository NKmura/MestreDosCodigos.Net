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

            Assert.AreEqual(pessoaEsperada.Nome, pessoa.ObterNome());
            Assert.AreEqual(pessoaEsperada.DataNascimento, pessoa.ObterDataDeNascimento());
            Assert.AreEqual(pessoaEsperada.Altura, pessoa.ObterAltura());
        }


        [TestMethod]
        [DataRow("Rafael Nakamura")]
        [DataRow("Maria Aparecida")]
        public void DeveAlterarNomeCorretamente(string nomeAlteracao)
        {
            var pessoa = InstanciarPessoa();

            pessoa.AlterarNome(nomeAlteracao);
            Assert.AreEqual(nomeAlteracao, pessoa.ObterNome());
        }

        [TestMethod]
        [DataRow(1991, 2, 3)]
        [DataRow(1987, 9, 20)]
        public void DeveAlterarNascimentoCorretamente(int ano, int mes, int dia)
        {
            var dataEsperada = new DateTime(ano, mes, dia);

            var pessoa = InstanciarPessoa();

            pessoa.AlterarNascimento(dataEsperada);
            Assert.AreEqual(dataEsperada, pessoa.ObterDataDeNascimento());
        }

        [TestMethod]        
        public void DeveAlteraAlturaCorretamente()
        {
            var novaAltura = 1.78m;
            var pessoa = InstanciarPessoa();

            pessoa.AlterarAltura(novaAltura);
            Assert.AreEqual(novaAltura, pessoa.ObterAltura());
        }

        [TestMethod]
        public void DeveCalcularIdadeCorretamente()
        {
            var pessoa = InstanciarPessoa();
            pessoa.AlterarNascimento(new DateTime(1991, 8, 4));
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
