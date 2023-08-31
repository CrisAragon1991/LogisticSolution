using LogisticSolution.Data;
using LogisticSolution.Models;
using LogisticSolution.Utils;
using Microsoft.EntityFrameworkCore;

namespace LogisticSolution.Repositories.BaseRepository
{
    public class BaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext dbContext;
        public BaseRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public async Task<T> CreateEntity(T entity)
        {
            await dbContext.AddAsync<T>(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> GetEntityById(int id)
        {
            var entity = await dbContext.FindAsync<T>(new object[] { id });
            if (entity == null) 
            {
                return null;
            }
            return entity;
        }

        public async Task<IEnumerable<T>> GetEntityWithPaginationFilter(PaginationFilter paginationFilter)
        {
            if (paginationFilter.Completed == 1)
            {
                return await dbContext.Set<T>()
                                        .ToListAsync();
            }
            else
            {
                return await dbContext.Set<T>()
                                         .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                                         .Take(paginationFilter.PageSize)
                                         .ToListAsync();
            }
        }

        public async Task<T> UpdateEntity(int id, T entity)
        {
            T oldEntity = await this.GetEntityById(id);
            if (oldEntity == null)
            {
                throw new Exception("Resource Not found");
            }
            dbContext.Entry(oldEntity).CurrentValues.SetValues(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteEntityById(int id)
        {
            T entity = await this.GetEntityById(id);
            if (entity == null)
            {
                return false;
            }
            dbContext.Remove<T>(entity);
            await this.dbContext.SaveChangesAsync();
            return true;
        }
    }
}
