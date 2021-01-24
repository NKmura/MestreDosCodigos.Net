using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace NivelEscudeiro.ExerciciosConsole
{
    [Description("Console - Exercício 6")]
    public class Console6: IExecutar
    {
        public void Executar()
        {
            ImprimirDescricaoExercicio();

            int parametroRef = 0; // variável precisa ser inicializada
            int parametroOut;     // inicialização opcional

            Console.WriteLine($"Variável Ref antes da chamada: {parametroRef}");
            Console.WriteLine($"Variável Out antes da chamada: Não inicializada");

            MetodoParametroRef(ref parametroRef);
            MetodoParametrouOut(out parametroOut);


            Console.WriteLine($"Variável Ref após chamada: {parametroRef}");
            Console.WriteLine($"Variável Out após chamada: {parametroOut}");
            
        }

        public void MetodoParametroRef(ref int variavel)
        {
            Console.WriteLine(@"
-A palavra chave ref faz com que um argumento seja passado como referencia, isso significa que quando o argumento sofre 
atribuição dentro do método ela se refletirá no método de chamada. 
Um argumento REF deverá obrigatóriamente ser inicializado no método de chamada antes de ser passado no método chamado.
");
            variavel = 10;
        }

        public void MetodoParametrouOut(out int variavel)
        {
            Console.WriteLine(@"
-A palavra-chave out faz com que uma variavel seja passada por referencia (ref) porém diferente de ref a variavel não 
precisa ser iniciada antesde ser passada, outra diferença é que um parametro out precisa obrigatóriamente receber alguma 
atribuição dentro do método antes do mesmo ser retornado.
");
            variavel = 20;
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
