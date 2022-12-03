using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiCSharp.Model.Entities;

namespace ApiCSharp.Data
{
    public class VeiculoContext : DbContext
    {
        public VeiculoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Veiculo> Veiculos { get; set; }
    }
}