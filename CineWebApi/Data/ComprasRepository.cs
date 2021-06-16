using CineWebApi.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineWebApi.Data
{
    public class ComprasRepository : IComprasRepository
    {
        private readonly CineContext _context;

        public ComprasRepository(CineContext context)
        {
            _context = context; 
        }

        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<Compra[]> GetAllComprasAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Compra> GetCompraByIdAsync(Guid id)
        {
            IQueryable<Compra> query = _context.Compras;

            return await query.FirstOrDefaultAsync(x => x.IdCompra == id);
        }

        public async Task<Compra[]> GetComprasByEntradaAsync(Guid identrada)
        {
            IQueryable<Compra> query = _context.Compras.Where(x => x.IdEntrada == identrada);

            return await query.ToArrayAsync();
        }

        public void Remove<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
