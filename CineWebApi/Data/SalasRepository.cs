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
    public class SalasRepository : ISalasRepository
    {
        private readonly CineContext _context;
        private readonly ILogger<SalasRepository> _logger; 

        public SalasRepository(CineContext context , ILogger<SalasRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            Sala sala = entity as Sala;
            
            if (sala == null)
            {
                throw new Exception($"No se paso una entidad sala como parametro");
            }

            for (int i = 0; i < sala.CantidadAsientos; i++)
            {
                var asiento = new Asiento()
                {
                    IdSala = sala.IdSala,
                    Ocupado = false                    
                };

                _context.Add(asiento); 
            }
            _context.Add(sala); 
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<Sala[]> GetAllSalasAsync()
        {
            IQueryable<Sala> query = _context.Salas;

            return await query.ToArrayAsync();
        }

        public async Task<Sala> GetSalaAsync(Guid id)
        {
            IQueryable<Sala> query = _context.Salas;

            query = query.Where(x => x.IdSala == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
