using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CineWebApi.Data;
using CineWebApi.DBModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace CineWebApi
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
            services.AddDbContext<CineContext>(options => options.UseInMemoryDatabase("database"));

            services.AddScoped<IPeliculaRepository,PeliculaRepository>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env , CineContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("React_Policy");

            app.UseAuthorization();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                    ForwardedHeaders.XForwardedProto
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            PutDataIntoDatabase(context); 
            
        }

        private void PutDataIntoDatabase(CineContext context)
        {
            if (!context.Peliculas.Any())
            {
                context.Peliculas.AddRange(new List<Pelicula>()
                {
                    new Pelicula(){ Titulo = "Jurasic World" , Genero = "Ciencia Ficcion" , Pais = "EEUU"},
                    new Pelicula(){ Titulo = "Exterminator" , Genero = "Ciencia Ficcion" , Pais = "EEUU"},
                });

                context.SaveChanges();
            }
        }
    }
}
