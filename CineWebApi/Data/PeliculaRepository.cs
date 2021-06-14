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
    public class PeliculaRepository:IPeliculaRepository
    {
        private readonly CineContext _context;
        private readonly ILogger<PeliculaRepository> _logger;

        public PeliculaRepository(CineContext context, ILogger<PeliculaRepository> logger )
        {
            _context = context;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"anadiendo una pelicula a la " +
                $"base de datos ");

            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Borrando la pelicula de la " +
                $"base de datos"); 

            _context.Remove(entity);
        }

        public async Task<Pelicula[]> GetAllPeliculasAsync()
        {
            _logger.LogInformation($"Filtrando todas las peliculas que hay en la " +
                $"base de datos ");

            IQueryable<Pelicula> query = _context.Peliculas;

            query = query.OrderBy(T => T.Titulo);

            return await query.ToArrayAsync();
        }

        public async Task<Pelicula> GetPeliculaAsync(string titulo)
        {
            _logger.LogInformation($"Filtrando la pelicula cuyo titulo " +
                $"es {titulo}"); 

            IQueryable<Pelicula> query = _context.Peliculas.Where(n => n.Titulo == titulo);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pelicula> GetPeliculaAsync(Guid id)
        {
            _logger.LogInformation($"Filtrando la pelicula cuyo Id" +
                $"es {id}");

            IQueryable<Pelicula> query = _context.Peliculas.Where(n => n.IdPelicula == id);

            return await query.FirstOrDefaultAsync();
        }


        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
