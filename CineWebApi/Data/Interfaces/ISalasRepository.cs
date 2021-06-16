using CineWebApi.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineWebApi.Data
{
    public interface ISalasRepository
    {
        public void Add<T>(T entity) where T : class;

        public void Delete<T>(T entity) where T : class;

        public Task<bool> SaveChangesAsync();

        public Task<Sala[]> GetAllSalasAsync(bool includeasientos = false);

        public Task<Sala> GetSalaAsync(Guid id, bool includeasientos = false); 
    }
}
