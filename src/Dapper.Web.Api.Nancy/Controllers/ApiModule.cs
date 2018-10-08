using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Dapper.Web.Api.Nancy.CrossCuting.Hashs;
using Dapper.Web.Api.Nancy.Entities.Models;
using Dapper.Web.Api.Nancy.Http.Marvel.DataAgents;
using Nancy;
using Newtonsoft.Json;

namespace Dapper.Web.Api.Nancy.Controllers
{
    public class ApiModule : NancyModule
    {
        public ApiModule()
        {
            var marvel = new MarvelDataAgents();
            var http = new Http.HttpClient();

            Get("/", args => JsonConvert.SerializeObject("Hello Marvel"));
            Get("/api/Personagem/{Nome}", args => JsonConvert.SerializeObject(marvel.GetFromPerson(args.Nome)));
            Get("/api/Personagem/paginas/{Qtd}", args => JsonConvert.SerializeObject(marvel.GetFromMagazine(args.Qtd)));
        }
    }
}
