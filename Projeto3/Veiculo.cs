using System;

namespace Projeto3
{
    class Veiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public uint Ano { get; set; }
        public double VelocidadeMaxima { get; set; }
        public double CapacidadeTanque { get; set; }
        public bool Flex { get; set; }
        public string TipoCombustivel { get; set; }
        public double KmLitroGas { get; set; }
        public double KmLitroAlcool { get; set; }
        public double QuantidadeAtualGas { get; set; }
        public double QuantidadeAtualAlcool { get; set; }
        public string StatusPneu { get; set; }

        public void Abastecer(bool calibrar = true)
        {

            if (Flex == true) // se for flex
            {
                Console.WriteLine("Qual combustivel você quer abastecer?  \n A- Alcool  G- Gasolina"); //pergunta o tipo de combustivel que deseja
                string opcaoAbastecer = Console.ReadLine().ToUpper();
                while (opcaoAbastecer != "A" && opcaoAbastecer != "G") // validação
                {
                    Console.WriteLine("\nInvalido! Qual é o tipo do combuistivel: \n A- Alcool  G- Gasolina");
                    opcaoAbastecer = Console.ReadLine().ToUpper();
                }

                //----------------------------------------------------------------------------------------------------------------------

                if (opcaoAbastecer == "A") // se quiser abastecer alcool
                {
                    Console.WriteLine("Deseja completar o tanque? (S ou N)"); //opcao de completar
                    string opcaoCompletar = Console.ReadLine().Trim().ToUpper();

                    while (opcaoCompletar != "S" && opcaoCompletar != "N")//validacao completar
                    {
                        Console.WriteLine("Invalido! Deseja completar o tanque do veiculo? (S ou N) ");
                        opcaoCompletar = Console.ReadLine().ToUpper().Trim();
                    }

                    if (opcaoCompletar == "S")// se quiser completar
                    {
                        double completar = CapacidadeTanque - (QuantidadeAtualAlcool + QuantidadeAtualGas);
                        QuantidadeAtualAlcool += completar;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n Veiculo abastecido com sucesso\n");
                        Console.ResetColor();
                    }
                    else // se não quiser completar
                    {
                        double aux;
                        Console.WriteLine("Quantos litros de alcool você quer abastecer? ");
                        while ((!double.TryParse(Console.ReadLine(), out aux) || aux <= 0)) Console.WriteLine("Invalido! Quantos litros de alcool você quer abastecer: ");

                        if (CapacidadeTanque >= aux + (QuantidadeAtualAlcool + QuantidadeAtualGas))
                        {
                            QuantidadeAtualAlcool += aux;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n Veiculo abastecido com sucesso\n");
                            Console.ResetColor();
                        }
                        else Console.WriteLine("\n A quantidade que você quer colocar ultrapassa o limite! \n");
                    }
                }

                //----------------------------------------------------------------------------------------------------------------------

                else // se quiser abastecer gasolina
                {
                    Console.WriteLine("Deseja completar o tanque? (S ou N)");
                    string opcaoCompletar = Console.ReadLine().Trim().ToUpper();
                    while (opcaoCompletar != "S" && opcaoCompletar != "N")
                    {
                        Console.WriteLine("Invalido! Deseja completar o tanque do veiculo? (S ou N) ");
                        opcaoCompletar = Console.ReadLine().ToUpper().Trim();
                    }
                    if (opcaoCompletar == "S")
                    {
                        double completar = CapacidadeTanque - (QuantidadeAtualGas + QuantidadeAtualAlcool);
                        QuantidadeAtualGas += completar;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n Veiculo abastecido com sucesso\n");
                        Console.ResetColor();

                    }
                    else
                    {

                        double aux;
                        Console.WriteLine("Quantos litros de gasolina você quer abastecer? ");
                        while ((!double.TryParse(Console.ReadLine(), out aux) || aux <= 0)) Console.WriteLine("Invalido! Quantos litros de gasolina você quer abastecer: ");

                        if (CapacidadeTanque >= aux + (QuantidadeAtualGas + QuantidadeAtualAlcool))
                        {
                            QuantidadeAtualGas += aux;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n Veiculo abastecido com sucesso\n");
                            Console.ResetColor();
                        }
                        else Console.WriteLine("\n A quantidade que você quer colocar ultrapassa o limite! \n");
                    }
                }
            }

            //----------------------------------------------------------------------------------------------------------------------

            else // se não for flex
            {
                if (TipoCombustivel == "A") // se o carro for alcool
                {
                    Console.WriteLine("Deseja completar o tanque? (S ou N)"); //opcao de completar
                    string opcaoCompletar = Console.ReadLine().Trim().ToUpper();

                    while (opcaoCompletar != "S" && opcaoCompletar != "N")//validacao completar
                    {
                        Console.WriteLine("Invalido! Deseja completar o tanque do veiculo? (S ou N) ");
                        opcaoCompletar = Console.ReadLine().ToUpper().Trim();
                    }
                    if (opcaoCompletar == "S")// se quiser completar
                    {
                        double completar = CapacidadeTanque - QuantidadeAtualAlcool;
                        QuantidadeAtualAlcool += completar;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n Veiculo abastecido com sucesso\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        double aux;
                        Console.WriteLine("Quantos litros de alcool você quer abastecer? ");
                        while ((!double.TryParse(Console.ReadLine(), out aux) || aux <= 0)) Console.WriteLine("Invalido! Quantos litros de alcool você quer abastecer: ");

                        if (CapacidadeTanque >= aux + QuantidadeAtualAlcool)
                        {
                            QuantidadeAtualAlcool += aux;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n Veiculo abastecido com sucesso\n");
                            Console.ResetColor();
                        }
                        else Console.WriteLine("\n A quantidade que você quer colocar ultrapassa o limite! \n");
                    }
                }

                //----------------------------------------------------------------------------------------------------------------------

                else
                {
                    Console.WriteLine("Deseja completar o tanque? (S ou N)");
                    string opcaoCompletar = Console.ReadLine().Trim().ToUpper();
                    while (opcaoCompletar != "S" && opcaoCompletar != "N")
                    {
                        Console.WriteLine("Invalido! Deseja completar o tanque o veiculo? (S ou N) ");
                        opcaoCompletar = Console.ReadLine().ToUpper().Trim();
                    }
                    if (opcaoCompletar == "S")
                    {
                        double completar = CapacidadeTanque - QuantidadeAtualGas;
                        QuantidadeAtualGas += completar;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n Veiculo abastecido com sucesso\n");
                        Console.ResetColor();

                    }
                    else
                    {

                        double aux;
                        Console.WriteLine("Quantos litros de gasolina você quer abastecer? ");
                        while ((!double.TryParse(Console.ReadLine(), out aux) || aux <= 0)) Console.WriteLine("Invalido! Quantos litros de gasolina você quer abastecer: ");

                        if (CapacidadeTanque >= aux + QuantidadeAtualGas)
                        {
                            QuantidadeAtualGas += aux;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n Veiculo abastecido com sucesso\n");
                            Console.ResetColor();
                        }
                        else Console.WriteLine("\n A quantidade que você quer colocar ultrapassa o limite! \n");
                    }

                }
            }
            if (calibrar)
            {
                Console.WriteLine("Deseja calibrar o pneu? (S ou N)"); //opcao de completar
                string opcaoCalibrar = Console.ReadLine().Trim().ToUpper();

                while (opcaoCalibrar != "S" && opcaoCalibrar != "N")//validacao completar
                {
                    Console.WriteLine("Invalido! Deseja completar o tanque do veiculo? (S ou N) ");
                    opcaoCalibrar = Console.ReadLine().ToUpper().Trim();
                }

                if (opcaoCalibrar == "S") CalibrarPneu();
                else Console.WriteLine("\n Você optou por não calibrar! ");
            }
        }

        public void CalibrarPneu()
        {
            Console.WriteLine("\nQual é o status do pneu do veiculo? \n 1- Muito ruim, 2- Ruim, 3- Bom");
            string statusPneu = Console.ReadLine().ToUpper();
            while (statusPneu != "1" && statusPneu != "2" && statusPneu != "3")
            {
                Console.WriteLine("\nInvalido! Qual é o status do pneu do veiculo? \n 1- Muito ruim, 2- Ruim, 3- Bom");
                statusPneu = Console.ReadLine().ToUpper();
            }

            if (statusPneu == "1")
            {
                KmLitroAlcool -= (KmLitroAlcool * 0.0915)  ;
                KmLitroGas -= (KmLitroGas * 0.0915);

            }
            else if (statusPneu == "2")
            {
                KmLitroAlcool -= (KmLitroAlcool * 0.0725) ;
                KmLitroGas -= (KmLitroGas * 0.0725);
            }

        }

        public double Autonomia(double kmLitro, double quantidadeAtualCombustivel)
        {
            double autonomiaTotal = kmLitro * quantidadeAtualCombustivel;
            return autonomiaTotal;
        }

        public void MostarStatusPneu()
        {
            if (StatusPneu == "1") Console.WriteLine("\n O pneu está muito ruim!\n");
            else if (StatusPneu == "2") Console.WriteLine("\n O pneu está ruim!\n");
            else Console.WriteLine("\n O pneu está normal!\n ");
        }
    }
}
