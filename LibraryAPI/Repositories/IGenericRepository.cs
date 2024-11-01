namespace LibraryAPI.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool Save();
    }
}
