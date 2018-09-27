using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.Web.Api.Angular.Models
{
    public class Marca
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        public ICollection<Modelo> Modelos { get; set; }
        public Marca()
        {
            Modelos = new Collection<Modelo>();
        }
    }
}
