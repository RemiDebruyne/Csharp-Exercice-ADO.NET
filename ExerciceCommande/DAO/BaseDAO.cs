using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceCommande.DAO
{
    internal abstract class BaseDAO<T>
    {
        protected string request = "";

        public abstract List<T> GetAll();
        public abstract T? GetOneById(int id);
        public abstract T Save(T element);
        public abstract T Update(T element);
        public abstract T Delte(T element);
        public abstract T Add(T element);
    }
}
