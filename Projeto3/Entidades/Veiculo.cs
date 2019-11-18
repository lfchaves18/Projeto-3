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
        public uint StatusPneu { get; set; }
        //TODO: validar o random
        public int IdVeiculo { get; set; } = new Random().Next(1, 9999);

       
    }
}
