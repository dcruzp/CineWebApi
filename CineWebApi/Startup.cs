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
            services.AddScoped<ISociosRepository,SociosRepository>();
            services.AddScoped<IEntradaRepository,EntradaRepository>();
            services.AddScoped<ISalasRepository, SalasRepository>(); 

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
                    new Pelicula(){ Titulo = "WithOut Remorse" , Genero = "Accion" , Pais = "EEUU"},
                    new Pelicula(){ Titulo = "Triple Frontier" , Genero = "Accion" , Pais = "EEUU"},
                    new Pelicula(){ Titulo = "Army Dead" , Genero = "Accion" , Pais = "EEUU"},
                    new Pelicula(){ Titulo = "Outside the Wire" , Genero = "Accion" , Pais = "EEUU"},
                    new Pelicula(){ Titulo = "Extraction" , Genero = "Accion" , Pais = "EEUU"},
                    new Pelicula(){ Titulo = "Underground" , Genero = "Accion" , Pais = "EEUU"},
                    new Pelicula(){ Titulo = "The old Guard" , Genero = "Accion" , Pais = "EEUU"},
                    new Pelicula(){ Titulo = "El Gran Robo" , Genero = "Accion" , Pais = "Espana"},
                    new Pelicula(){ Titulo = "Interestellar" , Genero = "Ciencia Ficcion" , Pais = "EEUU"},
                });

                context.SaveChanges();
            }
            if (!context.Socios.Any())
            {
                context.Socios.AddRange(new List<Socio>()
                {
                    new Socio{ Nombre ="Daniel" , CI = "97012402344" , Puntos = 0 , Apellidos="De La Cruz Prieto"},
                    new Socio{ Nombre ="David" , CI = "010201240234" , Puntos = 0 , Apellidos="De La Cruz Prieto"},
                });

                context.SaveChanges();
            }
            if (!context.Salas.Any())
            {
                context.Salas.AddRange(new List<Sala>()
                {
                    new Sala { Nombre = "Sala1" , CantidadAsientos = 20}, 
                    new Sala { Nombre = "Sala2" , CantidadAsientos = 30},
                    new Sala { Nombre = "Sala3" , CantidadAsientos = 100}
                });
                context.SaveChanges();
            }

            PutAllAsientosInDatabase(context);

            PutEntradasInDatabase(context); 
        }

        public void PutAllAsientosInDatabase (CineContext context)
        {
            foreach (var item in context.Salas)
            {
                PutAsientosInDatabase(item.IdSala, context); 
            }
        }

        public void PutAsientosInDatabase (Guid idSala , CineContext context)
        {
            var sala = context.Salas.Where(x => x.IdSala == idSala).FirstOrDefault();

            for (int i = 0; i < sala.CantidadAsientos; i++)
            {
                var asiento = new Asiento() { IdSala = sala.IdSala , Ocupado = false};
                context.Add(asiento); 
            }
            context.SaveChanges(); 
        }

        public void PutEntradasInDatabase(CineContext context)
        {
            var Pelicula = context.Peliculas.Where(x => x.Titulo == "Jurasic World").FirstOrDefault();
            var Sala = context.Salas.Where(x => x.Nombre == "Sala1").FirstOrDefault();

            var hora = DateTime.Now;

            foreach (var item in context.Asientos.Where(x=>x.IdSala == Sala.IdSala))
            {
                var entrada = new Entradum()
                {
                    IdPelicula = Pelicula.IdPelicula,
                    IdSala = Sala.IdSala,
                    IdAsiento = item.IdAsiento,
                    Hora = hora,
                    Precio = 15
                };
                context.Entrada.Add(entrada);
            }
            context.SaveChanges();
        }
    }
}
