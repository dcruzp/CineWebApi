using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineWebApi.Models
{
    public class PeliculaModels
    {
        public Guid IdPelicula { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Pais { get; set; }
        public DateTime? FechaEstreno { get; set; }
        public TimeSpan? Duracion { get; set; }
        public double Evaluacion { get; set; }
    }
}
