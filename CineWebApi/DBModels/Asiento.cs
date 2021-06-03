using System;
using System.Collections.Generic;

#nullable disable

namespace CineWebApi.DBModels
{
    public partial class Asiento
    {
        public Asiento()
        {
            Entrada = new HashSet<Entradum>();
        }

        public Guid IdAsiento { get; set; }
        public bool Ocupado { get; set; }
        public Guid IdSala { get; set; }

        public virtual Sala IdSalaNavigation { get; set; }
        public virtual ICollection<Entradum> Entrada { get; set; }
    }
}
