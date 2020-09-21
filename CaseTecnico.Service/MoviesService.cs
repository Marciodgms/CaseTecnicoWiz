using CaseTecnico.Model;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using CaseTecnico.Service.Spec;
using System.Threading.Tasks;
using CaseTecnico.Transport;
using System.Linq;

namespace CaseTecnico.Service
{
    public class MoviesService : IMoviesService
    {

        private readonly IOptions<DadosApi> _dadosApi;
        private readonly IGenreService _genreService;
        public MoviesService(IOptions<DadosApi> dadosApi, IGenreService genreService)
        {
            _dadosApi = dadosApi;
            _genreService = genreService;
        }

        public async Task<IEnumerable<DtoMoviesPopular>> ListMoviesPopular(int page)
        {
            string urlFormatada = string.Format(Constants.URL_MOVIE_POPULAR, _dadosApi.Value.ApiKey, Constants.LANGUAGE, page);

            var client = new RestClient(urlFormatada);

            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            var moviePopular = JsonConvert.DeserializeObject<MoviePopular>(response.Content);
            
            var result = moviePopular.results.Select(x =>
            {
                List<Genre> lists = _genreService.GetGenres(x.genre_ids);
                return new DtoMoviesPopular
                {
                    Nome = x.title,
                    DataDeLancamento = DateTime.Parse(x.release_date),
                    Generos = String.Join(',',lists.Select(n => n.name)),
                    Descricao = x.overview
                };
            }).ToList();
            return result;
        }

    }
}
