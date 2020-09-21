using CaseTecnico.Model;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseTecnico.Core
{
    public class Contexto
    {

        private readonly IOptions<DadosApi> _dadosApi;
        public Contexto(IOptions<DadosApi> dadosApi)
        {
            _dadosApi = dadosApi;
        }
        public MoviePopular GetMoviePopular(int page)
        {
            string urlFormatada = string.Format(Constants.URL_MOVIE_POPULAR, _dadosApi.Value.ApiKey, Constants.LANGUAGE, page);

            var client = new RestClient(urlFormatada);

            var request = new RestRequest(Method.GET);
            IRestResponse response =  client.Execute(request);
            var moviePopular = JsonConvert.DeserializeObject<MoviePopular>(response.Content);
            return moviePopular;
        } 

    }
}
