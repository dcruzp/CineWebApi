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
    public class SociosRepository : ISociosRepository
    {

        private readonly CineContext _context;
        private readonly ILogger<SociosRepository> _logger;

        public SociosRepository(CineContext context, ILogger<SociosRepository> logger)
        {
            _context = context; 
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Anadiendo un socio a la base de datos");

            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Borrando  un socio de la base de datos"); 

            _context.Remove(entity);
        }

        public async Task<Socio[]> GetAllSociosAsync()
        {
            _logger.LogInformation($"Filtando todos los Socios que existen " +
                $"en la base de datos");

            IQueryable<Socio> query = _context.Socios;

            //query = query.OrderByDescending(x => x.Nombre);

            return await query.ToArrayAsync(); 
        }

        public async Task<Socio[]> GetSociosAsync(string nombre)
        {
            _logger.LogInformation($"Filtando todos los Socios que exsiten" +
                $"en la base de datos que tiene por nombre '{nombre}'");

            IQueryable<Socio> query = _context.Socios.Where(x => x.Nombre == nombre);

            return await query.ToArrayAsync(); 
        }

        public async Task<Socio> GetSociosAsync(Guid id)
        {
            _logger.LogInformation($"Filtando el sicio de la base de datos que " +
                $"tiene el siguiente id '{id.ToString()}'");

            IQueryable<Socio> query = _context.Socios.Where(x => x.IdSocio == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
