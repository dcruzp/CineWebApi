using System;
using System.Collections.Generic;

#nullable disable

namespace CineWebApi.DBModels
{
    public partial class Entradas
    {
        public Entradas()
        {
            Compras = new HashSet<Compra>();
        }

        public Guid IdEntrada { get; set; }
        public Guid IdSala { get; set; }
        public Guid IdPelicula { get; set; }
        public DateTime Hora { get; set; }
        public decimal Precio { get; set; }


        public virtual Pelicula IdPeliculaNavigation { get; set; }
        public virtual Sala IdSalaNavigation { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
