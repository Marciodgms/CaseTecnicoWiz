using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseTecnico.Model;
using CaseTecnico.Service.Spec;
using CaseTecnico.Transport;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CaseTecnico.Api.Controllers
{
    [ApiController, Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;
        public MoviesController(IMoviesService moviesService)
        {
            this._moviesService = moviesService;
        }
        [HttpGet,Route("Buscar/{page}")]
        public async Task<IEnumerable<DtoMoviesPopular>> Buscar(int page)
        {
            var moviesPopular = await _moviesService.ListMoviesPopular(page);
            return moviesPopular;
        }

    }
}
