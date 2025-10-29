using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Infrastructure.Data;

namespace SmartClinicalSystem.Infrastructure.Common
{
    public class Repository(SmartClinicalSystemDbContext context) : IRepository
    {
        private DbSet<T> DbSet<T>() where T : class => context.Set<T>();

        public IQueryable<T> All<T>() where T : class => DbSet<T>();

        public IQueryable<T> AllReadOnly<T>() where T : class => DbSet<T>().AsNoTracking();

        public async Task AddAsync<T>(T entity) where T : class => await context.AddAsync(entity);

        public EntityEntry Delete<T>(T entity) where T : class => context.Remove(entity);

        public void RemoveRange<T>(IEnumerable<T> entities) where T : class => context.RemoveRange(entities);

        public async Task<int> SaveChangesAsync() => await context.SaveChangesAsync();

        public async Task<T?> GetByIdAsync<T>(object id) where T : class => await DbSet<T>().FindAsync(id);
    }
}
