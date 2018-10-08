using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Dapper.Web.Api.Nancy.Entities.Models
{
    public static class Config
    {
        public static IConfiguration Configurations { get; set; }
    }
}
