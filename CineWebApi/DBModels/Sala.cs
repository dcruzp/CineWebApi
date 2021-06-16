using System;
using System.Collections.Generic;

#nullable disable

namespace CineWebApi.DBModels
{
    public partial class Sala
    {
        public Sala()
        {
            Asientos = new HashSet<Asiento>();
            Entrada = new HashSet<Entradas>();
        }

        public Guid IdSala { get; set; }
        public string Nombre { get; set; }
        public int CantidadAsientos { get; set; }

        public virtual ICollection<Asiento> Asientos { get; set; }
        public virtual ICollection<Entradas> Entrada { get; set; }
    }
}
