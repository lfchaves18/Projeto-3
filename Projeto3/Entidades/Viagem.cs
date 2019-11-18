using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto3
{
    class Viagem
    {
        public int IdViagem { get; set; } = new Random().Next(1, 9999);
        public Veiculo VeiculoViagem { get; set; }
        public Percurso PercursoViagem { get; set; }
        public string StatusViagem { get; set; }
 


        //TODO: falta a viagem ser interrompida
     /*   public void GerarViagem(List<Veiculo> veiculos, List<Percurso> percursos)
        {
            //escolher o percurso para a viagem
            gerenciamento.MostrarPercursos(percursos);
            Console.WriteLine("Escolha um percurso? \n Insira o numero: ");
            uint opcaoPercurso;
            while (!uint.TryParse(Console.ReadLine(), out opcaoPercurso))
                Console.WriteLine($"Invalido! Escolha um percurso? \n Insira o numero: ");

            //escolher o veiculo para a viagem
            gerenciamento.MostarVeiculo(veiculos, false);
            Console.WriteLine("Escolha um veiculo? \n Insira o numero: ");
            uint opcaoAluno;
            while (!uint.TryParse(Console.ReadLine(), out opcaoAluno))
                Console.WriteLine("Invalido! Escolha um veiculo? \n Insira o numero: ");


             veiculo = veiculos.Find(buscaVeiculo => buscaVeiculo.IdVeiculo == opcaoAluno);
             percurso = percursos.Find(buscaPercurso => buscaPercurso.IdViagem == opcaoPercurso);


            double distancia = percurso.KM;
            double kmPercorrido;
            double kmLitroAlcool = veiculo.KmLitroAlcool;
            double kmLitroGas = veiculo.KmLitroGas;

            //calculos de desconto de autonomia
            if (percurso.Clima == 1) // neve
            {
                kmLitroGas -= (veiculo.KmLitroGas * 0.190);
                kmLitroAlcool -= (kmLitroGas * 0.300);

            }
            else if (percurso.Clima == 2) // chuva
            {
                kmLitroGas -= (veiculo.KmLitroGas * 0.120);
                kmLitroAlcool -= (kmLitroGas * 0.300);
            }

            if (veiculo.StatusPneu == 1) //pneu muito
            {
                kmLitroAlcool -= (kmLitroAlcool * 0.0915);
                kmLitroGas -= (kmLitroGas * 0.0915);

            }
            else if (veiculo.StatusPneu == 2) // pneu ruim
            {
                kmLitroAlcool -= (kmLitroAlcool * 0.0725);
                kmLitroGas -= (kmLitroGas * 0.0725);
            }


            // se o veiculo for flex
            if (veiculo.Flex == true)
            {
                // verifica se a autonomia é suficiente para percorrer a viagem. se não for
                if (distancia > (veiculo.QuantidadeAtualAlcool * veiculo.KmLitroAlcool + veiculo.QuantidadeAtualGas * veiculo.KmLitroGas))
                {
                    if (veiculo.QuantidadeAtualAlcool == 0)
                    {
                        kmPercorrido = (distancia / veiculo.KmLitroGas);
                        veiculo.QuantidadeAtualGas -= kmPercorrido;

                    }
                    kmPercorrido = (distancia / veiculo.KmLitroAlcool);
                    veiculo.QuantidadeAtualAlcool -= kmPercorrido;


                    Console.WriteLine($"Você percorreu {kmPercorrido:F2} km.");

                    if (veiculo.QuantidadeAtualAlcool + veiculo.QuantidadeAtualGas == 0) // se acabar o combustivel
                    {
                        while (distancia > 0)
                        {
                            Console.WriteLine("A quantidade atual de combustivel, não percorre a distancia solicitada. Deseja abastecer o veiculo? (S ou N)");
                            string opcaoAbastecer = Console.ReadLine().ToUpper().Trim();
                            while (opcaoAbastecer != "S" && opcaoAbastecer != "N")
                            {
                                Console.WriteLine("Invalido! Deseja abastecer o veiculo? (S ou N) ");
                                opcaoAbastecer = Console.ReadLine().ToUpper().Trim();
                            }

                            if (opcaoAbastecer == "S") // se quiser abastecer
                                veiculo.Abastecer();


                            else // se não quiser
                            {
                                Console.WriteLine("Você optou por não abastecer");
                                return;
                            }

                            distancia -= kmPercorrido;

                            if (veiculo.QuantidadeAtualAlcool == 0) veiculo.QuantidadeAtualAlcool -= kmPercorrido / veiculo.KmLitroAlcool;
                            else veiculo.QuantidadeAtualGas -= kmPercorrido / veiculo.KmLitroGas;
                        }
                    }
                }
                //se a quantidade de combustivel for suficiente
                else
                {
                    if (veiculo.QuantidadeAtualAlcool == 0)
                    {
                        kmPercorrido = (distancia / veiculo.KmLitroGas);
                        veiculo.QuantidadeAtualGas -= kmPercorrido;
                    }
                    kmPercorrido = (distancia / veiculo.KmLitroAlcool);
                    veiculo.QuantidadeAtualAlcool -= kmPercorrido;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nVocê concluiu o percurso total\n");
                Console.ResetColor();

            }
            else // se o veiculo não for flex
            {
                if (veiculo.TipoCombustivel == "A") // se o veiculo for a alcool
                {
                    while (distancia > 0)
                    {
                        if (veiculo.KmLitroAlcool * veiculo.QuantidadeAtualAlcool < distancia)
                        {

                            double quantidadePercorridaKM = veiculo.QuantidadeAtualAlcool * kmLitroAlcool;
                            double quantidadePercorridaLitros = quantidadePercorridaKM / kmLitroAlcool;
                            veiculo.QuantidadeAtualAlcool -= quantidadePercorridaLitros;
                            distancia -= quantidadePercorridaKM;


                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n Não é possivel percorrer a distancia total.");
                            Console.WriteLine($"\n A distancia percorrida foi de {quantidadePercorridaKM:F2}KM. Ainda restam {distancia:F2}KM \n");
                            Console.ResetColor();
                            Console.WriteLine(" Deseja abastecer? (S ou N) ");
                            string opcaoAbastecer = Console.ReadLine().ToUpper().Trim();
                            while (opcaoAbastecer != "S" && opcaoAbastecer != "N")
                            {
                                Console.WriteLine("Invalido! Deseja abastecer o veiculo? (S ou N) ");
                                opcaoAbastecer = Console.ReadLine().ToUpper().Trim();
                            }

                            if (opcaoAbastecer == "S")
                                veiculo.Abastecer(false);


                            else
                            {
                                Console.WriteLine("Você optou por não abastecer! A corrida foi cancelada");
                                return;
                            }
                        }

                        else // caso tem combustivel suficiente para fazer a corrida
                        {
                            double litrosNecessarios = distancia / kmLitroAlcool;
                            double quantidadePercorridaKM = litrosNecessarios * kmLitroAlcool;
                            distancia -= quantidadePercorridaKM;
                            veiculo.QuantidadeAtualAlcool -= (quantidadePercorridaKM / kmLitroAlcool);
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nVocê concluiu o percurso total\n");
                    Console.ResetColor();
                }

                else //  se o carro for a gasolina
                {
                    while (distancia > 0)
                    {
                        if (veiculo.KmLitroGas * veiculo.QuantidadeAtualGas < distancia)
                        {
                            double quantidadePercorridaKM = veiculo.QuantidadeAtualGas * kmLitroGas;
                            double quantidadePercorridaLitros = quantidadePercorridaKM / kmLitroGas;
                            veiculo.QuantidadeAtualGas -= quantidadePercorridaLitros;
                            distancia -= quantidadePercorridaKM;

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n Não é possivel percorrer a distancia total.");
                            Console.WriteLine($"\n A distancia percorrida foi de {quantidadePercorridaKM:F2}KM. Ainda restam {distancia:F2}KM \n");
                            Console.ResetColor();
                            Console.WriteLine(" Deseja abastecer? (S ou N) ");
                            string opcaoAbastecer = Console.ReadLine().ToUpper().Trim();
                            while (opcaoAbastecer != "S" && opcaoAbastecer != "N")
                            {
                                Console.WriteLine("Invalido! Deseja abastecer o veiculo? (S ou N) ");
                                opcaoAbastecer = Console.ReadLine().ToUpper().Trim();
                            }

                            if (opcaoAbastecer == "S")
                                veiculo.Abastecer(false);

                            else
                            {
                                Console.WriteLine("Você optou por não abastecer! A corrida foi cancelada");
                                return;
                            }
                        }

                        else // caso tem combustivel suficiente para fazer a corrida
                        {
                            double litrosNecessarios = distancia / kmLitroGas;
                            double quantidadePercorridaKM = litrosNecessarios * kmLitroGas;
                            distancia -= quantidadePercorridaKM;
                            veiculo.QuantidadeAtualGas -= (quantidadePercorridaKM / kmLitroGas);

                            Console.WriteLine($"\nDistancia percorrida com sucesso! \n");
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nVocê concluiu o percurso total\n");
                    Console.ResetColor();
                }
            }
        }*/
    }
}
