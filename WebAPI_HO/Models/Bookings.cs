using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_HO.Models
{
    public partial class Bookings
    {
        public Bookings()
        {
            Customers = new HashSet<Customers>();
            Pilots = new HashSet<Pilots>();
        }

        public int BookingId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? BookingDate { get; set; }
        [Required]
        public string Place { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public double? EstimatedPrice { get; set; }
        public int? CustomerId { get; set; }
        public int? PilotId { get; set; }

        public Customers Customer { get; set; }
        public Pilots Pilot { get; set; }
        public ICollection<Customers> Customers { get; set; }
        public ICollection<Pilots> Pilots { get; set; }
    }
}
