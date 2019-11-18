using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto3
{
    class Percurso
    {
        public double KM { get; set; }
        public uint Clima { get; set; }
        //TODO: validar random
        public int IdPercurso { get; set; } = new Random().Next(1, 9999);
    }
}
