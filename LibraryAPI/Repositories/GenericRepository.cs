
using LibraryData.Context;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LibraryContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(LibraryContext context)
        {

            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Delete(T entity)
        {
           _dbSet.Remove(entity); ;
        }

        public List<T> GetAll()
        {
            if (typeof(T) == typeof(Book))
            {
                return _dbSet.Include("Authors").Include("Genres").ToList(); // Chỉ thêm Include nếu T là Book
            }
            return _dbSet.ToList();  
        }

        public T GetById(Guid id)
        {

         
            return _dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public bool Save()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public void Update(T entity)
        {
           _context.Set<T>().Update(entity);
        }
    }
}
