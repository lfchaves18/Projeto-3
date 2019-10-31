using System;

namespace Projeto3
{
    class Veiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public uint Ano { get; set; }
        public uint VelocidadeMaxima { get; set; }
        public double CapacidadeTanque { get; set; }
        public string Flex { get; set; }
        public string TipoCombustivel { get; set; }
        public double KmLitroGas { get; set; }
        public double KmLitroAlcool { get; set; }
        public double QuantidadeAtualGas { get; set; }
        public double QuantidadeAtualAlcool { get; set; }

        public void Cadastrar()
        {
            Console.WriteLine("Informe os dados do veiculo: ");
            Console.WriteLine("\nMarca: ");
            Marca = Console.ReadLine().ToUpper().Trim();
            while ((!ValidarPalavras(Marca)) || (Marca.Length < 2))
            {
                Console.WriteLine("Invalido! Qual é a marca do veiculo: ");
                Marca = Console.ReadLine().Trim().ToUpper();
            }

            Console.WriteLine("\nModelo: ");
            Modelo = Console.ReadLine().ToUpper().Trim();
            while (string.IsNullOrEmpty(Modelo) || (Modelo.Length < 2))
            {
                Console.WriteLine("Invalido! Qual é o modelo do veiculo: ");
                Modelo = Console.ReadLine().Trim().ToUpper();
            }

            Console.WriteLine("\nPlaca: ");
            Placa = Console.ReadLine().ToUpper().Trim();
            while ((string.IsNullOrEmpty(Placa)) || (Placa.Length != 7))
            {
                Console.WriteLine("Invalido! Qual a placa do veiculo: ");
                Placa = Console.ReadLine().ToUpper().Trim();
            }

            uint anoAux;
            Console.WriteLine("\nAno: ");
            while (!uint.TryParse(Console.ReadLine(), out anoAux)) Console.WriteLine("Invalido! Qual o ano do veiculo: ");
            Ano = anoAux;

            uint velocidadeAux;
            Console.WriteLine("\nVelocidade máxima: ");
            while (!uint.TryParse(Console.ReadLine(), out velocidadeAux)) Console.WriteLine("Invalido! Qual é a velocidade máxima? ");
            VelocidadeMaxima = velocidadeAux;

            double capacidadeAux;
            Console.WriteLine("\nCapacidade do tanque: ");
            while (!double.TryParse(Console.ReadLine(), out capacidadeAux)) Console.WriteLine("Invalido! Qual é a capacidade do tanque: ");
            CapacidadeTanque = capacidadeAux;

            Console.WriteLine("\nÉ flex? (S ou N) ");
            Flex = Console.ReadLine().ToUpper().Trim();
            while (Flex != "S" && Flex != "N")
            {
                Console.WriteLine("Invalido! O veiculo é flex? ");
                Flex = Console.ReadLine().ToUpper().Trim();
            }
            if (Flex == "S")
            {
                double aux;
                Console.WriteLine("\nKm/L na gasolina: ");
                while (!double.TryParse(Console.ReadLine(), out aux) || (aux <= 0)) Console.WriteLine("Invalido! Quantos km/L na gasolina: ");
                KmLitroGas = aux;

                Console.WriteLine("\nKm/L no alcool: ");
                while (!double.TryParse(Console.ReadLine(), out aux) || (aux <= 0)) Console.WriteLine("Invalido! Quantos km/L no alcool: ");
                KmLitroAlcool = aux;

                Console.WriteLine("\nQuantidade atual de gasolina: ");
                while (!double.TryParse(Console.ReadLine(), out aux) || (aux >= CapacidadeTanque) || (aux < 0)) Console.WriteLine("Invalido! Quantidade atual de gasolina:");
                QuantidadeAtualGas = aux;

                Console.WriteLine("\nQuantidade atual de alcool: ");
                while (!double.TryParse(Console.ReadLine(), out aux) || (aux >= CapacidadeTanque) || (aux < 0)) Console.WriteLine("Invalido! Quantidade atual de alcool: ");
                QuantidadeAtualAlcool = aux;



            }

            else
            {
                Console.WriteLine("\nQual é o tipo do combuistivel: \n A- Alcool  G- Gasolina");
                TipoCombustivel = Console.ReadLine().ToUpper();
                while (TipoCombustivel != "A" && TipoCombustivel != "G")
                {
                    Console.WriteLine("\nInvalido! Qual é o tipo do combuistivel: \n A- Alcool  G- Gasolina");
                    TipoCombustivel = Console.ReadLine().ToUpper();
                }

                if (TipoCombustivel == "G")
                {
                    double aux;
                    Console.WriteLine("\nKm/L na gasolina: ");
                    while (!double.TryParse(Console.ReadLine(), out aux) || (aux <= 0)) Console.WriteLine("Invalido! Quantos km/L na gasolina: ");
                    KmLitroGas = aux;

                    Console.WriteLine("\nQuantidade atual de gasolina: ");
                    while (!double.TryParse(Console.ReadLine(), out aux) || (aux >= CapacidadeTanque) || (aux < 0)) Console.WriteLine("Invalido! Quantidade atual de gasolina:");
                    QuantidadeAtualGas = aux;
                }
                else
                {
                    double aux;
                    Console.WriteLine("\nKm/L no alcool: ");
                    while (!double.TryParse(Console.ReadLine(), out aux) || (aux <= 0)) Console.WriteLine("Invalido! Quantos km/L no alcool: ");
                    KmLitroAlcool = aux;

                    Console.WriteLine("\nQuantidade atual de alcool: ");
                    while (!double.TryParse(Console.ReadLine(), out aux) || (aux >= CapacidadeTanque) || (aux < 0)) Console.WriteLine("Invalido! Quantidade atual de alcool: ");

                    QuantidadeAtualAlcool = aux;
                }
            }
        }

        public void Dirigir()
        {

            double distancia;
            Console.WriteLine("Quantos km você deseja dirigir: ");
            while ((!double.TryParse(Console.ReadLine(), out distancia) || distancia <= 0)) Console.WriteLine("Invalido! Quantos km você deseja dirigir: ");

            double autonomiaAlcool = Autonomia(KmLitroAlcool, QuantidadeAtualAlcool);
            double autonomiaGasolina = Autonomia(KmLitroGas, QuantidadeAtualGas);
            double autonomiaTotal = autonomiaAlcool + autonomiaGasolina;

            if (Flex == "S") // se o carro for flex
            {

                double litrosNecessarios = distancia / KmLitroAlcool; //calcula quantos litros são necessarios para percorrer a distancia
                double distanciaPercorrida = QuantidadeAtualAlcool * KmLitroAlcool; // calcula a distancia que é percorrida
                double quantidadePercorridaLitros = (distanciaPercorrida / KmLitroAlcool); //calcula quantos litros foram usar para percorrer a distancia
                QuantidadeAtualAlcool -= quantidadePercorridaLitros; //tira a quatidade de litros do tanque
                litrosNecessarios -= quantidadePercorridaLitros; // desconta o que ja tinha no tanque

                if (QuantidadeAtualAlcool == 0)
                {
                    distanciaPercorrida = QuantidadeAtualGas * KmLitroGas;
                    quantidadePercorridaLitros = distanciaPercorrida / KmLitroGas;
                    QuantidadeAtualGas -= quantidadePercorridaLitros;
                    litrosNecessarios -= quantidadePercorridaLitros;

                    string opcaoAbastecer = "s";
                    while (litrosNecessarios > 0)
                    {

                        Console.WriteLine("A quantidade atual de combustivel, não percorre a distancia solicitada. Deseja abastecer o veiculo? (S ou N)");
                        opcaoAbastecer = Console.ReadLine().ToUpper().Trim();
                        while (opcaoAbastecer != "S" && opcaoAbastecer != "N")
                        {
                            Console.WriteLine("Invalido! Deseja abastecer o veiculo? (S ou N) ");
                            opcaoAbastecer = Console.ReadLine().ToUpper().Trim();
                        }

                        if (opcaoAbastecer == "S")
                        {

                            Abastecer();
                            litrosNecessarios -= quantidadePercorridaLitros;
                        }
                        else
                        {
                            Console.WriteLine("Você optou por não abastecer! A viagem foi cancelada");
                            break;
                        }
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nDistancia percorrida com sucesso! Você dirigiu {distancia}KM. \n");
                Console.ResetColor();
            }



            else
            {
                if (TipoCombustivel == "A") // se o veiculo for alcool
                {
                    if (autonomiaTotal < distancia) //se o combustivel não for suficiente para percorrer a distancia
                    {
                        double litrosNecessarios = distancia / KmLitroAlcool; //calcula quantos litros são necessarios para percorrer a distancia
                        double distanciaPercorrida = QuantidadeAtualAlcool * KmLitroAlcool; // calcula a distancia que é percorrida
                        double quantidadePercorridaLitros = (distanciaPercorrida / KmLitroAlcool); //calcula quantos litros foram usar para percorrer a distancia
                        QuantidadeAtualAlcool -= quantidadePercorridaLitros; //tira a quatidade de litros do tanque
                        litrosNecessarios -= quantidadePercorridaLitros; // desconta o que ja tinha no tanque

                        string opcaoAbastecer = "s";
                        while (litrosNecessarios > 0 && opcaoAbastecer != "N")
                        {

                            Console.WriteLine("A quantidade atual de combustivel, não percorre a distancia solicitada. Deseja abastecer o veiculo? (S ou N)");
                            opcaoAbastecer = Console.ReadLine().ToUpper().Trim();
                            while (opcaoAbastecer != "S" && opcaoAbastecer != "N")
                            {
                                Console.WriteLine("Invalido! Deseja abastecer o veiculo? (S ou N) ");
                                opcaoAbastecer = Console.ReadLine().ToUpper().Trim();
                            }

                            if (opcaoAbastecer == "S")
                            {

                                Abastecer();
                                litrosNecessarios -= QuantidadeAtualAlcool;
                                distanciaPercorrida = QuantidadeAtualAlcool * KmLitroAlcool;
                                quantidadePercorridaLitros = (distanciaPercorrida / KmLitroAlcool);
                                QuantidadeAtualAlcool -= quantidadePercorridaLitros;
                                QuantidadeAtualAlcool -= litrosNecessarios;


                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($" Distancia percorrida");
                                Console.ResetColor();
                            }

                            else Console.WriteLine("Você optou por não abastecer! A viagem foi cancelada");
                        }
                    }
                    else // caso tem combustivel suficiente para fazer a corrida
                    {
                        double quantidadePercorridaLitros = (distancia / KmLitroAlcool);
                        QuantidadeAtualAlcool -= quantidadePercorridaLitros;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nDistancia percorrida com sucesso! Você gastou {quantidadePercorridaLitros} litros de alcool e dirigiu {distancia}KM. \n");
                        Console.ResetColor();
                    }

                }
                else // quando o veiculo for a gasolina
                {
                    if (autonomiaTotal < distancia)
                    {
                        double litrosNecessarios = distancia / KmLitroGas;
                        double distanciaPercorrida = QuantidadeAtualGas * KmLitroGas;
                        double quantidadePercorridaLitros = (distanciaPercorrida / KmLitroGas);
                        QuantidadeAtualGas -= quantidadePercorridaLitros;
                        litrosNecessarios -= quantidadePercorridaLitros; // desconta o que ja tinha no tanque


                        string opcaoAbastecer = "s";
                        while (litrosNecessarios > 0 && opcaoAbastecer != "N")
                        {

                            Console.WriteLine("A quantidade atual de combustivel, não percorre a distancia solicitada. Deseja abastecer o veiculo? (S ou N)");
                            opcaoAbastecer = Console.ReadLine().ToUpper().Trim();
                            while (opcaoAbastecer != "S" && opcaoAbastecer != "N")
                            {
                                Console.WriteLine("Invalido! Deseja abastecer o veiculo? (S ou N) ");
                                opcaoAbastecer = Console.ReadLine().ToUpper().Trim();
                            }

                            if (opcaoAbastecer == "S")
                            {

                                Abastecer();

                                litrosNecessarios -= QuantidadeAtualGas;
                                distanciaPercorrida = QuantidadeAtualGas * KmLitroGas;
                                quantidadePercorridaLitros = (distanciaPercorrida / KmLitroGas);
                                QuantidadeAtualGas -= quantidadePercorridaLitros;
                                QuantidadeAtualGas -= litrosNecessarios;

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($" Distancia percorrida com sucesso");
                                Console.ResetColor();
                            }
                            else Console.WriteLine("Você optou por não abastecer! A viagem foi cancelada");


                        }


                    }
                    else // caso tem combustivel suficiente para fazer a corrida
                    {
                        double quantidadePercorridaLitros = (distancia / KmLitroGas);
                        QuantidadeAtualGas -= quantidadePercorridaLitros;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nDistancia percorrida com sucesso! Você gastou {quantidadePercorridaLitros} litros de alcool e dirigiu {distancia}KM. \n");
                        Console.ResetColor();
                    }
                }


            }

        }

        public void Abastecer()
        {

            if (Flex == "S") // se for flex
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
                        double completar = CapacidadeTanque - QuantidadeAtualAlcool;
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
        }

        public bool ValidarPalavras(string palavra) //  metodo para validar as palavras
        {
            if (string.IsNullOrEmpty(palavra)) return false;
            foreach (char letra in palavra) // percorre letra por letra da string
            {
                if (!char.IsLetter(letra)) return false; // negando o if, então se percorre todas as letra e for diferente da string, retorna falso
            }
            return true; // se não automaticamente retorna true
        }

        public override string ToString()
        {
            return $"\nMarca: {Marca} \nModelo: {Modelo} \nPlaca: {Placa} \nAno: {Ano} \nVelocidade Máxima: {VelocidadeMaxima} \nCapacidade do tanque: {CapacidadeTanque} \nFlex: {Flex}" +
                $" \nTipo de combustivel: {TipoCombustivel} \nKm/L gasolina: {KmLitroGas} \nKm/L alcool: {KmLitroAlcool} \nQuantidade atual de gasolina: {QuantidadeAtualGas} \nQuantidade atual de alcool: {QuantidadeAtualAlcool}";
        }

        public double Autonomia(double kmLitro, double quantidadeAtualCombustivel)
        {
            double autonomiaTotal = kmLitro * quantidadeAtualCombustivel;
            return autonomiaTotal;
        }
    }
}