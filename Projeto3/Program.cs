using System;
namespace Projeto3
{
    class Program
    {
        static void Main(string[] args)
        {
           
            uint opcaoMenu;

            Gerenciamento gerenciamento = new Gerenciamento();
            Veiculo veiculo = new Veiculo();
            Viagem viagem = new Viagem();

            do
            {

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n -----VEICULO----- \n");
                Console.WriteLine("1- Cadastrar veiculo. \n");
                Console.WriteLine("2- Cadastrar viagem.\n ");
                Console.WriteLine("3- Dirigir. \n");
                Console.WriteLine("4. Abastecer. \n");
                Console.WriteLine("5- Visualizar combustivel no tanque. \n");
                Console.WriteLine("6- Visualizar autonomia. \n");
                Console.WriteLine("7- Visualizar dados do veiculo. \n");
                Console.WriteLine("8- Visualizar dados da viagem.\n");
                Console.WriteLine("9- Calibrar pneu.\n");
                Console.WriteLine("10- Visualizar status do pneu.\n \n ");
                Console.WriteLine("0- Sair.\n");
                Console.ResetColor();
                while (!uint.TryParse(Console.ReadLine(), out opcaoMenu))
                    Console.WriteLine($"Invalido! Digite novamente a opção desejada: ");


                switch (opcaoMenu)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("===== VOCÊ ESCOLHEU POR CADASTRAR UM VEICULO =====");
                        Console.ResetColor();
                        veiculo = gerenciamento.CadastrarVeiculo();

                        // veiculo.Cadastrar();

                        Console.WriteLine("\nPressione ENTER para limpar o console e voltar para o Menu\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("===== VOCÊ ESCOLHEU POR CADASTRAR UMA VIAGEM =====");
                        Console.ResetColor();
                        viagem = gerenciamento.CadastrarViagem();

                        Console.WriteLine("\nPressione ENTER para limpar o console e voltar para o Menu\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("===== VOCÊ ESCOLHEU POR DIRIGIR O VEICULO =====");
                        Console.ResetColor();
                        //verifica se existem veiculos, se não existir aparecer a mensagem
                        if (veiculo.Marca == null) Console.WriteLine("Não exiestem veiculos cadastrados!");   
                        else gerenciamento.Dirigir(veiculo, viagem);
                        // veiculo.TipoCombustivel == "A" ? veiculo.Dirigir(veiculo.KmLitroAlcool, veiculo.QuantidadeAtualAlcool) : veiculo.Dirigir(veiculo.KmLitroGas, veiculo.QuantidadeAtualGas);

                        Console.WriteLine("\nPressione ENTER para limpar o console e voltar para o Menu\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("===== VOCÊ ESCOLHEU POR ABASTECER O VEICULO =====");
                        Console.ResetColor();

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

                    case 5:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("===== VOCÊ ESCOLHEU POR VISUALIZAR O COMBUSTIVEL DO VEICULO =====");
                        Console.ResetColor();

                        double combustivelTotal = veiculo.QuantidadeAtualAlcool + veiculo.QuantidadeAtualGas;
                        Console.WriteLine($"\nA quantidade atual de combustivel é: {combustivelTotal:F1} litros");

                        Console.WriteLine("\nPressione ENTER para limpar o console e voltar para o Menu\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 6:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("===== VOCÊ ESCOLHEU POR VISUALIZAR A AUTONOMIA DO VEICULO =====");
                        Console.ResetColor();

                        if (veiculo.Marca == null) Console.WriteLine("Não existem veiculos cadastrados!");
                        else
                        {
                            double autonomiaAlcool = veiculo.Autonomia(veiculo.KmLitroAlcool, veiculo.QuantidadeAtualAlcool);
                            double autonomiaGasolina = veiculo.Autonomia(veiculo.KmLitroGas, veiculo.QuantidadeAtualGas);

                            Console.WriteLine($"Autonomia total: {(autonomiaAlcool + autonomiaGasolina):F2} km");
                        }
                        Console.WriteLine("\nPressione ENTER para limpar o console e voltar para o Menu\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 7:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("===== VOCÊ ESCOLHEU POR MOSTRAR OS DADOS DO VEICULO =====");
                        Console.ResetColor();
                        if (veiculo.Marca == null) Console.WriteLine("Não existem veiculos cadastrados!");
                        else gerenciamento.MostarVeiculo(veiculo);

                        Console.WriteLine("\nPressione ENTER para limpar o console e voltar para o Menu\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 8:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("===== VOCÊ ESCOLHEU POR VISUALIZAR OS DADOS DA VIAGEM =====");
                        Console.ResetColor();

                        if (viagem.KM == 0) Console.WriteLine("Não existem viagens cadastradas");
                        else gerenciamento.MostrarViagem(viagem);
                        Console.WriteLine("\nPressione ENTER para limpar o console e voltar para o Menu\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 9:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("===== VOCÊ ESCOLHEU POR CALIBRAR O PNEU DO VEICULO =====");
                        Console.ResetColor();

                        if (veiculo.Marca == null) Console.WriteLine("Não existem veiculos cadastrados! ");
                        else veiculo.CalibrarPneu();

                        Console.WriteLine("\nPressione ENTER para limpar o console e voltar para o Menu\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 10:
                        if (veiculo.Marca == null) Console.WriteLine("Não existem veiculos cadastrados! ");
                        else veiculo.MostarStatusPneu();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("===== VOCÊ ESCOLHEU POR VER O STATUS NO PNEU =====");
                        Console.ResetColor();



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
