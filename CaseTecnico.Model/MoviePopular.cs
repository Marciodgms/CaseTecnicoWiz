using System;
using System.Collections.Generic;
using System.Text;

namespace CaseTecnico.Model
{
    public class MoviePopular
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public Result[] results { get; set; }
    }


}
