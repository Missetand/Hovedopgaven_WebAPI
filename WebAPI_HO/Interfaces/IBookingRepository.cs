using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_HO.Models;

namespace WebAPI_HO.Interfaces
{
    public interface IBookingRepository 
    {
        void Add(Bookings item);

        IEnumerable<Bookings> GetAll();

        Bookings Find(int key);

        Bookings Remove(int key);

        void Update(Bookings item);
    }
}
