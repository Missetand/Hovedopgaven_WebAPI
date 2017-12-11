using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI_HO.Interfaces;
using WebAPI_HO.Models;

namespace WebAPI_HO.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private HovedOpgavenContext db;

        public CustomerRepository(HovedOpgavenContext context)
        {
            db = context;
        }

        public void Add(Customers item)
        {
            db.Add(item);
            db.SaveChanges();
        }

        public Customers Find(int key) => db.Customers.FirstOrDefault(x => x.CustomerId == key);

        public IEnumerable<Customers> GetAll() => db.Customers;


        public Customers Remove(int key)
        {
            Customers item;
            item = db.Customers.Single(x => x.CustomerId == key);
            db.Remove(item);
            db.SaveChanges();
            return item;
        }

        public void Update(Customers item)
        {
            db.Customers.Update(item);
            db.SaveChanges();
        }
    }
}
