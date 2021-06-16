using CineWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineWebApi.Data
{
    public interface IEntradasModelsRepository
    {
        public Task<EntradaModels[]> GetAllEntradasModelsAsync();

        public Task<EntradaModels> GetEntradaModelsByPelicula(Guid id);
    }
}
