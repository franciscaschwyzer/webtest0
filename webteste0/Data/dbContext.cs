using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webteste0.Models;

namespace webteste0.Data
{
    public class dbContext : DbContext
    {
        public dbContext (DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public DbSet<webteste0.Models.Cliente> Cliente { get; set; } = default!;

        public DbSet<webteste0.Models.Inventario> Inventario { get; set; } = default!;

        public DbSet<webteste0.Models.Maquina> Maquina { get; set; } = default!;
    }
}
