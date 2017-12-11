using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_HO.Interfaces;
using WebAPI_HO.Models;

namespace WebAPI_HO.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private HovedOpgavenContext db;

        public BookingRepository(HovedOpgavenContext context)
        {
            db = context;
        }

        public void Add(Bookings item)
        {
            db.Add(item);
            db.SaveChanges();
        }

        public Bookings Find(int key) => db.Bookings.FirstOrDefault(x => x.BookingId == key);

        public IEnumerable<Bookings> GetAll() => db.Bookings;

        public Bookings Remove(int key)
        {
            Bookings item;
            item = db.Bookings.Single(x => x.BookingId == key);
            db.Bookings.Remove(item);
            db.SaveChanges();
            return item;
        }

        public void Update(Bookings item)
        {
            db.Bookings.Update(item);
            db.SaveChanges();
        }
    }
}
