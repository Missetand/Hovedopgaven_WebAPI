using System;
using System.Collections.Generic;

namespace WebAPI_HO.Models
{
    public partial class Pilots
    {
        public Pilots()
        {
            Bookings = new HashSet<Bookings>();
        }

        public int PilotId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? BookingId { get; set; }

        public Bookings Booking { get; set; }
        public ICollection<Bookings> Bookings { get; set; }
    }
}
