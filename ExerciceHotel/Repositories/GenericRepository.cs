using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ExerciceHotel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ExerciceHotel.Repositories
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //Pourquoi déclaré en null ?
        private HotelDbContext _context = null;
        private DbSet<T> _table = null;

        public HotelDbContext Context { get; set; }
        public DbSet<T>? Table { get; set; }


        public GenericRepository()
        {
            _context = new HotelDbContext();
            //Whatever class name we specify while creating the instance of GenericRepository
            //That class name will be stored in the Table variable
            Table = _context.Set<T>();
        }
        //Using the Parameterized Constructor, 
        //we are initializing the context object and Table variable
        public GenericRepository(HotelDbContext context)
        {
            this._context = _context;
            Table = _context.Set<T>();
        }

        //This method will return all the Records from the Table
        public IEnumerable<T> GetAll()
        {
            return Table.ToList();
        }
        //This method will return the specified record from the Table
        //based on the ID which it received as an argument
        public T GetById(object id)
        {
            return Table.Find(id);
        }
        //This method will Insert one object into the Table
        //It will receive the object as an argument which needs to be inserted into the database
        public void Insert(T obj)
        {
            //It will mark the Entity state as Added State
            Table.Add(obj);
        }
        //This method is going to update the record in the Table
        //It will receive the object as an argument
        public void Update(T obj)
        {
            //First attach the object to the Table
            Table.Attach(obj);
            //Then set the state of the Entity as Modified
            _context.Entry(obj).State = EntityState.Modified;
        }
        //This method is going to remove the record from the Table
        //It will receive the primary key value as an argument whose information needs to be removed from the Table
        public void Delete(object id)
        {
            //First, fetch the record from the Table
            T existing = Table.Find(id);
            //This will mark the Entity State as Deleted
            Table.Remove(existing);
        }
        //This method will make the changes permanent in the database
        //That means once we call Insert, Update, and Delete Methods, 
        //Then we need to call the Save method to make the changes permanent in the database
        public void Save()
        {
            _context.SaveChanges();
        }
    }

}