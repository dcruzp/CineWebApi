using System;
using System.Collections.Generic;

#nullable disable

namespace CineWebApi.DBModels
{
    public partial class Compra
    {
        public Guid IdCompra { get; set; }
        public Guid IdEntrada { get; set; }
        public DateTime Hora { get; set; }
        public Guid IdSocio { get; set; }

        public virtual Entradas IdEntradaNavigation { get; set; }
        public virtual ICollection<Asiento> IdAsientosNavigation { get; set; }
    }
}
