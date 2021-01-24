using System;
using System.ComponentModel;

namespace NivelEscudeiro.ExerciciosConsole
{
    [Description("Console - Exercício 5")]
    public class Console5: IExecutar
    {
        public void Executar()
        {
            ImprimirDescricaoExercicio();
            int a = LerInt("Valor de a:");
            int b = LerInt("Valor de b:");
            int c = LerInt("Valor de c:");

            //Passo 1 - Achar o valor de Delta
            var delta = (Math.Pow(b, 2) - (4 * a * c));

            var raizDelta = Math.Sqrt(delta);
            if (Double.IsNaN(raizDelta))
            {
                Console.WriteLine("A equação de 2º grau não possúi raizes reais!");
                return;
            }

            //passo 2 - Bhaskara
            var x1 = (-b + raizDelta)/ (2 * a);

            var x2 = (-b - raizDelta) / (2 * a);

            Console.WriteLine(@"
Resultados");
            Console.WriteLine();
            Console.WriteLine($"Valor x': {x1}");
            Console.WriteLine($"Valor x'': {x2}");
        }

        public int LerInt(string descricao)
        {
            int valor=0;
            while (valor == 0)
            {
                Console.Write(descricao);
                Int32.TryParse(Console.ReadLine(), out valor);
            }
            return valor;
        }

        private void ImprimirDescricaoExercicio()
        {
            Console.WriteLine(@"
Console - Exercício 5
Crie uma aplicação que calcule a fórmula de Bhaskara.

-Receba os valores a, b, c.
-Imprima os resultados R1 e R2.
-Use a biblioteca MATH.
------------------------------------------------------------
");            
        }
    }
}
