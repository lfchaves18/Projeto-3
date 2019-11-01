using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto3
{
    class Viagem
    {
        public double KM { get; set; }
        public bool ClimaRuim { get; set; }
        public string RespClima { get; set; }

        public void Cadastrar()
        {
            double kmAux;
            Console.WriteLine("Digite quantos KM essa viagem terá: ");
            while ((!double.TryParse(Console.ReadLine(), out kmAux) || kmAux <= 0)) Console.WriteLine("Invalido! Quantos km você deseja dirigir:\n A viagem deve ser maior do que 0KM ");
            KM = kmAux;

            Console.WriteLine("O clima desta viagem está ruim? (S ou N) ");
            string opcaoClimaRuim = Console.ReadLine().Trim().ToUpper();
            while (opcaoClimaRuim != "S" && opcaoClimaRuim != "N")
            {
                Console.WriteLine("Invalido!O clima destá viagem está ruim ? (S ou N) ");
                opcaoClimaRuim = Console.ReadLine().ToUpper().Trim();
            }
            if (opcaoClimaRuim == "S")
            {
                ClimaRuim = true;
                RespClima = "ruim";
            }
            else
            {
                ClimaRuim = false;
                RespClima = "bom";
            }

        }

        public override string ToString()=> $"A viagem tem {KM} e o clima está {RespClima}. ";
        
    }
}
