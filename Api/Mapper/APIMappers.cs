using Api.Models;
using Api.Models.DTO;
using AutoMapper;
using System.Data;

namespace Api.Mapper
{
    public class APIMappers : Profile
    {
        public APIMappers()
        {
            CreateMap<Tbl_Humano, Tbl_HumanoDTO>().ReverseMap();
            CreateMap<Tbl_HumanoDTO, Tbl_Humano>().ReverseMap();
        }
    }
}
