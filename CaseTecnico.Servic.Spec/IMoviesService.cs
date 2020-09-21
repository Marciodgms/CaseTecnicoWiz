using CaseTecnico.Model;
using CaseTecnico.Transport;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseTecnico.Service.Spec
{
    public interface IMoviesService
    {
        Task<IEnumerable<DtoMoviesPopular>> ListMoviesPopular(int page);

    }
}
