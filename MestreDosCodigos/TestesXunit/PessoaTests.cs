using Bogus;
using ExpectedObjects;
using NivelEscudeiro.POO;
using System;
using Xunit;

namespace TestesXUnit
{
    public class PessoaTests
    {
        private readonly Faker _faker;

        public PessoaTests()
        {
            _faker = new Faker();
        }

        [Fact]
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

            Assert.Equal(pessoaEsperada.Nome, pessoa.ObterNome());
            Assert.Equal(pessoaEsperada.DataNascimento, pessoa.ObterDataDeNascimento());
            Assert.Equal(pessoaEsperada.Altura, pessoa.ObterAltura());
        }

        [Theory]
        [InlineData("Rafael Nakamura")]
        [InlineData("Maria Aparecida")]
        public void DeveAlterarNomeCorretamente(string nomeAlteracao)
        {
            var pessoa = InstanciarPessoa();

            pessoa.AlterarNome(nomeAlteracao);
            Assert.Equal(nomeAlteracao, pessoa.ObterNome());
        }

        [Theory]
        [InlineData(1991, 2, 3)]
        [InlineData(1987, 9, 20)]
        public void DeveAlterarNascimentoCorretamente(int ano, int mes, int dia)
        {
            var dataEsperada = new DateTime(ano, mes, dia);

            var pessoa = InstanciarPessoa();

            pessoa.AlterarNascimento(dataEsperada);
            Assert.Equal(dataEsperada, pessoa.ObterDataDeNascimento());
        }

        [Theory]
        [InlineData(1.78)]
        [InlineData(1.87)]
        public void DeveAlteraAlturaCorretamente(decimal novaAltura)
        {
            var pessoa = InstanciarPessoa();

            pessoa.AlterarAltura(novaAltura);
            Assert.Equal(novaAltura, pessoa.ObterAltura());
        }

        [Fact]       
        public void DeveCalcularIdadeCorretamente()
        {
            var pessoa = InstanciarPessoa();
            pessoa.AlterarNascimento(new DateTime(1991, 8, 4));
            var idade = pessoa.CalcularIdadeNaData(new DateTime(2021, 1, 28));
            Assert.Equal(idade, 29);
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
