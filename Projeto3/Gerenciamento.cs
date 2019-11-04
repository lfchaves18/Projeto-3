using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto3
{
    class Gerenciamento
    {
        //metodo que cadastra o veiculo
        public Veiculo CadastrarVeiculo()
        {
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


            double capacidade = 0;
            double kmLitroGas = 0;
            double kmLitroAlcool = 0;
            double quantidadeAtualAlcool = 0;
            double quantidadeAtualGas = 0;
            string statusPneu = "";
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
                while (!double.TryParse(Console.ReadLine(), out quantidadeAtualGas) || (quantidadeAtualAlcool + quantidadeAtualGas >= capacidade) || (quantidadeAtualGas < 0)) Console.WriteLine("Invalido! Quantidade atual de gasolina:");

                Console.WriteLine("\nQuantidade atual de alcool: \nLembre-se que não pode ultrapassar o limite.");
                while (!double.TryParse(Console.ReadLine(), out quantidadeAtualAlcool) || (quantidadeAtualAlcool + quantidadeAtualGas >= capacidade) || (quantidadeAtualAlcool < 0)) Console.WriteLine("Invalido! Quantidade atual de alcool: ");

            }

            else
            {
                flex = false;
                string tipoCombustivel;
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
                statusPneu = Console.ReadLine().ToUpper();
                while (statusPneu != "1" && statusPneu != "2" && statusPneu != "3")
                {
                    Console.WriteLine("\nInvalido! Qual é o status do pneu do veiculo? \n 1- Muito ruim, 2- Ruim, 3- Bom");
                    statusPneu = Console.ReadLine().ToUpper();
                }

            }
            return new Veiculo
            {
                Marca = marca,
                Modelo = modelo,
                Placa = placa,
                Ano = ano,
                VelocidadeMaxima = velocidadeAux,
                CapacidadeTanque = capacidade,
                Flex = flex,
                KmLitroGas = kmLitroGas,
                KmLitroAlcool = kmLitroAlcool,
                QuantidadeAtualAlcool = quantidadeAtualAlcool,
                QuantidadeAtualGas = quantidadeAtualGas,
                StatusPneu = statusPneu
            };

        }

        //metodo que cadastra a viagem
        public Viagem CadastrarViagem()
        {
            double km;
            Console.WriteLine("Digite quantos KM essa viagem terá: ");
            while ((!double.TryParse(Console.ReadLine(), out km) || km <= 0)) Console.WriteLine("Invalido! Quantos km você deseja dirigir:\n A viagem deve ser maior do que 0KM ");

            bool climaRuim;
            Console.WriteLine("O clima desta viagem está ruim? (S ou N) ");
            string opcaoClimaRuim = Console.ReadLine().Trim().ToUpper();
            while (opcaoClimaRuim != "S" && opcaoClimaRuim != "N")
            {
                Console.WriteLine("Invalido!O clima destá viagem está ruim ? (S ou N) ");
                opcaoClimaRuim = Console.ReadLine().ToUpper().Trim();
            }
            if (opcaoClimaRuim == "S")
                climaRuim = true;

            else
                climaRuim = false;

            return new Viagem { ClimaRuim = climaRuim, KM = km };
        }

        //metodo para mostrar um veiculo, recebendo um veiculo como parametro
        public void MostarVeiculo(Veiculo veiculo)
        {
            Console.WriteLine($"\nMarca: {veiculo.Marca} \nModelo: {veiculo.Modelo} \nPlaca: {veiculo.Placa} \nAno: {veiculo.Ano}" +
                $" \nVelocidade Máxima: {veiculo.VelocidadeMaxima} \nCapacidade do tanque: {veiculo.CapacidadeTanque} \nFlex: {veiculo.Flex}" +
                $" \nTipo de combustivel: {veiculo.TipoCombustivel} \nKm/L gasolina: {veiculo.KmLitroGas} \nKm/L alcool: {veiculo.KmLitroAlcool} " +
                $"\nQuantidade atual de gasolina: {veiculo.QuantidadeAtualGas} \nQuantidade atual de alcool: {veiculo.QuantidadeAtualAlcool}");
        }

        //metodo para mostrar uma viagem, recebendo uma viagem como parametro
        public void MostrarViagem(Viagem viagem)
        {
            if (viagem.ClimaRuim)
                Console.WriteLine($"A viagem tem {viagem.KM} e o clima está ruim. ");
            else Console.WriteLine($"A viagem tem {viagem.KM} e o clima está bom. ");
        }

        //metodo para validar as palavras
        public bool ValidarPalavras(string palavra)
        {
            if (string.IsNullOrEmpty(palavra)) return false;
            foreach (char letra in palavra) // percorre letra por letra da string
            {
                if (!char.IsLetter(letra)) return false; // negando o if, então se percorre todas as letra e for diferente da string, retorna falso
            }
            return true; // se não automaticamente retorna true
        }

        public void Dirigir(Veiculo veiculo, Viagem viagem)
        {
            if (viagem.ClimaRuim == true)
            {
                veiculo.KmLitroAlcool -= (veiculo.KmLitroAlcool *0.135) ;
                veiculo.KmLitroGas -= (veiculo.KmLitroGas  *0.120); 
            }

            double distancia = viagem.KM;
            double kmPercorrido = 0;

            if (veiculo.Flex == true) // se o veiculo for flex
            {
                // verifica se a autonomia é suficiente para percorrer a viagem. se não for
                if (distancia > (veiculo.QuantidadeAtualAlcool * veiculo.KmLitroAlcool + veiculo.QuantidadeAtualGas * veiculo.KmLitroGas))
                {
                    kmPercorrido = (veiculo.KmLitroAlcool * veiculo.QuantidadeAtualAlcool);
                    veiculo.QuantidadeAtualAlcool -= kmPercorrido / veiculo.KmLitroAlcool;

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
                                veiculo.Abastecer(false);


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

                        Console.WriteLine(veiculo.QuantidadeAtualGas);
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

                    if ((veiculo.KmLitroAlcool * veiculo.QuantidadeAtualAlcool) <= distancia) // se o combustivel necessario para percoorer a distancia não for suficiente
                    {
                        while (distancia > 0)
                        {
                            kmPercorrido = (veiculo.KmLitroAlcool * veiculo.QuantidadeAtualAlcool);
                            veiculo.QuantidadeAtualAlcool -= kmPercorrido / veiculo.KmLitroAlcool;


                            Console.WriteLine($"Você percorreu {kmPercorrido:F2} km.");

                            if (veiculo.QuantidadeAtualAlcool == 0) // se acabar o combustivel
                            {
                                Console.WriteLine("A quantidade atual de combustivel, não percorre a distancia solicitada. Deseja abastecer o veiculo? (S ou N)");
                                string opcaoAbastecer = Console.ReadLine().ToUpper().Trim();
                                while (opcaoAbastecer != "S" && opcaoAbastecer != "N")
                                {
                                    Console.WriteLine("Invalido! Deseja abastecer o veiculo? (S ou N) ");
                                    opcaoAbastecer = Console.ReadLine().ToUpper().Trim();
                                }

                                if (opcaoAbastecer == "S") // se quiser abastecer
                                    veiculo.Abastecer(false);


                                else // se não quiser
                                {
                                    Console.WriteLine("Você optou por não abastecer");
                                    return;
                                }
                            }

                            distancia -= kmPercorrido;
                            veiculo.QuantidadeAtualAlcool -= kmPercorrido / veiculo.KmLitroAlcool;
                        }
                    }
                    else // se o combustivel necessario para percoorer a distancia  for suficiente
                        veiculo.QuantidadeAtualAlcool -= kmPercorrido / veiculo.KmLitroAlcool;


                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nVocê concluiu o percurso total\n");
                    Console.ResetColor();
                }
                else //  se o carro for a gasolina
                {


                    if ((veiculo.KmLitroGas * veiculo.QuantidadeAtualGas) <= distancia) // se o combustivel necessario para percoorer a distancia não for suficiente
                    {
                        while (distancia > 0)
                        {


                            kmPercorrido = (veiculo.KmLitroGas * veiculo.QuantidadeAtualGas);
                            veiculo.QuantidadeAtualGas -= kmPercorrido / veiculo.KmLitroGas;

                            if (kmPercorrido == distancia)
                                Console.WriteLine($"Você percorreu {kmPercorrido:F2} km");
                            else
                            {
                                Console.WriteLine($"Você percorreu {kmPercorrido:F2} km.");

                                if (veiculo.QuantidadeAtualGas == 0) // se acabar o combustivel
                                {
                                    Console.WriteLine("A quantidade atual de combustivel, não percorre a distancia solicitada. Deseja abastecer o veiculo? (S ou N)");
                                    string opcaoAbastecer = Console.ReadLine().ToUpper().Trim();
                                    while (opcaoAbastecer != "S" && opcaoAbastecer != "N")
                                    {
                                        Console.WriteLine("Invalido! Deseja abastecer o veiculo? (S ou N) ");
                                        opcaoAbastecer = Console.ReadLine().ToUpper().Trim();
                                    }

                                    if (opcaoAbastecer == "S") // se quiser abastecer
                                        veiculo.Abastecer(false);


                                    else // se não quiser
                                    {
                                        Console.WriteLine("Você optou por não abastecer");
                                        return;
                                    }
                                }
                            }
                            distancia -= kmPercorrido;
                            veiculo.QuantidadeAtualGas -= kmPercorrido / veiculo.KmLitroGas;
                        }
                    }
                    else // se o combustivel necessario para percoorer a distancia  for suficiente
                        veiculo.QuantidadeAtualGas -= kmPercorrido / veiculo.KmLitroGas;
                }
            }
        }
    }
}
