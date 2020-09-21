using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace CaseTecnico.Model
{
    public class Constants
    {
        public const string LANGUAGE = "pt-BR";
        public const string URL_MOVIE_POPULAR = "https://api.themoviedb.org/3/movie/popular?api_key={0}&language={1}&page={2}";
        public const string URL_GENRE = "https://api.themoviedb.org/3/genre/movie/list?api_key={0}&language={1}";
    }
}
