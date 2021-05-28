using AutoMapper;
using CineWebApi.DBModels;
using CineWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineWebApi.Data
{
    public class CineProfile:Profile
    {
        public CineProfile()
        {
            this.CreateMap<Pelicula, PeliculaModels>();
            this.CreateMap<Pelicula, PeliculaModels>().ReverseMap();
        }
    }
}
