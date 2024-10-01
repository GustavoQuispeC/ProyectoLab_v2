using ProyectoLab.DataAccess.Data;
using ProyectoLab.Entities;
using ProyectoLab.Repositories.Implementaciones;
using ProyectoLab.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLab.Repositories.Implementaciones
{
    public class PacienteRepository : RepositoryBase<Paciente>, IPacienteRepository
    {
        public PacienteRepository(ProyectoLabDbContext context)
        : base(context)
        {
        }
    }
      
    
}

