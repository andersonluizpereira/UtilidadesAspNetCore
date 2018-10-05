using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Models.Entities
{
    public static class Config
    {
        public static IConfiguration Configurations { get; set; }
    }
}
