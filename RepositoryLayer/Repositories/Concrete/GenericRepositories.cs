using CoreLayer.BaseEntities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Concrete
{
    public class GenericRepositories<T> : IGenericRepositories<T> where T : class,IBaseEntity,new()
    {
        private readonly AppDBContext _dbContext;
        private readonly DbSet<T> _dbSet; 

        public GenericRepositories(AppDBContext dbContext )
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task AddEntityAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public void UpdateEntity(T entity)
        {
            _dbSet.Update(entity);
        }
        public void DeleteEntity(T entity)
        {
            _dbSet.Remove(entity);
        }
        public IQueryable<T> GetAllEntityList()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }
        public IQueryable<T> Where(Expression <Func<T,bool>> exception)
        {
            return _dbSet.Where(exception);
        }
        public async Task<T?> GetEntityByIdAsync(int id)
        {
           return await _dbSet.FindAsync(id);
        }
    }
}
