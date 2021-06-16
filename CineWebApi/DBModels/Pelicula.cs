using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CineWebApi.DBModels
{
    public partial class Pelicula
    {
        public Pelicula()
        {
            Entrada = new HashSet<Entradas>();
        }

        public Guid IdPelicula { get; set; }
        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Pais { get; set; }
        public DateTime? FechaEstreno { get; set; }
        public TimeSpan? Duracion { get; set; }
        public double Evaluacion { get; set; }
        public string DireccionFoto { get; set; }

        public virtual ICollection<Entradas> Entrada { get; set; }
    }
}
