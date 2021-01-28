using NivelEscudeiro.ExerciciosConsole;
using NivelEscudeiro.POO;
using System;
using System.Collections.Generic;

namespace NivelEscudeiro
{   
    class Program
    {
        static void Main(string[] args)
        {           
            IExecutar exercicio = new ExecutarTodos();
            exercicio.Executar();
        }
    }
}
