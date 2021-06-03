using System;
using System.Collections.Generic;

#nullable disable

namespace CineWebApi.DBModels
{
    public partial class Descuento
    {
        public Descuento()
        {
            Compras = new HashSet<Compra>();
        }

        public Guid IdDescuento { get; set; }
        public string Tipo { get; set; }
        public int PorcientoDeDescuento { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}
