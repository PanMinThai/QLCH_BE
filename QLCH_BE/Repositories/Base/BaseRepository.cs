
using Microsoft.EntityFrameworkCore;

namespace QLCH_BE.Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public IQueryable<T> Queries { get; }
        public StoreManagementDbContext RepositoryContext {  get; set; }
        public BaseRepository(StoreManagementDbContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
            Queries = RepositoryContext.Set<T>().AsQueryable();
        }

        public void Create(T model) => RepositoryContext.Set<T>().Add(model);
        public void Delete(T model) => RepositoryContext.Set<T>().Remove(model);
        public void Update(T model) => RepositoryContext?.Set<T>().Update(model);

        public IQueryable<T> FindAll() => RepositoryContext.Set<T>().AsNoTracking();

        public T? FindById(Guid id) => RepositoryContext.Set<T>().Find(id);
        public async Task<T> FindByIdAsync(Guid id) => await RepositoryContext.Set<T>().FindAsync(id);
    }
}
