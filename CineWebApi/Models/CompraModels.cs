using CineWebApi.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineWebApi.Models
{
    public class CompraModels
    {
        public Entradas entradas { get; set; }
        List<CompraAsientos> compraAsientos { get; set; }
    }
}
