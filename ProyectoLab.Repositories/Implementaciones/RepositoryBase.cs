using Microsoft.EntityFrameworkCore;
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
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        public readonly ProyectoLabDbContext _context;

        public RepositoryBase(ProyectoLabDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<TEntity>> ListAsync()
        {
            return await _context.Set<TEntity>()
                .Where(p =>p.Estado == true)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TEntity?> FindAsync(int id)
        {
            return await _context.Set<TEntity>()
                .FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            
        }

        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var registro = await FindAsync(id);
            if(registro != null)
            {
               registro.Estado = false;
                await UpdateAsync();
            }
        }

       

      

        public Task<ICollection<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

       
    }
}
