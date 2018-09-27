using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dapper.Web.Api.Angular.Models;
using Dapper.Web.Api.Angular.Resources;

namespace Dapper.Web.Api.Angular.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Marca, MarcaResource>();
            CreateMap<Modelo, ModeloResource>();
            CreateMap<Acessorio, AcessorioResource>();
        }
    }
}
