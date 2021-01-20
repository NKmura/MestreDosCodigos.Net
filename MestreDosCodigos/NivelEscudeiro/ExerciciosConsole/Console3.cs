using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NivelEscudeiro.ExerciciosConsole
{
    [Description("Console - Exercício 3")]
    public class Console3: IExecutar
    {
        public void Executar()
        {
            ImprimirDescricaoExercicio();
                        
            int fator = 1;
            int multiplicador = 3;
            int resultado = fator * multiplicador;
            
            while (resultado<=100)
            {
                Console.WriteLine(resultado);
                fator += 1;
                resultado = fator * multiplicador;
            }
        }

        private void ImprimirDescricaoExercicio()
        {
            Console.WriteLine(@"
Console - Exercício 3

Faça uma aplicação que imprima todos os múltiplos de 3, entre 1 e 100. Utilize a repetição while.
-------------------------------------------------------------------------------------------------
");            
        }
    }
}
