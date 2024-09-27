using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLab.DataAccess.Data
{
    public class ProyectoLabDbContext : DbContext
    {
        public ProyectoLabDbContext(DbContextOptions<ProyectoLabDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProyectoLabDbContext).Assembly);
        }

        //todos estan configurados en el OnModelCreating a maximo 100 caracteres
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<string>()
                .HaveMaxLength(100);
        }
    }
}
