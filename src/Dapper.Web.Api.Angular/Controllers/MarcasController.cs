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
    public class MarcasController : Controller
    {
        private readonly DapperDbContext context;
        private readonly IMapper mapper;
        public MarcasController(DapperDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/marcas")]
        public async Task<IEnumerable<MarcaResource>> GetMarcas()
        {
            var marcas = await context.Marcas.Include(m => m.Modelos).ToListAsync();
            return mapper.Map<List<Marca>, List<MarcaResource>>(marcas);
        }
    }
}
