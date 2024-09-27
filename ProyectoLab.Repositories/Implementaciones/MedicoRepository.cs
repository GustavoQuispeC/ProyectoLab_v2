using ProyectoLab.DataAccess.Data;
using ProyectoLab.Entities;
using ProyectoLab.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLab.Repositories.Implementaciones
{
    public class MedicoRepository : RepositoryBase<Medico>, IMedicoRepository
    {
        public MedicoRepository(ProyectoLabDbContext context)
        : base(context)
        {
        }

       
    }
}
