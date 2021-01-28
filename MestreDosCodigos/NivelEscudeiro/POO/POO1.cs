using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NivelEscudeiro.POO
{
    #region 1- O que é POO?- Exemplo
    //Programação Orientada a Objetos (POO) é um paradigma de programação no qual tenta aproximar a codificação das estruturas de um programa a objetos do mundo real, 
    //é por esse motivo que se chama orientada a "objetos" que é algo completamente genérico e que pode representar qualquer coisa tangivel do mundo.
    //No exemplo abaixo construi duas classe, sendo a primeira uma representação simples de um carro e a segunda de um cachorro.
    internal class Carro
    {
        public string Cor { get; set; }
        public int Ano { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public bool Ligado { get; set; }
        public int Velocidade { get; set; }

        public void Buzinar()
        {
            Console.WriteLine("Foooon!");
        }

        public void Ligar()
        {
            Ligado = true;
        }

        public void Acelerar()
        {
            this.Velocidade++;
        }

        public void Frear()
        {
            this.Velocidade = 0;
        }
    }

    internal class Cachorro
    {
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Raca { get; set; }

        public void Latir()
        {
            Console.WriteLine("Au Au!");
        }
    }


    #endregion

    #region 2- O que é polimorfismo? - Exemplo
    //Polimorfismo é o conceito que define que o mesmo método pode ser implementado de diferentes formas em objetos de diferentes classes;
    //No exemplo abaixo utilizei uma interface a ser seguida pelas duas classes, mas suas utilização não é obrigatória,
    //observe que as classes 'AcrescentarUm' e 'AcrescentarQuatro' possuem o mesmo método 'Acrescentar' porém cada uma possui uma implementação diferente.   

    internal interface IAcrescentar
    {
        int Valor { get; set; }
        public int Acrescentar();
    }

    internal class AcrescentarUm : IAcrescentar
    {
        public int Valor { get; set; }

        public int Acrescentar()
        {
            Valor++;
            return Valor;
        }
    }

    internal class AcrescentarQuatro : IAcrescentar
    {
        public int Valor { get; set; }

        public int Acrescentar()
        {
            Valor += 4;
            return Valor;
        }
    }

    #endregion

    #region 3- O que é abstração
    //A abstração é um dos conceitos mais importantes de uma linguagem orientada a objetos, ela é a capacidade de olhar para um objeto do mundo real identificar suas caracteristicas e comportamentos
    //e modela-lo dentro da linguagem na forma de classes, essa classe sempre será somente uma representação de algo do mundo real, pois dificilmente algum desenvolvedor terá a capacidade
    //de representar por completo toda a complexidade do objeto real.A essas "representações" damos o nome de abstrações pois no fim é o que realmente são.
    //Como exemplo podem ser utilizadas todas as classes presentes nesse arquivo
    #endregion

    #region 4- O que é encapsulamento?
    //O encapsulamento é uma técnica que adiciona segurança quando implementamos em uma linguagem orientada a objetos, ela define que os detalhes internos de uma classe não devem ser visiveis e 
    //modificaveis externamente, isso é muito útil para diminuir a dependencia entre pedaços de um sistema.  
    // No exemplo abaixo temos uma classe que recebe dois valores string e gera um código a partir deles, a classe cliente sabe que ela precisa passar dois código no construtor e que 
    //ela pode chamar um método 'GerarCodigoDosValores' mas ela não consegue manipular nenhuma informação da classe de gerar código e não sabe exatamente como esse código é gerado.

    internal class GerarCodigo
    {
        private string Valor1;
        private string Valor2;
        public GerarCodigo(string valor1, string valor2)
        {
            this.Valor1 = valor1;
            this.Valor2 = valor2;
        }

        public int GerarCodigoDosValores()
        {
            return string.Concat(Valor1, Valor2).GetHashCode();
        }
    }

    #endregion

    #region 5- Quando usar uma classe abstrata e quando devo usar uma interface
    //R: A classe abstrata é uma classe não instanciavel(pelo menos não diretamente) ela pode conter um conjunto de propriedades e comportamentos completos ou não que sejam comuns a uma série de outras
    //classes que poderão ser acessadas por meio de herança.
    //As interfaces diferentes das classes abstratas não podem conter implementação nenhuma, elas possuem somente uma definição das propriedades e métodos esperados em uma classe.
    //Por esse motivo funcionam  como "contratos" pois uma vez que uma classe implemente uma interface ela deverá obrigatóriamente possuir as propriedades e métodos descritos por ela.
    //As interfaces podem ser muito poderosas se bem utilizadas, elas permitem o reaproveitamento de comportamentos, baixar o nível de acomplamento entre as partes de um sistema e criar
    //designs flexiveis e com grande capacidade de evolução.

    #region Classes abstratas
    //A classe macaco abstrato possui alguns atributos que todos os macacos devem possuir e o
    //comportamento já implementado de dormir. 
    //alem de forçar as classes que herdarem dela a implementar seu próprio método de subir em arvores.
    internal abstract class MacacoAbstrato
    {
        protected string Nome { get; set; }
        protected DateTime Nascimento { get; set; }

        public MacacoAbstrato(string nome, DateTime nascimento)
        {
            this.Nome = nome;
            this.Nascimento = nascimento;
        }

        // implementação geral de dormir para todos os macacos que herdarem macaco base
        public virtual void Dormir()
        {
            //--implementação do macaco dormindo
        }

        // definição que irá forçar cada cada classe concreta a implementar seu próprio método de subir na arvore
        public abstract void SubirNaArvore();
    }

    // a classe macaco surfista herda os atributos e o comportamento de dormir do macaco abstrato e 
    //implementa seu próprio comportamento de subir em arvore alem de um método só seu de sufar
    internal class MacacoSurfista : MacacoAbstrato
    {
        public MacacoSurfista(string nome, DateTime nascimento) : base(nome, nascimento)
        {
        }

        public override void SubirNaArvore()
        {
            //-- implementação de subir em arvore segurando a prancha de surf
        }

        public void Surfar()
        {
            //Implementação do método de surfar
        }
    }
    #endregion

    #region Interfaces
    //A interface IMacaco não pode possuir nenhuma implementação, ela só pode conter todos os atributos e comportamentos que os macacos que implementarem ela deverão possuir [obrigatóriamente]
    //casos de comportamentos específicos de um tipo de implementação como o Surfar do macaco surfista não devem ser expressos na interface,
    //pois isso forçaria a todos os macacos que implementarem a interface possuirem esse comportamento, e como sabemos.. nem todo macaco é surfista.    
    internal interface IMacaco
    {
        string Nome { get; set; }
        DateTime Data { get; set; }

        void SubirNaArvore();
        void Dormir();
    }
    //Mas como não temos limite da quantidade de interfaces que uma classe pode assinar, diferentemente da herança multiplas de classe,
    //você poderá criar uma outra interface para definir a obrigatoriedade da implementação do comportamento de surfar, e essa interface poderá ser implementada
    //somente pelos tipos de macacos surfistas. 
    //poderia ser criado ainda uma interface IMacacoSurfista que implementasse a interface IMacaco como base, desse modo todas as regras do contrato do macaco base seriam aplicadas
    //ao nosso novo contrato tbm, fazendo com que não precissemos implementar as duas interfaces nas classes concretas.
    internal interface ISurfista
    {
        void Surfar();
    }

    //O macaco normal implementa a interface IMacaco, portanto deve possuir a implementação de todas os atributos e comportamentos estipulados na interface.
    //Diferente da classe abstrata ele não recebeu a implementação já pronta do método dormir.
    internal class MacacoNormal : IMacaco
    {
        public string Nome { get; set; }
        public DateTime Data { get; set; }

        public void Dormir()
        {
            //implementacao de dormir do macaco normal
        }

        public void SubirNaArvore()
        {
            //implementação de subir na arvore do macaco normal
        }
    }

    internal class MacacoSurfistaDoHawaii : IMacaco, ISurfista
    {
        public string Nome { get; set; }
        public DateTime Data { get; set; }

        public void Dormir()
        {
            //implementacao de dormir na praia do macaco surfista do Hawaii
        }

        public void SubirNaArvore()
        {
            //implementação de subir na arvore segurando a prancha
        }

        public void Surfar()
        {
            //Implementação de surfar usando uma saia de ula 
        }
    }

    internal class MacacoSurfistaDoCeara : IMacaco, ISurfista
    {
        public string Nome { get; set; }
        public DateTime Data { get; set; }

        public void Dormir()
        {
            //implementacao de dormir do macaco surfista do ceara
        }

        public void SubirNaArvore()
        {
            //implementação de subir na arvore segurando a prancha e o usando a jabiraca
        }

        public void Surfar()
        {
            //Implementação de surfar comendo rapadura
        }
    }

    #endregion

    #endregion

    #region 6-O que faz as interfaces IDisposable, IComparable, ICloneable e IEnumerable?
    //IDisposable: Define que uma classe implemente o método Dispose(). Esse método é usado para liberar recursos não gerenciaveis, como por exemplo memória.
    internal class ExemploIDisposable : IDisposable
    {
        public MemoryStream Arquivo { get; set; }

        public ExemploIDisposable()
        {
            Arquivo = new MemoryStream();
        }
        public void Dispose()
        {
            //Código para liberar recursos não gerenciaveis
            Arquivo.Close();           
        }
    }

    //IComparable: Define que uma classe implemente o método CompareTo(). Esse método permite definir a posição de um objeto em uma ordem de classificação.
    internal class ExemploIComparable : IComparable
    {
        public int Valor { get; set; }
        public int CompareTo(Object obj)
        {
            if (obj == null) return 1;

            var exemplo = obj as ExemploIComparable;
            if (exemplo != null)
            {
                if (this.Valor < exemplo.Valor) return -1;
                else if (this.Valor > exemplo.Valor) return 1;
                else return 0;
            }
            else
            {
                throw new ArgumentException($"O objeto não é um {(typeof(ExemploIComparable).Name)}");
            }            
        }
    }

    //ICloneable:  Define quem uma classe implemente o método Clone(). Esse método permite replicar um objeto com os mesmos valores de uma instância existente.
    internal class ExemploICloneable : ICloneable
    {
        public object Clone()
        {                           
            var clone = (ExemploICloneable)this.MemberwiseClone();
            return clone;            
        }
    }

    //IEnumerable: Define que uma classe implemente o método GetEnumerator() que retorna um enumerador, esse enumerador permite a iteração simples em uma lista não generica de elementos, resumindo ele permite deixar algo "iteravel".    

    internal class ListExemploIEnumerable : IEnumerable<int>
    {
        private int[] Itens;        
        public ListExemploIEnumerable(params int[] itens)
        {
            this.Itens = itens;
        }

        public IEnumerator GetEnumerator()
        {            
            return new ListExemploIEnumerator(this.Itens);
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            return new ListExemploIEnumerator(this.Itens);
        }
    }

    internal class ListExemploIEnumerator :  IEnumerator<int>        
    {
        private int[] Itens;
        private int Index = -1;

        public int  Current { get; set; } = -1;

        object IEnumerator.Current => Current;

        public ListExemploIEnumerator(params int[] itens)
        {
            this.Itens = itens;
        }

        public void Dispose()
        {                        
        }

        public bool MoveNext()
        {
            if ((this.Index + 1) == Itens.Length) return false;
            this.Index++;
            this.Current = Itens[this.Index];
            return true;
        }

        public void Reset()
        {
            this.Index = -1;            
        }
    }
    #endregion

    #region 7-Existe herança múltipla (de classes) em C#?
    //Não é possivel que uma classe herde de mais de uma classe no C#, o que podemos fazer é utilizar 
    //as interfaces para resolver situações onde necessitariamos de multiplas definições para um mesmo objeto.

    internal class ClasseBase
    {
        //código da classe base que será herdada por todas as filhas
    }

    //Ao definir uma classe, podemos herdar somente de uma classe base. Caso a classe base herde de uma terceira classe e assim sucessivamente, sua classe irá
    //herdar todas os atributos e comportamentos de toda a hierarquia de herança.
    //O que pode ser feito para 'burlar' essa limitação é utilizar as interfaces, pois não temos limite de interfaces que uma classe pode implementar
    internal class ClasseFilha : ClasseBase, Interface1, Interface2
    {

    }

    internal interface Interface1 { }
    internal interface Interface2 { }
    #endregion
}
