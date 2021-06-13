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
            _context.Add(entity); 
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity); 
        }

        public async Task<Sala[]> GetAllSalasAsync(bool includeasientos = false)
        {
            IQueryable<Sala> query = _context.Salas;

            if (includeasientos )
            {
                query = query.Include(x => x.Asientos);
            }

            return await query.ToArrayAsync();
        }

        public async Task<Sala> GetSalaAsync(Guid id , bool includeasientos = false)
        {
            IQueryable<Sala> query = _context.Salas;

            query = query.Where(x => x.IdSala == id);

            if (includeasientos)
            {
                query = query.Include(x => x.Asientos); 
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
