using CineWebApi.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineWebApi.Models
{
    public class SalaModels
    {
        public Guid IdSala { get; set; }
        public string Nombre { get; set; }
        public int CantidadAsientos { get; set; }

        public virtual ICollection<Asiento> Asientos { get; set; }
    }
}
