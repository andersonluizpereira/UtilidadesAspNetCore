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
    public abstract class AHttpClienMarvel
    {

        public static dynamic IResultadoMarvel(string Nome, [FromServices] IConfiguration config)
        {
            if (String.IsNullOrEmpty(Nome))
                Nome = "Captain America";

            var urlResp = MontarUrl(config);

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                string ts = DateTime.Now.Ticks.ToString();
                string publicKey = config.GetSection("MarvelComicsAPI:PublicKey").Value;
                string hash = Hash.GerarHash(ts, publicKey,
                                             config.GetSection("MarvelComicsAPI:PrivateKey").Value);

                HttpResponseMessage response = client.GetAsync(
                    config.GetSection("MarvelComicsAPI:BaseURL").Value +
                    $"characters?ts={ts}&apikey={publicKey}&hash={hash}&" +
                    $"name={Uri.EscapeUriString(Nome)}").Result;



                return JsonConvert.DeserializeObject(response.EnsureSuccessStatusCode().Content.ReadAsStringAsync().Result);

            }
        }

        private static HttpClient MontarUrl(IConfiguration config)
        {
            var client = new HttpClient();

            throw new NotImplementedException();
        }

        public static dynamic IResultadoMarvelGibis(string qtd, [FromServices] IConfiguration config)
        {
            if (String.IsNullOrEmpty(qtd) || Convert.ToInt16(qtd) > Convert.ToInt16("100"))
                qtd = "10";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                string ts = DateTime.Now.Ticks.ToString();
                string publicKey = config.GetSection("MarvelComicsAPI:PublicKey").Value;
                string hash = Hash.GerarHash(ts, publicKey,
                                             config.GetSection("MarvelComicsAPI:PrivateKey").Value);

                HttpResponseMessage response = client.GetAsync(
                    config.GetSection("MarvelComicsAPI:BaseURL").Value +
                    $"comics?ts={ts}&apikey={publicKey}&hash={hash}&" +
                    $"limit={Uri.EscapeUriString(qtd.ToString())}").Result;

                return JsonConvert.DeserializeObject(response.EnsureSuccessStatusCode().Content.ReadAsStringAsync().Result);
                
            }
        }
    }
}
