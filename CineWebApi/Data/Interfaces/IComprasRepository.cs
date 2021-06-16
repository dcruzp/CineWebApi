using CineWebApi.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineWebApi.Data
{
    public interface IComprasRepository
    {
        public void Add<T>(T entity) where T : class;

        public void Remove<T>(T entity) where T : class;

        public Task<bool> SaveChangesAsync();

        public Task<Compra[]> GetAllComprasAsync ();

        public Task<Compra[]> GetComprasByEntradaAsync(Guid identrada);

        public Task<Compra> GetCompraByIdAsync(Guid id);

    }
}
