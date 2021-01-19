using System;
using System.Collections.Generic;
using System.Text;

namespace NivelEscudeiro.ExerciciosConsole
{
    public class Console3: IExecutar
    {
        public void Executar()
        {
            Console.WriteLine("Console - Exercício 3");
            Console.WriteLine();
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
    }
}
