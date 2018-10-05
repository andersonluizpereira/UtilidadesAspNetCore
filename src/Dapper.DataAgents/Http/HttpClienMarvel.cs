using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Dapper.CrossCuting.Hashs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Dapper.DataAgents.Http
{
    public  class HttpClienMarvel : AHttpClienMarvel
    {
        
        public static dynamic ResultadoMarvel(string Nome, [FromServices] IConfiguration config)
        {
           return IResultadoMarvel(Nome, config);
        }

        public static dynamic ResultadoMarvelGibis(string qtd,[FromServices] IConfiguration config)
        {
           return IResultadoMarvelGibis(qtd,config);
        }

    }

}
