using System;
using System.Collections.Generic;

#nullable disable

namespace CineWebApi.DBModels
{
    public partial class Compra
    {
        public Guid IdCompra { get; set; }
        public Guid IdEntrada { get; set; }
        public Guid? IdDescuento { get; set; }
        public DateTime Hora { get; set; }
        public Guid IdSocio { get; set; }

        public virtual Descuento IdDescuentoNavigation { get; set; }
        public virtual Entradum IdEntradaNavigation { get; set; }
    }
}
