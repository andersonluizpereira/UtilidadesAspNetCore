using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper.Web.Api.Nancy.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Dapper.Web.Api.Nancy.Http
{
    public class HttpClient : IHttpClient
    {
        public string BaseUrlEndPoint { get; private set; }
        public string ContentJsonPoint { get; private set; }

        internal readonly string AccountNamePoint;
        internal readonly string EnvironmentPoint;
        internal readonly string ApiKeyPoint;
        internal readonly string ApiTokenPoint;
      

        private IConfiguration _config;


        public enum BaseUrl
        {
            RestMarvel = 0
        }

        //static HttpClient()
        //{
        //    ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        //}

         public HttpClient()
        {
            this._config = Config.Configurations;
            this.ChangeUrlBase(BaseUrl.RestMarvel);
        }

        public void ChangeUrlBase(HttpClient.BaseUrl baseUrl)
        {
            switch (baseUrl)
            {

                 case BaseUrl.RestMarvel:
                    this.BaseUrlEndPoint = _config.GetSection("MarvelComicsAPI:BaseURL").Value;
                    this.ContentJsonPoint = _config.GetSection("HttpClient:ValueContentJson").Value;
                    break;
            }
        }

        public Task<string> GetAsync(string url)
        {
            return this.GetAsync(url, new CancellationToken(false));
        }

        public Task<string> GetAsync(string url, CancellationToken cancellationToken)
        {
            using (var client = new System.Net.Http.HttpClient())

            {
                client.BaseAddress = new Uri(this.BaseUrlEndPoint);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return client.GetAsync(url, cancellationToken).Result.Content.ReadAsStringAsync();
               
            }
        }

        public Task<HttpResponseMessage> PatchAsync(string url, object patchContent, CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), new Uri(this.BaseUrlEndPoint + url))
            {
                Content = new StringContent(JsonConvert.SerializeObject(patchContent), Encoding.UTF8, this.ContentJsonPoint)
            };

            using (var client = new System.Net.Http.HttpClient())
            {
                client.DefaultRequestHeaders.Add("accept", this.ContentJsonPoint);
                return client.SendAsync(request, cancellationToken);
                
            }
        }

        public Task<HttpResponseMessage> PostAsync(string url, object postContent)
        {
            return this.PostAsync(url, postContent, CancellationToken.None);
        }

        public Task<HttpResponseMessage> PostAsync(string url, object postContent, CancellationToken cancellationToken)
        {
            var body = new StringContent(JsonConvert.SerializeObject(postContent), Encoding.UTF8, this.ContentJsonPoint);
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(this.BaseUrlEndPoint);
                client.DefaultRequestHeaders.Add("accept", this.ContentJsonPoint);
                return client.PostAsync(url, body, cancellationToken);
            }
        }

        public Task<HttpResponseMessage> PutAsync(string url, object putContent)
        {
            return this.PutAsync(url, putContent, CancellationToken.None);
        }

        public Task<HttpResponseMessage> PutAsync(string url, object putContent, CancellationToken cancellationToken)
        {
            var body = new StringContent(JsonConvert.SerializeObject(putContent), Encoding.UTF8, this.ContentJsonPoint);
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(this.BaseUrlEndPoint);
                client.DefaultRequestHeaders.Add("accept", this.ContentJsonPoint);
                
                return client.PutAsync(url, body, cancellationToken);
            }
        }
    }
}
