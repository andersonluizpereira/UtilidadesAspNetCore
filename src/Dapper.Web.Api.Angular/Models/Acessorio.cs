using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.Web.Api.Angular.Models
{
    [Table("Acessorios")]
    public class Acessorio
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
    }
}
