using AutoMapper;
using CaseTecnico.Service;
using CaseTecnico.Service.Spec;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CaseTecnico.IoC
{
    public static class Bootstrapper
    {
        private static readonly Assembly[] assemblies =
      {
            Assembly.GetEntryAssembly(),
        };

        public static IServiceCollection AddBootstrapperIoC(this IServiceCollection services)
        {

            services
                .AddScoped<IMoviesService, MoviesService>()
                .AddScoped<IGenreService ,GenreService>();

            services
               .AddAutoMapper(Bootstrapper.assemblies, ServiceLifetime.Transient);

            return services;
        }
    }
}
