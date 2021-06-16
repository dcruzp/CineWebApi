using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineWebApi.DBModels
{
    public class CompraAsientos
    {
        
        public Guid IdCompra { get; set; }
        public Guid IdAsiento { get; set; }
        public Guid? IdDescuento { get; set; }

        public Descuento IdDescuentoNavigational { get; set; }
        public Asiento IdAsientoNavigational { get; set; }
        public Descuento IdCompraNavigational { get; set; }
    }
}
