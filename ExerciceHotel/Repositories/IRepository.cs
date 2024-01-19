using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceHotel.Repositories
{
    internal interface IRepository<T, Tid> where T : new()
    {
        void Save(T entity);
        List<T> GetAll();

        // Le predicate va nous permetre de créer un filtre spécifique pour notre entité
        List<T> GetOneBySpecification(Func<T, bool> predicate);
        T? GetOneById(Tid id);
        void Update(T entity);
        void Delete(T entity);
    }
}
