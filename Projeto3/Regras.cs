using System;

namespace Projeto3
{
    class Regras
    {
        public void Dirigir(Veiculo veiculo, Viagem viagem)
        {
            double distancia = viagem.KM;
            if (veiculo.TipoCombustivel == "A")
            {
             //   double autonomia = veiculo.Autonomia(veiculo.KmLitroAlcool, veiculo.QuantidadeAtualAlcool);
                double kmPercorrido;
                while (distancia > 0)
                {
                   
                    if (distancia > (veiculo.KmLitroAlcool * veiculo.QuantidadeAtualAlcool)) // se o combustivel necessario para percoorer a distancia não for suficiente
                    {

                        kmPercorrido = (veiculo.KmLitroAlcool * veiculo.QuantidadeAtualAlcool);
                        veiculo.QuantidadeAtualAlcool -= kmPercorrido / veiculo.KmLitroAlcool;
                        distancia -= kmPercorrido;

                        Console.WriteLine($"Você percorreu {kmPercorrido} km");

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
                               veiculo.Abastecer();
                               
                            
                            else // se não quiser
                            {
                                Console.WriteLine("Você optou por não abastecer");
                                return;
                            }

                            distancia -= kmPercorrido;
                        }
                    }
                    else // se o combustivel necessario para percoorer a distancia  for suficiente
                    {
                        kmPercorrido = (veiculo.KmLitroAlcool * veiculo.QuantidadeAtualAlcool);
                        double quantidadePercorridaLitros = (distancia / veiculo.KmLitroAlcool);
                        veiculo.QuantidadeAtualAlcool -= quantidadePercorridaLitros;
                        distancia -= kmPercorrido;

                    }
                }
            }
            else //  se o carro for a gasolina
            {

            }
        }
    }
}
