namespace QLCH_BE.Repositories.Base
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> Queries { get; }
        IQueryable<T> FindAll();
        void Create(T model);
        void Update(T model);
        void Delete(T model);
        abstract Task<T> FindByIdAsync(Guid id);
        T? FindById(Guid id);

    }
}
