using System;
using System.Collections.Generic;

namespace Projeto3
{
    class GerenciamentoSistema
    {
        public List<Veiculo> ListaVeiculo { get; set; } = new List<Veiculo>();
        public List<Percurso> ListaPercurso { get; set; } = new List<Percurso>();
        public List<Viagem> ListaViagem { get; set; } = new List<Viagem>();

        
        /*---------------------------------------------------VEICULO---------------------------------------------------------------------------*/
        //Cadastra o veiculo
        public Veiculo CadastrarVeiculo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n===== Cadastrar veiculo =====\n");
            Console.ResetColor();

            Console.WriteLine("Informe os dados do veiculo: ");
            Console.WriteLine("\nMarca: ");
            string marca = Console.ReadLine().ToUpper().Trim();
            while ((!ValidarPalavras(marca)) || (marca.Length < 2))
            {
                Console.WriteLine("Invalido! Qual é a marca do veiculo: ");
                marca = Console.ReadLine().Trim().ToUpper();
            }

            Console.WriteLine("\nModelo: ");
            string modelo = Console.ReadLine().ToUpper().Trim();
            while (string.IsNullOrEmpty(modelo) || (modelo.Length < 2))
            {
                Console.WriteLine("Invalido! Qual é o modelo do veiculo: ");
                modelo = Console.ReadLine().Trim().ToUpper();
            }

            Console.WriteLine("\nPlaca: ");
            string placa = Console.ReadLine().ToUpper().Trim();
            while ((string.IsNullOrEmpty(placa)) || (placa.Length != 7))
            {
                Console.WriteLine("Invalido! Qual a placa do veiculo: ");
                placa = Console.ReadLine().ToUpper().Trim();
            }

            uint ano;
            Console.WriteLine("\nAno: ");
            while (!uint.TryParse(Console.ReadLine(), out ano)) Console.WriteLine("Invalido! Qual o ano do veiculo: ");


            double velocidadeAux;
            Console.WriteLine("\nVelocidade máxima: ");
            while (!double.TryParse(Console.ReadLine(), out velocidadeAux)) Console.WriteLine("Invalido! Qual é a velocidade máxima? ");


            double capacidade;
            double kmLitroGas = 0;
            double kmLitroAlcool = 0;
            double quantidadeAtualAlcool = 0;
            double quantidadeAtualGas = 0;
            uint statusPneu = 0;
            string tipoCombustivel = "";
            Console.WriteLine("\nCapacidade do tanque: ");
            while (!double.TryParse(Console.ReadLine(), out capacidade)) Console.WriteLine("Invalido! Qual é a capacidade do tanque: ");


            Console.WriteLine("\nÉ flex? (S ou N) ");
            string respFlex = Console.ReadLine().ToUpper().Trim();
            while (respFlex != "S" && respFlex != "N")
            {
                Console.WriteLine("Invalido! O veiculo é flex? ");
                respFlex = Console.ReadLine().ToUpper().Trim();
            }
            bool flex;
            if (respFlex == "S")
            {
                flex = true;

                Console.WriteLine("\nKm/L na gasolina: ");
                while (!double.TryParse(Console.ReadLine(), out kmLitroGas) || (kmLitroGas <= 0)) Console.WriteLine("Invalido! Quantos km/L na gasolina: ");


                Console.WriteLine("\nKm/L no alcool: ");
                while (!double.TryParse(Console.ReadLine(), out kmLitroAlcool) || (kmLitroAlcool <= 0)) Console.WriteLine("Invalido! Quantos km/L no alcool: ");


                Console.WriteLine("\nQuantidade atual de gasolina: ");
                while (!double.TryParse(Console.ReadLine(), out quantidadeAtualGas) || (quantidadeAtualAlcool + quantidadeAtualGas > capacidade) || (quantidadeAtualGas < 0)) Console.WriteLine("Invalido! Quantidade atual de gasolina:");

                Console.WriteLine("\nQuantidade atual de alcool: \nLembre-se que não pode ultrapassar o limite.");
                while (!double.TryParse(Console.ReadLine(), out quantidadeAtualAlcool) || (quantidadeAtualAlcool + quantidadeAtualGas > capacidade) || (quantidadeAtualAlcool < 0)) Console.WriteLine("Invalido! Quantidade atual de alcool: ");

            }

            else
            {
                flex = false;

                Console.WriteLine("\nQual é o tipo do combuistivel: \n A- Alcool  G- Gasolina");
                tipoCombustivel = Console.ReadLine().ToUpper();
                while (tipoCombustivel != "A" && tipoCombustivel != "G")
                {
                    Console.WriteLine("\nInvalido! Qual é o tipo do combuistivel: \n A- Alcool  G- Gasolina");
                    tipoCombustivel = Console.ReadLine().ToUpper();
                }

                if (tipoCombustivel == "G")
                {

                    Console.WriteLine("\nKm/L na gasolina: ");
                    while (!double.TryParse(Console.ReadLine(), out kmLitroGas) || (kmLitroGas <= 0)) Console.WriteLine("Invalido! Quantos km/L na gasolina: ");


                    Console.WriteLine("\nQuantidade atual de gasolina: ");
                    while (!double.TryParse(Console.ReadLine(), out quantidadeAtualGas) || (quantidadeAtualGas >= capacidade) || (quantidadeAtualGas < 0)) Console.WriteLine("Invalido! Quantidade atual de gasolina:");

                }
                else
                {
                    Console.WriteLine("\nKm/L no alcool: ");
                    while (!double.TryParse(Console.ReadLine(), out kmLitroAlcool) || (kmLitroAlcool <= 0)) Console.WriteLine("Invalido! Quantos km/L no alcool: ");


                    Console.WriteLine("\nQuantidade atual de alcool: ");
                    while (!double.TryParse(Console.ReadLine(), out quantidadeAtualAlcool) || (quantidadeAtualAlcool >= capacidade) || (quantidadeAtualAlcool < 0)) Console.WriteLine("Invalido! Quantidade atual de alcool: ");


                }

                Console.WriteLine("\nQual é o status do pneu do veiculo? \n 1- Muito ruim, 2- Ruim, 3- Bom");
                while ((!uint.TryParse(Console.ReadLine(), out statusPneu) || statusPneu <= 0 || statusPneu >= 4)) Console.WriteLine("Invalido!Como está o clima dessa viagem?\n 1- Chovendo  2- Nevando  3- Ensolarado");

            }
            return new Veiculo
            {
                Marca = marca,
                Modelo = modelo,
                Placa = placa,
                Ano = ano,
                VelocidadeMaxima = velocidadeAux,
                CapacidadeTanque = capacidade,
                TipoCombustivel = tipoCombustivel,
                Flex = flex,
                KmLitroGas = kmLitroGas,
                KmLitroAlcool = kmLitroAlcool,
                QuantidadeAtualAlcool = quantidadeAtualAlcool,
                QuantidadeAtualGas = quantidadeAtualGas,
                StatusPneu = statusPneu,
            };

            /*
           return new Veiculo
           {
               Marca = "honda",
               Modelo = "civic",
               // Placa = placa,
               Ano = 2015,
               //  VelocidadeMaxima = velocidadeAux,
               CapacidadeTanque = 60,
               TipoCombustivel = "A",
               // Flex = true,
               // KmLitroGas = 11.7,
               KmLitroAlcool = 8.5,
               QuantidadeAtualAlcool = 20,
               // QuantidadeAtualGas = 15,
               // StatusPneu = statusPneu
           };*/
        }

        //Mostrar um veiculo, recebendo um veiculo como parametro
        public void MostarVeiculo(List<Veiculo> veiculos, bool mostarTudo = true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n===== Mostrar veiculos =====\n");
            Console.ResetColor();

            if (veiculos.Count == 0) Console.WriteLine("Não existem carros cadastrados");
            veiculos.ForEach(veiculo =>
            {
                if (mostarTudo)
                {
                    Console.WriteLine($"\nNumero do veiculo: {veiculo.IdVeiculo} \nMarca: {veiculo.Marca} \nModelo: {veiculo.Modelo} \nPlaca: {veiculo.Placa} \nAno: {veiculo.Ano}" +
                        $" \nVelocidade Máxima: {veiculo.VelocidadeMaxima} \nCapacidade do tanque: {veiculo.CapacidadeTanque} \nFlex: {veiculo.Flex}" +
                        $" \nTipo de combustivel: {veiculo.TipoCombustivel} \nKm/L gasolina: {veiculo.KmLitroGas} \nKm/L alcool: {veiculo.KmLitroAlcool} " +
                        $"\nQuantidade atual de gasolina: {veiculo.QuantidadeAtualGas} \nQuantidade atual de alcool: {veiculo.QuantidadeAtualAlcool}");
                }
                else
                    if (veiculo.Flex == true) Console.WriteLine($"\nNúmero do veiculo: {veiculo.IdVeiculo} - Marca: {veiculo.Marca} - Modelo: {veiculo.Modelo} -" +
                        $" Ano: {veiculo.Ano} Flex: S\n");
                else Console.WriteLine($"\nNúmero do veiculo: {veiculo.IdVeiculo} - Marca: {veiculo.Marca} - Modelo: {veiculo.Modelo} -" +
                    $" Ano: {veiculo.Ano} - Tipo Combustivel: {veiculo.TipoCombustivel}\n");
            });
        }

        public void Abastecer(List<Veiculo> veiculos, bool calibrar = true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n===== Abastecer =====\n");
            Console.ResetColor();

            MostarVeiculo(veiculos, false);
            Console.WriteLine("Escolha um veiculo? \n Insira o numero: ");
            uint opcaoVeiculo;
            while (!uint.TryParse(Console.ReadLine(), out opcaoVeiculo))
                Console.WriteLine("Invalido! Escolha um veiculo? \n Insira o numero: ");

            Veiculo veiculo = veiculos.Find(buscaVeiculo => buscaVeiculo.IdVeiculo == opcaoVeiculo);

            if (veiculo.Flex == true) // se for flex
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
                        double completar = veiculo.CapacidadeTanque - (veiculo.QuantidadeAtualAlcool + veiculo.QuantidadeAtualGas);
                        veiculo.QuantidadeAtualAlcool += completar;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n Veiculo abastecido com sucesso\n");
                        Console.ResetColor();
                    }
                    else // se não quiser completar
                    {
                        double aux;
                        Console.WriteLine("Quantos litros de alcool você quer abastecer? ");
                        while ((!double.TryParse(Console.ReadLine(), out aux) || aux <= 0)) Console.WriteLine("Invalido! Quantos litros de alcool você quer abastecer: ");

                        if (veiculo.CapacidadeTanque >= aux + (veiculo.QuantidadeAtualAlcool + veiculo.QuantidadeAtualGas))
                        {
                            veiculo.QuantidadeAtualAlcool += aux;
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
                        double completar = veiculo.CapacidadeTanque - (veiculo.QuantidadeAtualGas + veiculo.QuantidadeAtualAlcool);
                        veiculo.QuantidadeAtualGas += completar;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n Veiculo abastecido com sucesso\n");
                        Console.ResetColor();

                    }
                    else
                    {

                        double aux;
                        Console.WriteLine("Quantos litros de gasolina você quer abastecer? ");
                        while ((!double.TryParse(Console.ReadLine(), out aux) || aux <= 0)) Console.WriteLine("Invalido! Quantos litros de gasolina você quer abastecer: ");

                        if (veiculo.CapacidadeTanque >= aux + (veiculo.QuantidadeAtualGas + veiculo.QuantidadeAtualAlcool))
                        {
                            veiculo.QuantidadeAtualGas += aux;
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
                if (veiculo.TipoCombustivel == "A") // se o carro for alcool
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
                        double completar = veiculo.CapacidadeTanque - veiculo.QuantidadeAtualAlcool;
                        veiculo.QuantidadeAtualAlcool += completar;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n Veiculo abastecido com sucesso\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        double aux;
                        Console.WriteLine("Quantos litros de alcool você quer abastecer? ");
                        while ((!double.TryParse(Console.ReadLine(), out aux) || aux <= 0)) Console.WriteLine("Invalido! Quantos litros de alcool você quer abastecer: ");

                        if (veiculo.CapacidadeTanque >= aux + veiculo.QuantidadeAtualAlcool)
                        {
                            veiculo.QuantidadeAtualAlcool += aux;
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
                        double completar = veiculo.CapacidadeTanque - veiculo.QuantidadeAtualGas;
                        veiculo.QuantidadeAtualGas += completar;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n Veiculo abastecido com sucesso\n");
                        Console.ResetColor();

                    }
                    else
                    {

                        double aux;
                        Console.WriteLine("Quantos litros de gasolina você quer abastecer? ");
                        while ((!double.TryParse(Console.ReadLine(), out aux) || aux <= 0)) Console.WriteLine("Invalido! Quantos litros de gasolina você quer abastecer: ");

                        if (veiculo.CapacidadeTanque >= aux + veiculo.QuantidadeAtualGas)
                        {
                            veiculo.QuantidadeAtualGas += aux;
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

                if (opcaoCalibrar == "S") CalibrarPneu(veiculos);
                else Console.WriteLine("\n Você optou por não calibrar! ");
            }
        }

        public void CalibrarPneu(List<Veiculo> veiculos)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n===== Calibrar pneu =====\n");
            Console.ResetColor();

            MostarVeiculo(veiculos, false);
            Console.WriteLine("Escolha um veiculo? \n Insira o numero: ");
            uint opcaoVeiculo;
            while (!uint.TryParse(Console.ReadLine(), out opcaoVeiculo))
                Console.WriteLine("Invalido! Escolha um veiculo? \n Insira o numero: ");

            Veiculo veiculo = veiculos.Find(buscaVeiculo => buscaVeiculo.IdVeiculo == opcaoVeiculo);

            Console.WriteLine("\nQual é o status do pneu do veiculo? \n 1- Muito ruim, 2- Ruim, 3- Bom");
            uint statusPneuAux;
            while ((!uint.TryParse(Console.ReadLine(), out statusPneuAux) || statusPneuAux <= 0 || statusPneuAux >= 4)) Console.WriteLine("Invalido! Qual é o status do pneu do veiculo? \n 1- Muito ruim, 2- Ruim, 3- Bom");

            veiculo.StatusPneu = statusPneuAux;
        }

        public double Autonomia(double kmLitro, double quantidadeAtualCombustivel)
        {
            double autonomiaTotal = kmLitro * quantidadeAtualCombustivel;
            return autonomiaTotal;
        }

        public void MostarStatusPneu(List<Veiculo> veiculos)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n===== Status do pneu =====\n");
            Console.ResetColor();

            veiculos.ForEach(v => {
                if (v.StatusPneu == 1) Console.WriteLine($"\nNúmero do veiculo: {v.IdVeiculo} - Nome do veiculo: {v.Modelo} -  Status pneu: MUITO RUIM!\n");
                else if (v.StatusPneu == 2) Console.WriteLine($"\nNúmero do veiculo: {v.IdVeiculo} - Nome do veiculo: {v.Modelo} -  Status pneu: RUIM!\n");
                else Console.WriteLine($"\nNúmero do veiculo: {v.IdVeiculo} - Nome do veiculo: {v.Modelo} -  Status pneu: BOM!\n");
            });
        }

        public void MostrarCombustivel(List<Veiculo> veiculos)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n===== Combustivel no tanque =====\n");
            Console.ResetColor();

            veiculos.ForEach(v => {
                Console.WriteLine($"\nNúmero do veiculo: {v.IdVeiculo} - Nome do veiculo: {v.Modelo} -  Combustivel atual {v.QuantidadeAtualAlcool + v.QuantidadeAtualGas} litros!\n");
            });
        }


        /*---------------------------------------------------PERCURSO---------------------------------------------------------------------------*/
        //Cadastra um percurso
        public Percurso CadastrarPercurso()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n===== Cadastrar =====\n");
            Console.ResetColor();

            double km;
            Console.WriteLine("Digite quantos KM essa viagem terá: ");
            while ((!double.TryParse(Console.ReadLine(), out km) || km <= 0)) Console.WriteLine("Invalido! Quantos km você deseja dirigir:\n A viagem deve ser maior do que 0KM ");

            uint clima;
            Console.WriteLine("Como está o clima dessa viagem?\n 1- Nevando  2- Chovendo  3- Ensolarado");
            while ((!uint.TryParse(Console.ReadLine(), out clima) || clima <= 0 || clima >= 4)) Console.WriteLine("Invalido!Como está o clima dessa viagem?\n 1- Chovendo  2- Nevando  3- Ensolarado");

            return new Percurso { Clima = clima, KM = km };
        }

        //Mostrar uma viagem, recebendo uma viagem como parametro
        public void MostrarPercursos(List<Percurso> ListaPercursos)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n===== Mostrar percurso =====\n");
            Console.ResetColor();

            if (ListaPercursos.Count == 0) Console.WriteLine("Não existem viagens cadastradas. ");
            ListaPercursos.ForEach(percursos =>
            {
                if (percursos.Clima == 1) Console.WriteLine($"\nA viagem {percursos.IdPercurso}: tem {percursos.KM}km e está chovendo. \n");
                else if (percursos.Clima == 2) Console.WriteLine($"\nA viagem {percursos.IdPercurso}: tem {percursos.KM}km e está nevando. \n");
                else Console.WriteLine($"\nA viagem {percursos.IdPercurso}: tem {percursos.KM}km e está ensoralado. \n");
            });
        }


        /*---------------------------------------------------VIAGEM---------------------------------------------------------------------------*/
        //Gerar viagem
        public Viagem GerarViagem(List<Veiculo> veiculos, List<Percurso> percursos)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n===== Viajar =====\n");
            Console.ResetColor();

            //escolher o percurso para a viagem
            MostrarPercursos(percursos);
            Console.WriteLine("Escolha um percurso? \n Insira o numero: ");
            uint opcaoPercurso;
            while (!uint.TryParse(Console.ReadLine(), out opcaoPercurso))
                Console.WriteLine($"Invalido! Escolha um percurso? \n Insira o numero: ");

            //escolher o veiculo para a viagem
            MostarVeiculo(veiculos, false);
            Console.WriteLine("Escolha um veiculo? \n Insira o numero: ");
            uint opcaoVeiculo;
            while (!uint.TryParse(Console.ReadLine(), out opcaoVeiculo))
                Console.WriteLine("Invalido! Escolha um veiculo? \n Insira o numero: ");


            Veiculo veiculo = veiculos.Find(buscaVeiculo => buscaVeiculo.IdVeiculo == opcaoVeiculo);
            Percurso percurso = percursos.Find(buscaPercurso => buscaPercurso.IdPercurso == opcaoPercurso);

            double distancia = percurso.KM;
            double kmPercorrido;
            double kmLitroAlcool = veiculo.KmLitroAlcool;
            double kmLitroGas = veiculo.KmLitroGas;

            //calculos de desconto de autonomia

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
                                Abastecer(veiculos);


                            else // se não quiser
                            {
                                Console.WriteLine("Você optou por não abastecer");
                                return new Viagem { VeiculoViagem = veiculo, PercursoViagem = percurso, StatusViagem = $"Viagem Pausada, distancia restante{distancia}" }; ;
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
                                Abastecer(veiculos);


                            else
                            {
                                Console.WriteLine("Você optou por não abastecer! A corrida foi cancelada");
                                return new Viagem { VeiculoViagem = veiculo, PercursoViagem = percurso, StatusViagem = $"Viagem Pausada, distancia restante{distancia}" };
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
                                Abastecer(veiculos);

                            else
                            {
                                Console.WriteLine("Você optou por não abastecer! A corrida foi cancelada");
                                return new Viagem { VeiculoViagem = veiculo, PercursoViagem = percurso, StatusViagem = $"Viagem Pausada, distancia restante{distancia}" };
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
            return new Viagem { VeiculoViagem = veiculo, PercursoViagem = percurso, StatusViagem = "Viagem Concluida" };

        }

        //Mostar viagem, recebendo uma lista de viagem como parametro
        public void MostrarViagem(List<Viagem> viagens)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n===== Relatorios =====\n");
            Console.ResetColor();

            if (viagens.Count == 0) Console.WriteLine("Não existem viagens cadastradas!");
            viagens.ForEach(v =>
            {
                Console.WriteLine($"\nNúmero: {v.IdViagem} \nVeiculo: {v.VeiculoViagem.IdVeiculo} - {v.VeiculoViagem.Modelo}" +
                    $" \nPercurso: {v.PercursoViagem.IdPercurso}\n Status da Viagem: {v.StatusViagem.ToUpper()}\n");
            });
        }


        /*---------------------------------------------------VALIDAÇÃO---------------------------------------------------------------------------*/
        //Validar as palavras
        public bool ValidarPalavras(string palavra)
        {
            if (string.IsNullOrEmpty(palavra)) return false;
            foreach (char letra in palavra) // percorre letra por letra da string
            {
                if (!char.IsLetter(letra)) return false; // negando o if, então se percorre todas as letra e for diferente da string, retorna falso
            }
            return true; // se não automaticamente retorna true
        }
    }
}
