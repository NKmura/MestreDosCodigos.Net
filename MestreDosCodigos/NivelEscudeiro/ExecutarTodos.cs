using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace NivelEscudeiro
{
    public class ExecutarTodos : IExecutar
    {
        private static List<Exercicio> Exercicios { get; set; } 
        static ExecutarTodos()
        {
            Exercicios = new List<Exercicio>();
            var executarType = typeof(IExecutar);
            int sequencia = 0;
            (from type in typeof(ExecutarTodos).Assembly.GetExportedTypes()
             where
                 executarType.IsAssignableFrom(type) &&
                 type.Name != "ExecutarTodos" &&
                 type.IsClass
             select type)
             .OrderBy(x => x.Name)
             .ToList()
             .ForEach(ap => {
                 sequencia++;
                 var description = (DescriptionAttribute)Attribute.GetCustomAttribute(ap, typeof(DescriptionAttribute));
                 Exercicios.Add(new Exercicio
                 {
                     Numero = sequencia,
                     Tipo = ap,
                     Nome = description.Description
                 });
             });
        }

        public void Executar()
        {
            int opcao = 0;
            while(opcao!= (Exercicios.Count + 1))
            {
                opcao = ExibirMenu();
                ExecutarExercicio(opcao);
                if(opcao!= Exercicios.Count + 1)
                {
                    Console.WriteLine("Aperte alguma tecla para voltar ao menu.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }          
        }

        private int ExibirMenu()
        {
            int opcao = 0;
            Console.WriteLine(@"
INFORMAÇÕES
-Essa aplicação permite executar todos os exercícios presentes na solução,
 para isso basta digitar o número do exercício desejado e apertar a tecla enter.

-Ao encerrar um exercício você será redirecionado novamente ao menu de seleção.
");

            Console.WriteLine("-----------------------------------Exercícios-------------------------------------");
            Exercicios.ForEach(e=> Console.WriteLine($"[{e.Numero}] - {e.Nome}"));
            Console.WriteLine($"[{Exercicios.Count() + 1}] - Encerrar");
            Console.WriteLine("----------------------------------------------------------------------------------");            

            while(opcao<=0 || opcao> (Exercicios.Count+1))
            {
                Console.Write("Executar exercicio nº: ");
                Int32.TryParse(Console.ReadLine(), out opcao);
            }
            return opcao;
        }

        private void ExecutarExercicio(int numero)
        {
            var exercicio = Exercicios.FirstOrDefault(x => x.Numero == numero);
            if (exercicio != null)
            {
                Console.Clear();
                ((IExecutar)Activator.CreateInstance(exercicio.Tipo)).Executar();                
            }
        }
    }

    internal class Exercicio
    {
        public int Numero { get; set; }
        public Type Tipo { get; set; }
        public string Nome { get; set; }
    }
}
