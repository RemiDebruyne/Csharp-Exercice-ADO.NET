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
        private DbSet<T> _reppository;

        public HotelContext Context { get; set; }
        public DbSet<T>? Repository { get; set; }
        public GenericRepository()
        {
            _context = new HotelContext();
            Repository = _context.Set<T>();
        }

        public void Delete(T entity)
        {
            T existing = Repository.Find(entity);
            Repository.Remove(existing);
            _context.SaveChanges();

        }

        public List<T> GetAll()
        {
            return Repository.ToList();
        }

        public T? GetOneById(T entity)
        {
            return Repository.Find(entity);
        }

        public T? Get(Expression<Func<T, bool>> predicate)
        {
            return Repository.Where(predicate).FirstOrDefault();
        }



        public void Update(T entity)
        {

            Repository.Update(entity);
            _context.SaveChanges();

        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return Repository.Where(predicate).ToList();
        }

        public void Add(T entity)
        {
            Repository.Add(entity);
            _context.SaveChanges();
        }
    }
}
