using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineWebApi.Models
{
    public class EntradaQueryModels
    {
        public int minPrice { get; set; } = 0;
        public int maxPrice { get; set; } = int.MaxValue;
        public DateTime minDatetime { get; set; } = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
        public DateTime maxDatetime { get; set; } = DateTime.MaxValue;

        public Guid idPelicula { get; set; }
        public string nombrePelicula { get; set; }

        public Guid idSala { get; set; }
        public string nombreSala { get; set;  }
    }
}
