using CaseTecnico.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CaseTecnico.Service.Spec
{
    public interface IGenreService
    {
        List<Genre> GetGenres(int[] genre_ids);
    }
}
