﻿using System;
using System.Collections.Generic;

#nullable disable

namespace CineWebApi.DBModels
{
    public partial class Socio
    {
        public Guid id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Puntos { get; set; }
    }
}
