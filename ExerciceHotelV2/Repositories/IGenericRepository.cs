using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceHotelV2.Repositories
{
    internal interface IGenericRepository<T> where T : class
    {
            void Add(T entity);
            void Save(T entity);
            List<T> GetAll();
            List<T> GetAll(Expression<Func<T, bool>> predicate);

            // Le predicate va nous permetre de créer un filtre spécifique pour notre entité
            List<T> Get(Expression<Func<T, bool>> predicate);
            T? GetOneById(T entity);
            void Update(T entity);
            void Delete(T entity);
    }
}
