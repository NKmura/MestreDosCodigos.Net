using NivelEscudeiro.ExerciciosConsole;
using NivelEscudeiro.POO;

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
