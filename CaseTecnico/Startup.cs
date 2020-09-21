using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CaseTecnico.Model;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using CaseTecnico.IoC;

namespace CaseTecnico
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();


            services
                .AddSwaggerGen()
                .Configure<SwaggerGenOptions>(this.Configuration.GetSection("Swagger:SwaggerGenOptions"))
                .Configure<SwaggerUIOptions>(this.Configuration.GetSection("Swagger:SwaggerUIOptions"));

            var dadosApi = Configuration.GetSection("DadosApi");
            services.Configure<DadosApi>(dadosApi);
            services.AddBootstrapperIoC();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger(c =>
            {
                if (env.IsProduction())
                {
                    c.RouteTemplate = this.Configuration.GetValue<string>("Swagger:RouteTemplate");
                }
            });
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
