using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dapper.Web.Api.Nancy.Http.Marvel.Interfaces
{
    public interface IMarvelDataAgents
    {
        Task<string> GetFromPerson(string name);
        Task<string> GetFromMagazine(string qtd);
    }
}
