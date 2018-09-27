using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Web.Api.Angular.Models;

namespace Dapper.Web.Api.Angular.Resources
{
    public class MarcaResource
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Modelo> Modelos { get; set; }
        public MarcaResource()
        {
            Modelos = new Collection<Modelo>();
        }
    }
}
