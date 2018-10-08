using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Dapper.Web.Api.Nancy.CrossCuting.Hashs;
using Dapper.Web.Api.Nancy.Entities.Models;
using Dapper.Web.Api.Nancy.Http.Marvel.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Dapper.Web.Api.Nancy.Http.Marvel.DataAgents
{
    public class MarvelDataAgents : HttpClient, IMarvelDataAgents
    {
        public async Task<string> GetFromMagazine(string qtd)
        {
            if (String.IsNullOrEmpty(qtd) || Convert.ToInt32(qtd) > Convert.ToInt32("100") || Convert.ToInt32(qtd) < Convert.ToInt32("1"))
                qtd = "10";
            string ts = DateTime.Now.Ticks.ToString();
            return await this.GetAsync($"comics?ts={ts}&apikey={Config.Configurations.GetSection("MarvelComicsAPI:PublicKey").Value}&hash={Hash.GerarHash(ts, Config.Configurations.GetSection("MarvelComicsAPI:PublicKey").Value, Config.Configurations.GetSection("MarvelComicsAPI:PrivateKey").Value)}&limit={Uri.EscapeUriString(qtd.ToString())}");
        }

        public async Task<string> GetFromPerson(string name)
        {
            if (String.IsNullOrEmpty(name))
                name = "Captain America";
            string ts = DateTime.Now.Ticks.ToString();
            return await this.GetAsync($"characters?ts={ts}&apikey={Config.Configurations.GetSection("MarvelComicsAPI:PublicKey").Value}&hash={Hash.GerarHash(ts, Config.Configurations.GetSection("MarvelComicsAPI:PublicKey").Value, Config.Configurations.GetSection("MarvelComicsAPI:PrivateKey").Value)}&name={Uri.EscapeUriString(name)}");
            
        }
        
    }
}
