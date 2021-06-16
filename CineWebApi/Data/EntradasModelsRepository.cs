using CineWebApi.DBModels;
using CineWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineWebApi.Data
{
    public class EntradasModelsRepository : IEntradasModelsRepository
    {
        private readonly CineContext _context; 

        public EntradasModelsRepository(CineContext context)
        {
            _context = context;
        }

        public Task<EntradaModels[]> GetAllEntradasModelsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<EntradaModels> GetEntradaModelsByPelicula(Guid id)
        {
            IQueryable<Pelicula> query = _context.Peliculas.Where(x => x.IdPelicula == id);

            Pelicula pelicula = await query.FirstOrDefaultAsync();

            if (pelicula == null)
            {
                return new EntradaModels(); 
            }

            IQueryable<Entradas> query1 = _context.Entrada.Where(x => x.IdPelicula == id).Include(x=>x.IdSalaNavigation).IgnoreAutoIncludes();

            

            var query2 = (await query1.ToArrayAsync()).GroupBy(x => x.Hora);

            var query3 = (await query1.ToArrayAsync()).GroupBy(x => x.IdSalaNavigation);

            var horarios = query2.Select(x => x.Key).ToArray();

            var salas =  query3.Select(x => x.Key).ToArray();

            pelicula.Entrada = null;

            EntradaModels entradaQueryModels = new EntradaModels() {
                Pelicula = pelicula,
                Fechas = horarios,
                Salas = salas,               
            };
            
            return entradaQueryModels;
        }
    }
}
