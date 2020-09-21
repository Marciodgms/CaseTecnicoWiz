using System;
using System.Collections.Generic;
using System.Text;

namespace CaseTecnico.Model
{
    public class Genres
    {
        public Genre[] genres { get; set; }
    }

    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }
    }

}
