using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace NivelEscudeiro.ExerciciosConsole
{
    [Description("Console - Exercício 6")]
    public class Console6
    {
        public void Executar()
        {
            ImprimirDescricaoExercicio();
            throw new NotImplementedException();
        }

        private void ImprimirDescricaoExercicio()
        {
            Console.WriteLine(@"
Console - Exercício 6
Crie uma aplicação, que demonstre a diferença entre REF e OUT.
-----------------------------------------------------------------
");            
        }
    }
}
