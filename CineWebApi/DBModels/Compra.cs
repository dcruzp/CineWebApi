using System;
using System.Collections.Generic;

#nullable disable

namespace CineWebApi.DBModels
{
    public partial class Compra
    {
        public Guid IdCompra { get; set; }
        public Guid IdEntrada { get; set; }
        public Guid IdAsiento { get; set;}
        public DateTime Hora { get; set; }
        public Guid? IdSocio { get; set; }
        public Guid IdDescuento { get; set; }
        public bool Cancelado { get; set; }

        public virtual Entradas IdEntradaNavigation { get; set; }

        public virtual Asiento IdAsientoNavicational { get; set; }

        public virtual Descuento IdDescuentoNavicational { get; set; }
    }
}
