using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CineWebApi.DBModels
{
    public partial class Asiento
    {
        public Asiento()
        {
            Entrada = new HashSet<Entradas>();
        }

        
        public Guid IdAsiento { get; set; }        
        public string Tipo { get; set; } 
        public int NumeroAsiento { get; set; }
        public Guid IdSala { get; set; }

        public virtual Sala IdSalaNavigation { get; set; }
        public virtual ICollection<Entradas> Entrada { get; set; }
    }
}
