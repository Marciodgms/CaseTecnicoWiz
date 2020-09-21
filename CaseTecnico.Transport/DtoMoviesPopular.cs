using CaseTecnico.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseTecnico.Transport
{
   public class DtoMoviesPopular
    {
        public string Nome { get; set; }
        public string Generos { get; set; }
        public DateTime DataDeLancamento { get; set; }
        public string Descricao { get; set; }
    }
}
