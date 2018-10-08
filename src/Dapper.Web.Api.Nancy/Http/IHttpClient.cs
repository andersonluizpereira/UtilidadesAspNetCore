using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Dapper.Web.Api.Nancy.Http
{
    public interface IHttpClient
    {
        void ChangeUrlBase(HttpClient.BaseUrl baseUrl);

        Task<string> GetAsync(string url);
        Task<string> GetAsync(string url, CancellationToken cancellationToken);

        Task<HttpResponseMessage> PostAsync(string url, object postContent);
        Task<HttpResponseMessage> PostAsync(string url, object postContent, CancellationToken cancellationToken);

        Task<HttpResponseMessage> PutAsync(string url, object putContent);
        Task<HttpResponseMessage> PutAsync(string url, object putContent, CancellationToken cancellationToken);

        Task<HttpResponseMessage> PatchAsync(string url, object patchContent, CancellationToken cancellationToken);
    }
}
