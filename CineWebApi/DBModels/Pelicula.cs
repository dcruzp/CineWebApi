using System;
using System.Collections.Generic;

#nullable disable

namespace CineWebApi.DBModels
{
    public partial class Pelicula
    {
        public Pelicula()
        {
            Entrada = new HashSet<Entradum>();
        }

        public Guid IdPelicula { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Pais { get; set; }
        public DateTime? FechaEstreno { get; set; }
        public TimeSpan? Duracion { get; set; }
        public double Evaluacion { get; set; }

        public virtual ICollection<Entradum> Entrada { get; set; }
    }
}
