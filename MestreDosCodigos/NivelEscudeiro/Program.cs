using NivelEscudeiro.ExerciciosConsole;
using NivelEscudeiro.POO;
using System;

namespace NivelEscudeiro
{
    //O arquivo 1-Instrucoes.txt possui uma série de informações para auxiliar a execução dos exercícios.
    class Program
    {
        static void Main(string[] args)
        {
            IExecutar exercicio = new POO2();
            exercicio.Executar();
        }
    }
}
