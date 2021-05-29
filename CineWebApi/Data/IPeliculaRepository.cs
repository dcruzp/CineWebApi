using CineWebApi.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineWebApi.Data
{
    public interface IPeliculaRepository
    {
        public void Add<T>(T entity) where T : class;

        public void Delete<T>(T entity) where T : class;

        public Task<Pelicula[]> GetAllPeliculasAsync();

        public Task<Pelicula> GetPeliculaAsync(string titulo);

        public Task<bool> SaveChangesAsync();

    }
}
