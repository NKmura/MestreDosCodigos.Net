using System;
using System.ComponentModel;

namespace NivelEscudeiro.ExerciciosConsole
{
    [Description("Console - Exercício 5")]
    public class Console5
    {
        public void Executar()
        {
            ImprimirDescricaoExercicio();
            throw new NotImplementedException();
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
