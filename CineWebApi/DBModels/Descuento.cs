using System;
using System.Collections.Generic;

#nullable disable

namespace CineWebApi.DBModels
{
    public partial class Descuento
    {
        public Guid id { get; set; }
        public string Tipo { get; set; }
        public int PorcientoDeDescuento { get; set; }
    }
}
