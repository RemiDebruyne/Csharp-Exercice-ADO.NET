using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciceHotel.Models;
namespace ExerciceHotel.Repositories
{
    internal class ClientRepository : IRepository<Client, int>
    {
        public void Delete(Client entity)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetAll()
        {
            throw new NotImplementedException();
        }

        public Client? GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetOneBySpecification(Func<Client, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Save(Client entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Client entity)
        {
            entity.Save
        }
    }
}
