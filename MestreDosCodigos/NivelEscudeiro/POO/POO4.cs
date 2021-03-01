using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NivelEscudeiro.POO
{
    //adicionar limite de volume
    //troca de canal quando não houver.. está mostrando o canal maior mas não está trocando
    [Description("POO - Exercício 4")]
    public class POO4 : IExecutar
    {
        private ControleRemoto Controle { get; set; } = new ControleRemoto(new Televisao());
        public void Executar()
        {
            ImprimirDescricaoExercicio();            
            
            Controle.Imprimir();
            int opcao = 1;

            while (opcao != (int)OpcoesPOO4Enum.Desligar)
            {
                opcao = ExibirMenu();
                Console.Clear();
                ImprimirDescricaoExercicio();
                ExecutarAcao(opcao);
            }
        }

        private void ImprimirDescricaoExercicio()
        {
            Console.WriteLine(@"
POO - Exercício 4
Crie uma classe Televisao e uma classe ControleRemoto que pode controlar o volume e trocar os canais da televisão. O controle permite:

-Aumentar ou diminuir a potência do volume de som em uma unidade de cada vez.
-Aumentar e diminuir o número do canal em uma unidade.
-Trocar para um canal indicado.
-Consultar o valor do volume de som e o canal selecionado.
-Imprima os dados via console.
------------------------------------------------------------------------------------------------------------------------------------------
");
        }

        private int ExibirMenu()
        {
            int opcao = 0;
            Console.WriteLine();            
            Console.WriteLine();
            Console.WriteLine("-----------MENU Controle--------------");
            Console.WriteLine("[1]- Aumentar canal");
            Console.WriteLine("[2]- Diminuir canal");
            Console.WriteLine("[3]- Aumentar volume");
            Console.WriteLine("[4]- Diminuir volume");
            Console.WriteLine("[5]- Status da TV");
            Console.WriteLine("[6]- Ir para canal");
            Console.WriteLine("[7]- Desligar");
            Console.WriteLine("-----------------------------");

            while (opcao < 1 || opcao > 7)
            {
                Console.Write("Opção: ");
                Int32.TryParse(Console.ReadLine(), out opcao);
            }

            return opcao;
        }

        private void ExecutarAcao(int opcao)
        {
            switch ((OpcoesPOO4Enum)opcao)
            {
                case OpcoesPOO4Enum.AumentarCanal:
                    Controle.AumentarCanal();
                    break;
                case OpcoesPOO4Enum.DiminuirCanal:
                    Controle.DiminuirCanal();
                    break;
                case OpcoesPOO4Enum.AumentarVolume:
                    Controle.AumentarVolume();
                    break;
                case OpcoesPOO4Enum.DiminuirVolume:
                    Controle.DiminuirVolume();
                    break;
                case OpcoesPOO4Enum.StatusTV:
                    Console.WriteLine("Status da TV ");
                    Controle.Imprimir();
                    break;
                case OpcoesPOO4Enum.IrParaCanal:
                    int canal = -1;
                    Console.Write("Informe o canal desejado de 0 a 6: ");
                    while (canal == -1)
                    {
                        Int32.TryParse(Console.ReadLine(), out canal);
                    }
                    Controle.IrParaOCanal(canal);
                    break;
                case OpcoesPOO4Enum.Desligar:
                    Console.WriteLine("TV desligada.");
                    break;

            }
        }
    }

    internal enum OpcoesPOO4Enum : int
    {
        AumentarCanal = 1,
        DiminuirCanal = 2,
        AumentarVolume = 3,
        DiminuirVolume = 4,
        StatusTV = 5,
        IrParaCanal = 6,
        Desligar = 7
    }

    internal interface ITelevisor
    {
        string ObterCanalAtual();
        int ObterVolumeAtual();
        bool AumentarVolume();
        bool DiminuirVolume();
        void AumentarCanal();
        void DiminuirCanal();
        bool IrParaOCanal(int canal);
        void Imprimir();
    }

    internal class Televisao : ITelevisor
    {
        private string[] ListaDeCanais = new string[]
        {
            "Canal 0",
            "Canal 1",
            "Canal 2",
            "Canal 3",
            "Canal 4",
            "Canal 5",
            "Canal 6"
        };
        private int CanalAtual { get; set; } = 3;
        private int Volume { get; set; } = 10;

        public string ObterCanalAtual()
        {
            return ListaDeCanais[CanalAtual];
        }

        public int ObterVolumeAtual()
        {
            return Volume;
        }

        public bool AumentarVolume()
        {
            if (Volume < 100)
            {
                Volume++;
                return true;
            }
            return false;
        }

        public bool DiminuirVolume()
        {
            if(Volume>0)
            {
                Volume--;
                return true;
            }
            return false;
        }

        public void AumentarCanal()
        {
            if ((CanalAtual + 1) > (ListaDeCanais.Length - 1)) CanalAtual = 0;
            else CanalAtual++;
        }

        public void DiminuirCanal()
        {
            if (CanalAtual == 0) CanalAtual = ListaDeCanais.Length - 1;
            else CanalAtual--;
        }

        public bool IrParaOCanal(int canal)
        {
            if (canal >= 0 && canal <= (ListaDeCanais.Length - 1))
            {
                CanalAtual = canal;
                return true;
            }
            return false;
        }

        public void Imprimir()
        {
            Console.WriteLine("-----------TELEVISOR---------------");
            Console.WriteLine($"Canal: {ObterCanalAtual()}");
            Console.WriteLine($"Volume: {ObterVolumeAtual()}");
            Console.WriteLine("-----------------------------------");
        }

    }

    internal class ControleRemoto
    {
        private ITelevisor TV { get; set; }
        public ControleRemoto(ITelevisor tv)
        {
            TV = tv;
        }

        public void AumentarVolume()
        {
            if (TV.AumentarVolume()) Console.WriteLine("Volume aumentado.");
            else Console.WriteLine("Volume no máximo.");            
            Imprimir();
        }

        public void DiminuirVolume()
        {            
            if(TV.DiminuirVolume()) Console.WriteLine("Volume diminuído."); 
            else Console.WriteLine("Volume no mínimo.");
            Imprimir();
        }

        public void AumentarCanal()
        {
            Console.WriteLine("Canal aumentado.");
            TV.AumentarCanal();
            Imprimir();
        }

        public void DiminuirCanal()
        {
            Console.WriteLine("Canal diminuido.");
            TV.DiminuirCanal();
            Imprimir();
        }

        public void IrParaOCanal(int canal)
        {
            if (TV.IrParaOCanal(canal)) Console.WriteLine($"Canal alterado para: {canal}.");
            else Console.WriteLine($"Canal não disponível!");

            Imprimir();
        }

        public void Imprimir()
        {
            TV.Imprimir();
        }
    }

}
