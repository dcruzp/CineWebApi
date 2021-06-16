using CineWebApi.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineWebApi.Data
{
    public interface ISociosRepository
    {
        public void Add<T>(T entity) where T : class;

        public void Delete<T>(T entity) where T : class;

        public Task<Socio[]> GetAllSociosAsync();

        public Task<Socio[]> GetSociosAsync(string nombre);

        public Task<Socio> GetSociosAsync(Guid id);

        public Task<bool> SaveChangesAsync();
    }
}
