using CaseTecnico.Model;
using CaseTecnico.Service.Spec;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTecnico.Service
{
    public class GenreService : IGenreService
    {
        private readonly IOptions<DadosApi> _dadosApi;
        public GenreService(IOptions<DadosApi> dadosApi)
        {
            _dadosApi = dadosApi;
        }
        public List<Genre> GetGenres(int[] genre_ids)
        {
            string urlFormatada = string.Format(Constants.URL_GENRE, _dadosApi.Value.ApiKey, Constants.LANGUAGE);
            var client = new RestClient(urlFormatada);
            var request = new RestRequest(Method.GET);
            IRestResponse response =  client.Execute(request);
            var genres = JsonConvert.DeserializeObject<Genres>(response.Content);

            var result = genres.genres.Where(x => genre_ids.Contains(x.id)).ToList();
            return result;
        }
    }
}
