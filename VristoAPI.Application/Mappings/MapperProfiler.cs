using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VristoAPI.Domain.DTOs;
using VristoAPI.Domain.Entities;

namespace VristoAPI.Application.Mappings
{
    public class MapperProfiler:Profile
    {
        public MapperProfiler()
        {
            CreateMap<Product,ProductDTO>().ReverseMap();
        }
    }
}
