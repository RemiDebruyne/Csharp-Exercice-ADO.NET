using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciceHotel.Data;
using ExerciceHotel.Models;

namespace ExerciceHotel.Repositories
{
    internal class ChambreRepository : IRepository<Chambre, int>
    {
        public HotelDbContext Context { get; set; }

        public void Delete(Chambre entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }

        public List<Chambre> GetAll()
        {
            
        }

        public Chambre? GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Chambre> GetOneBySpecification(Func<Chambre, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Save(Chambre entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Chambre entity)
        {
            throw new NotImplementedException();
        }
    }
}
