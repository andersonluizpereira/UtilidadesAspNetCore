using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.DataAgents.Http;
using Dapper.Models.Entities;
using Nancy;
using Newtonsoft.Json;

namespace Dapper.Web.Api.Nancy.Controllers
{
    public class ApiModule : NancyModule
    {
        public ApiModule()
        {
            Get("/", args => JsonConvert.SerializeObject("Hello Marvel"));
            Get("/api/Personagem/{Nome}", args => JsonConvert.SerializeObject(HttpClienMarvel.ResultadoMarvel(args.Nome, Config.Configurations)));
            Get("/api/Personagem/paginas/{Qtd}", args => JsonConvert.SerializeObject(HttpClienMarvel.ResultadoMarvelGibis(args.Qtd, Config.Configurations)));
        }
    }
}
