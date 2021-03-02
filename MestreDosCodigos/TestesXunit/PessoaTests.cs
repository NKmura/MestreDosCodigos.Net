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

            Assert.Equal(pessoaEsperada.Nome, pessoa.Nome);
            Assert.Equal(pessoaEsperada.DataNascimento, pessoa.DataNascimento);
            Assert.Equal(pessoaEsperada.Altura, pessoa.Altura);
        }
       

        [Fact]       
        public void SePessoaNasceuEm91Em2021DevePossuir29Anos()
        {
            var pessoa = InstanciarPessoa();
            pessoa.DataNascimento = new DateTime(1991, 8, 4);
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
