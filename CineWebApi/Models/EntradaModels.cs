using CineWebApi.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineWebApi.Models
{
    public class EntradaModels
    {
        public Pelicula Pelicula { get; set; }
        public ICollection<Sala>  Salas{ get; set; }        
        public ICollection<DateTime> Fechas { get; set;  }
    }
}
