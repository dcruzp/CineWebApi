using System;
using System.Collections.Generic;

#nullable disable

namespace CineWebApi.DBModels
{
    public partial class Pelicula
    {
        public Guid id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Pais { get; set; }
        public DateTime? FechaEstreno { get; set; }
    }
}
