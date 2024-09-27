using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using ProyectoLab.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLab.DataAccess.Configurations
{
    public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.Property(m => m.Nombres)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.Apellidos)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(m => m.Especialidad)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.Observaciones)
                .HasMaxLength(500);

            builder.Property(m => m.Telefono)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(m => m.Correo)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.FechaModificacion)
                .IsRequired();
                
           
        }
    }
}
