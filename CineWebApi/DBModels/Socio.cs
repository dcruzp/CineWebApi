using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CineWebApi.DBModels
{
    public partial class Socio
    {
        public Guid IdSocio { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Puntos { get; set; }
        [StringLength(11)]
        public string CI { get; set; }
    }
}
