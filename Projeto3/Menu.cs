﻿using System;

namespace Projeto3
{
    class Menu
    {
        public uint Numero { get; set; }

        public void MenuPrincipal()
        {
            Veiculo veiculo = new Veiculo();

            do
            {
                uint numero;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n -----VEICULO----- \n");
                Console.WriteLine("1- Cadastrar veiculo. \n");
                Console.WriteLine("2- Dirigir. \n");
                Console.WriteLine("3- Abastecer. \n");
                Console.WriteLine("4- Visualizar combustivel no tanque. \n");
                Console.WriteLine("5- Visualizar autonomia. \n");
                Console.WriteLine("6- Visualizar dados do veiculo. \n");
                Console.WriteLine("0- Sair.\n");
                Console.ResetColor();
                while (!uint.TryParse(Console.ReadLine(), out numero))
                    Console.WriteLine($"Invalido! Digite novamente a opção desejada: ");
                Numero = numero;

                switch (Numero)
                {
                    case 1:
                        veiculo.Marca = "honda";
                        veiculo.Modelo = "civic";
                        veiculo.Placa = "fih-4173";
                        veiculo.Ano = 2014;
                        veiculo.VelocidadeMaxima = 200;
                        veiculo.CapacidadeTanque = 60;
                        veiculo.Flex = "N";
                        veiculo.TipoCombustivel = "A";
                       // veiculo.KmLitroGas = 7.5;
                        veiculo.KmLitroAlcool = 5;
                        //veiculo.QuantidadeAtualGas = 30;
                        veiculo.QuantidadeAtualAlcool = 10;
                        // veiculo.Cadastrar();

                        Console.WriteLine("\nPressione ENTER para limpar o console e voltar para o Menu\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 2:
                        //verifica se existem veiculos, se não existir aparecer a mensagem
                        if (veiculo.Marca == null) Console.WriteLine("Não existem veiculos cadastrados!");
                        else veiculo.Dirigir(); // se existir, poderá dirigir

                        Console.WriteLine("\nPressione ENTER para limpar o console e voltar para o Menu\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 3:
                        //verifica se existe veiculo, se não existir aparece a mensagem.
                        if (veiculo.Marca == null) Console.WriteLine("Não existem veiculos cadastrados!");

                        //se existir, permite abastecer
                        else
                        { //se o tanque tiver cheio, não permite que abasteça
                            if (veiculo.CapacidadeTanque == veiculo.QuantidadeAtualAlcool + veiculo.QuantidadeAtualGas)
                                Console.WriteLine("O tanque do veiculo está cheio!");
                            else veiculo.Abastecer(); // se tiver possibilidade de abastecer, é liberado o abastecimento

                        }

                        Console.WriteLine("\nPressione ENTER para limpar o console e voltar para o Menu\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 4:
                        double combustivelTotal = veiculo.QuantidadeAtualAlcool + veiculo.QuantidadeAtualGas;
                        Console.WriteLine($"\nA quantidade atual de combustivel é: {combustivelTotal:F1} litros");

                        Console.WriteLine("\nPressione ENTER para limpar o console e voltar para o Menu\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 5:
                        if (veiculo.Marca == null) Console.WriteLine("Não existem veiculos cadastrados!");
                        else
                        {
                            double autonomiaAlcool = veiculo.Autonomia(veiculo.KmLitroAlcool , veiculo.QuantidadeAtualAlcool);
                            double autonomiaGasolina = veiculo.Autonomia(veiculo.KmLitroGas, veiculo.QuantidadeAtualGas);

                            Console.WriteLine($"Autonomia total {autonomiaAlcool+autonomiaGasolina}");
                        }
                        Console.WriteLine("\nPressione ENTER para limpar o console e voltar para o Menu\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 6:
                        if (veiculo.Marca == null) Console.WriteLine("Não existem veiculos cadastrados!");
                        else Console.WriteLine(veiculo);

                        Console.WriteLine("\nPressione ENTER para limpar o console e voltar para o Menu\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 0:
                        Console.WriteLine("\n Você escolheu sair. \n");
                        Console.WriteLine("\nPressione ENTER para limpar o console e voltar para o Menu\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("\t* OPÇÃO INVALIDA* ");
                        Console.WriteLine("\nPressione ENTER para limpar o console e voltar para o Menu\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }

            } while (Numero != 0);
        }
    }
}