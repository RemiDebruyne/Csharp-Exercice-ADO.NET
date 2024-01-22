using ExerciceHotelV2.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceHotelV2.Repositories
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private HotelContext _context;
        private DbSet<T> _table;

        public HotelContext Context { get; set; }
        public DbSet<T>? Table { get; set; }
        public GenericRepository()
        {
            _context = new HotelContext();
            Table = _context.Set<T>();
        }

        public void Delete(T entity)
        {
            T existing = Table.Find(entity);
            Table.Remove(existing);
        }

        public List<T> GetAll()
        {
            return Table.ToList();
        }

        public T? GetOneById(T entity)
        {
            return Table.Find(entity);
        }

        public List<T> GetOneBySpecification(Func<T, bool> predicate)
        {
            return Table.Where(predicate).ToList();
        }

        public void Save(T entity)
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            Table.Update(entity);
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<T> Get(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            Table.Add(entity);
        }
    }
}
