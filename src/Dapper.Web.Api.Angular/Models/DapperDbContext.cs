using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dapper.Web.Api.Angular.Models
{
    public class DapperDbContext : DbContext
    {
        public DapperDbContext(DbContextOptions<DapperDbContext> options)
            : base(options)
        { }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Acessorio> Acessorios { get; set; }
    }
}
