using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.Web.Api.Angular.Models
{
    [Table("Modelos")]
    public class Modelo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        public Marca Marca { get; set; }
        public int MarcaId { get; set; }
    }
}
