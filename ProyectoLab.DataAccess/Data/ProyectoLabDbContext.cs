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
        
    }
}
