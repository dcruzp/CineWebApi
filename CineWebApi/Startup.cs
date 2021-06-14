using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CineWebApi.Data;
using CineWebApi.DBModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

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

            //services.AddDbContext<CineContext>(options => 
            //options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

            services.AddIdentity<CineUser, IdentityRole>()
                .AddEntityFrameworkStores<CineContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "yourdomain.com",
                    ValidAudience = "yourdomain.com",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                        Configuration["Llave_super_secreta"])),
                    ClockSkew = TimeSpan.Zero
                }); 

            services.AddScoped<IPeliculaRepository,PeliculaRepository>();
            services.AddScoped<ISociosRepository,SociosRepository>();
            services.AddScoped<IEntradaRepository,EntradaRepository>();
            services.AddScoped<ISalasRepository, SalasRepository>(); 

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddControllers();

            services.AddControllers().AddNewtonsoftJson(options =>
              options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
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

            app.UseAuthentication(); 

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
                    new Socio{ Nombre ="David" , CI = "01020124023" , Puntos = 0 , Apellidos="De La Cruz Prieto"},
                });

                context.SaveChanges();
            }
            if (!context.Salas.Any())
            {
                context.Salas.AddRange(new List<Sala>()
                {
                    CreateSala("Sala1", 20), 
                    CreateSala("Sala2", 30),
                    CreateSala("Sala3", 40)
                });
                context.SaveChanges();
            }

            if (!context.Entrada.Any())
            {
                PutEntradasInDatabase(context);
            }
            
        }

        
        private Sala CreateSala (string nombre, int cantidadasientos)
        {
            Sala sala = new Sala();
            sala.Nombre = nombre;
            sala.CantidadAsientos = cantidadasientos;

            List<Asiento> asientos = new List<Asiento>(); 

            for (int i = 0; i < sala.CantidadAsientos; i++)
            {
                Asiento asiento = new Asiento() { Ocupado = false };
                asientos.Add(asiento); 
            }

            sala.Asientos = asientos;

            return sala; 
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
