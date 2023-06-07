using AutoMapper;
using Drone.DTO;
using Drone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Drone.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Dron, DronDTO>().ReverseMap();
            CreateMap<Estado, EstadoDTO>().ReverseMap();
            CreateMap<Medicamento, MedicamentoDTO>().ReverseMap();
            CreateMap<Modelo, ModeloDTO>().ReverseMap();
        }
    }
}
