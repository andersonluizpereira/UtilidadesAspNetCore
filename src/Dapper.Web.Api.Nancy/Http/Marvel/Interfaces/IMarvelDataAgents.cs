using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dapper.Web.Api.Nancy.Http.Marvel.Interfaces
{
    public interface IMarvelDataAgents
    {
        Task<HttpResponseMessage> GetFromPerson(string name);
        Task<HttpResponseMessage> GetFromMagazine(string qtd);
    }
}
