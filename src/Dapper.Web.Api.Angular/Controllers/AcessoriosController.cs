using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dapper.Web.Api.Angular.Models;
using Dapper.Web.Api.Angular.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dapper.Web.Api.Angular.Controllers
{
    public class AcessoriosController : Controller
    {
        private readonly DapperDbContext context;
        private readonly IMapper mapper;
        public AcessoriosController(DapperDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/acessorios")]
        public async Task<IEnumerable<AcessorioResource>> GetAcessorios()
        {
            var acessorios = await context.Acessorios.ToListAsync();
            return mapper.Map<List<Acessorio>, List<AcessorioResource>>(acessorios);
        }
    }
}
