using CineWebApi.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineWebApi.Data
{
    public class EntradaRepository : IEntradaRepository
    {
        private readonly CineContext _context;
        private readonly ILogger<EntradaRepository> _logger; 

        public EntradaRepository (CineContext context , ILogger<EntradaRepository> logger )
        {
            _context = context;
            _logger = logger; 
        }
        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Anadiendo entrada");
            _context.Add(entity); 
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Removiendo entrada");
            _context.Remove(entity); 
        }

        public async Task<Entradas[]> GetAllEntradasAsync()
        {
            _logger.LogInformation($"Filtrando todas las entradas que hay" +
                                     $" en la base de datos");

            IQueryable<Entradas> query = _context.Entrada;

            //Ordenandolas de forma descendente por la hora en que 
            //entan disponibles las entradas. 
            query.OrderByDescending(x => x.Hora);

            return await query.ToArrayAsync();
        }

       

        public async Task<Entradas[]> GetAllEntradasAsync(DateTime min_datetime, 
                                                    DateTime max_datetime, 
                                                    decimal min_price, 
                                                    decimal max_price, 
                                                    Guid idpelicula, 
                                                    string nombrePelicula, 
                                                    Guid idSala, 
                                                    string nombreSala)
        {
            _logger.LogInformation($"filtrando las entradas que corresponden a " +
                $"el rango de fecha entre {min_datetime} y {max_datetime} " +
                $"y por el precio entre {min_price} , {max_price}");
               

            IQueryable<Entradas> query = _context.Entrada;

            //filtando por hora de presentacion de las entradas
            query = query.Where(x => x.Hora > min_datetime && x.Hora < max_datetime);

            //filtrando por el precio de las entradas 
            query = query.Where(x => x.Precio > min_price && x.Precio < max_price);


            //filtando por el id de la pelicula
            if(idpelicula != Guid.Empty)
            {
                query = query.Where(x => x.IdEntrada == idpelicula);
            }


            //filtando por el nombre de la pelicula 
            if (!string.IsNullOrEmpty(nombrePelicula))
            {
                query = query.Where(x => x.IdPeliculaNavigation.Titulo == nombrePelicula);
            }
            

            //filtrando por el id de la sala 
            if (idSala != Guid.Empty)
            {
                query = query.Where(x => x.IdSala == idSala);
            }

            //filtrando por el nombre de la sala 
            if (!string.IsNullOrEmpty(nombreSala))
            {
                query = query.Where(x => x.IdSalaNavigation.Nombre == nombreSala);
            }

            return await query.ToArrayAsync();
        }

        public async Task<Entradas> GetEntradaAsync(Guid id)
        {
            _logger.LogInformation($"filtrando la entrada que corresponde " +
                $"el Id = {id.ToString()}");

            IQueryable<Entradas> query = _context.Entrada;

            query = query.Where(x => x.IdEntrada == id);

            return await query.FirstOrDefaultAsync(); 
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0; 
        }
    }
}
