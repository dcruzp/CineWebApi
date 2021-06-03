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
            Entrada = new HashSet<Entradum>();
        }

        public Guid IdSala { get; set; }
        public byte[] Nombre { get; set; }
        public int CantidadAsientos { get; set; }

        public virtual ICollection<Asiento> Asientos { get; set; }
        public virtual ICollection<Entradum> Entrada { get; set; }
    }
}
