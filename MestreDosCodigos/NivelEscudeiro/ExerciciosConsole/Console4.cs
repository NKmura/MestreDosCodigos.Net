using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NivelEscudeiro.ExerciciosConsole
{
    public class Console4: IExecutar
    {
        private List<Aluno> Alunos = new List<Aluno>();        

        public void Executar()
        {
            Console.WriteLine("Console - Exercício 3");
            Console.WriteLine();
            int opcao = 0;

            while (opcao != 3)
            {
                opcao = ExibirMenu();
                ExecutarAcao(opcao);
            }


        }

        private int ExibirMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("---------------------OPÇÔES------------------");
            Console.WriteLine("|  1- Informar alunos                        |");
            Console.WriteLine("|  2- Escrever alunos com média maior que 7  |");
            Console.WriteLine("|  3- Encerrar                               |");
            Console.WriteLine("---------------------------------------------");

            int opcao =0;

            while (opcao <1 || opcao>3)
            {
                Console.Write("Opção: ");
                Int32.TryParse(Console.ReadLine(), out opcao);                
            }

            return opcao;
        }

        private void ExecutarAcao(int acao)
        {
            switch ((OpcoesEnum)acao)
            {
                case OpcoesEnum.LerAlunos:
                    LerAlunos();
                    break;
                case OpcoesEnum.EscreverMedias:
                    EscreverAlunosComMediaMaiorQue7();
                    break;
                case OpcoesEnum.Encerrar:
                    Console.WriteLine("Aplicação encerrada...");
                    break;               
            }
        }

        private void EscreverAlunosComMediaMaiorQue7()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("------------------------Alunos com média maior que 7 -----------------------------");
            var alunosComMediaMaiorQue7 = this.Alunos.Where(x => x.Media >= 7).ToList();

            if (alunosComMediaMaiorQue7.Count == 0)
            {
                Console.WriteLine("-Nenhum aluno encontrado.");
                return;
            }

            alunosComMediaMaiorQue7.OutputAlunos();            
        }

        private void LerAlunos()
        {
            Console.WriteLine();
            Alunos = new List<Aluno>();
            int quantidadeDeAlunos = 0;
            while (quantidadeDeAlunos<1 || quantidadeDeAlunos>10)
            {
                Console.Write("Informe a quantidade de alunos a serem inseridos entre 1 e 10: ");
                Int32.TryParse(Console.ReadLine(), out quantidadeDeAlunos);
            }

            for (int i = 1; i <= quantidadeDeAlunos; i++)
            {
                var aluno = new Aluno();
                Console.WriteLine($"Aluno N:{i}");
                aluno.LerNome();
                aluno.LerNotas();
                Console.WriteLine();
                Alunos.Add(aluno);
            }
        }        
    }

    public enum OpcoesEnum: int
    {
        LerAlunos=1,
        EscreverMedias=2,
        Encerrar=3
    }

    public class Aluno
    {
        public string Nome { get; set; }
        List<decimal> Notas { get; set; } = new List<decimal>();
        public decimal Media => Notas.Count == 0 ? 0 : Math.Round((Notas.Sum(x => x) / Notas.Count),2);
        
        public void LerNome()
        {
            Console.Write("Nome: ");
            this.Nome = Console.ReadLine();
        }

        public void LerNotas()
        {
            Console.WriteLine("");
            Console.WriteLine("Informe notas de 1 a 10:");            
            while (Notas.Count < 4)
            {
                decimal notaInput =-1;
                Console.Write($"Nota {Notas.Count+1}: ");
                Decimal.TryParse(Console.ReadLine(), out notaInput);

                if (notaInput > 0 && notaInput <= 10) Notas.Add(notaInput);                
            }
        }
    }

    public static class ListAlunosExtensions
    {
        public static void OutputAlunos(this List<Aluno> alunos)
        {
            foreach (var a in alunos)
            {
                Console.WriteLine();                
                Console.WriteLine($"Aluno: {a.Nome}");
                Console.WriteLine($"Média: {a.Media}");
                Console.WriteLine("--------------------------");
            }            
        }
    }
}

