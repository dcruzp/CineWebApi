using CineWebApi.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineWebApi.Data
{
    public interface IEntradaRepository
    {
        public void Add<T>(T entity) where T : class;

        public void Delete<T>(T entity) where T : class;

        public Task<bool> SaveChangesAsync();

        public Task<Entradas[]> GetAllEntradasAsync();

        public Task<Entradas> GetEntradaAsync(Guid id);

        public Task<Entradas[]> GetAllEntradasAsync(DateTime min_datetime,
                                                    DateTime max_datetime,
                                                    decimal min_price,
                                                    decimal max_price,
                                                    Guid idpelicula,
                                                    string nombrePelicula,
                                                    Guid idSala,
                                                    string nombreSala); 
    }
}
