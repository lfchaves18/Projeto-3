using System;
using System.Collections.Generic;

namespace Projeto3
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: console clear

            uint opcaoMenu;

            GerenciamentoSistema gerenciamento = new GerenciamentoSistema();

            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n -----Bem vindo----- \n");
                Console.WriteLine("1- Veiculo. \n");
                Console.WriteLine("2- Percurso.\n ");
                Console.WriteLine("3- Viagem.\n\n");
                Console.WriteLine("0- Sair.\n");
                Console.ResetColor();
                while (!uint.TryParse(Console.ReadLine(), out opcaoMenu))
                    Console.WriteLine($"Invalido! Digite novamente a opção desejada: ");


                switch (opcaoMenu)
                {

                    case 1:
                        uint subMenuVeiculo;

                        do
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\n===== VEICULO =====\n");
                            Console.ResetColor();
                            Console.WriteLine("1- Cadastrar. \n");
                            Console.WriteLine("2- Mostrar. \n");
                            Console.WriteLine("3- Calibrar pneu. \n");
                            Console.WriteLine("4- Status pneu. \n");
                            Console.WriteLine("5- Abastecer. \n");
                            Console.WriteLine("6- Visualizar combustivel no tanque. \n");
                            Console.WriteLine("7- Autonomia. \n");
                            Console.WriteLine("0- Sair");
                            while (!uint.TryParse(Console.ReadLine(), out subMenuVeiculo))
                                Console.WriteLine($"Invalido! Digite novamente a opção desejada: ");

                            switch (subMenuVeiculo)
                            {
                                case 1:
                                    ListaVeiculo.Add(gerenciamento.CadastrarVeiculo());

                                    break;

                                case 2:
                                    gerenciamento.MostarVeiculo(ListaVeiculo);

                                    break;

                                case 3:
                                    gerenciamento.CalibrarPneu(ListaVeiculo);
                                    break;

                                case 4:
                                    gerenciamento.MostarStatusPneu(ListaVeiculo);
                                    break;

                                case 5:
                                    gerenciamento.Abastecer(ListaVeiculo);
                                    break;

                                case 6:
                                    gerenciamento.MostrarCombustivel(ListaVeiculo);
                                    break;

                                case 7:
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\n===== Autonomia =====\n");
                                    Console.ResetColor();
                                    break;

                                case 0:
                                    Console.WriteLine("\n Você escolheu sair. \n");
                                    Console.WriteLine("\nPressione ENTER para limpar o console e voltar para o Menu\n");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                default:
                                    Console.WriteLine("\t* OPÇÃO INVALIDA * ");
                                    Console.WriteLine("\nPressione ENTER para limpar o console e voltar para o Menu\n");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                            }


                        } while (subMenuVeiculo != 0);

                        break;

                    case 2:

                        uint subMenuViagem;
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\n===== Percurso =====\n");
                            Console.ResetColor();
                            Console.WriteLine("1- Cadastrar. \n");
                            Console.WriteLine("2- Mostrar. \n\n");
                            Console.WriteLine("0- Sair. \n");
                            while (!uint.TryParse(Console.ReadLine(), out subMenuViagem))
                                Console.WriteLine($"Invalido! Digite novamente a opção desejada: ");

                            switch (subMenuViagem)
                            {
                                case 1:
                                    ListaPercurso.Add(gerenciamento.CadastrarPercurso());
                                    break;

                                case 2:
                                    gerenciamento.MostrarPercursos(ListaPercurso);
                                    break;

                                case 0:
                                    Console.WriteLine("\n Você escolheu sair. \n");
                                    Console.WriteLine("\nPressione ENTER para limpar o console e voltar para o Menu\n");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                default:
                                    Console.WriteLine("\t* OPÇÃO INVALIDA * ");
                                    Console.WriteLine("\nPressione ENTER para limpar o console e voltar para o Menu\n");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                            }

                        } while (subMenuViagem != 0);
                        break;

                    case 3:

                        uint subMenuRelatorio;
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\n===== VIAGEM =====\n");
                            Console.ResetColor();
                            Console.WriteLine("1- Gerar relatorio da viagem. \n");
                            Console.WriteLine("2- Mostrar viagens. \n");
                            Console.WriteLine("3- Viajar. \n\n");
                            Console.WriteLine("0- Sair. \n");
                            while (!uint.TryParse(Console.ReadLine(), out subMenuRelatorio))
                                Console.WriteLine($"Invalido! Digite novamente a opção desejada: ");

                            switch (subMenuRelatorio)
                            {
                                case 1:
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\n===== Gerar relatorio =====\n");
                                    Console.ResetColor();

                                    break;

                                case 2:
                                    gerenciamento.MostrarViagem(ListaViagem);

                                    //relatorio.VerViagens(ListaViagem);

                                    break;

                                case 3:
                                    ListaViagem.Add(gerenciamento.GerarViagem(ListaVeiculo, ListaPercurso));
                                    break;

                                case 0:
                                    Console.WriteLine("\n Você escolheu sair. \n");
                                    Console.WriteLine("\nPressione ENTER para limpar o console e voltar para o Menu\n");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                default:
                                    Console.WriteLine("\t* OPÇÃO INVALIDA * ");
                                    Console.WriteLine("\nPressione ENTER para limpar o console e voltar para o Menu\n");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                            }

                        } while (subMenuRelatorio != 0);
                        break;

                    case 0:
                        Console.WriteLine("\n Você escolheu sair. \n");
                        Console.WriteLine("\nPressione ENTER para limpar o console e voltar para o Menu\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("\t* OPÇÃO INVALIDA * ");
                        Console.WriteLine("\nPressione ENTER para limpar o console e voltar para o Menu\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                }

            } while (opcaoMenu != 0);
        }
    }
}
