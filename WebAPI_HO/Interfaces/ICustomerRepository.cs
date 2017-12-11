using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_HO.Models;

namespace WebAPI_HO.Interfaces
{
    public interface ICustomerRepository
    {
        void Add(Customers item);

        IEnumerable<Customers> GetAll();

        Customers Find(int key);

        Customers Remove(int key);

        void Update(Customers item);
    }
}
