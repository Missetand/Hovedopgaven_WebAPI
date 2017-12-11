using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_HO.Models;
using WebAPI_HO.Repositories;
using WebAPI_HO.Interfaces;

namespace WebAPI_HO.Controllers
{
    [Produces("application/json")]
    [Route("api/Booking")]
    public class BookingController : Controller
    {

        private IBookingRepository BookingItems { get; set; }

        public BookingController (IBookingRepository bookingItems)
        {
            BookingItems = bookingItems;
        }

        // GET: api/Booking
        [HttpGet]
        public IEnumerable<Bookings> GetAll() => BookingItems.GetAll();

        // GET: api/Booking/5
        [HttpGet("{id}", Name = "GetBooking")]
        public IActionResult Get(int id)
        {
            var item = BookingItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        
        // POST: api/Booking
        [HttpPost]
        public IActionResult Post([FromBody]Bookings value)
        {
            TryValidateModel(value);
            if (this.ModelState.IsValid)
            {
                BookingItems.Add(value);
            }    
            else
            {
                return BadRequest();
            }
            return CreatedAtRoute("GetBooking", new { controller = "Booking", id = value.BookingId }, value);
        }
        
        // PUT: api/Booking/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Bookings value)
        {
            var Booking = BookingItems.Find(id);

            TryValidateModel(value);
            if (this.ModelState.IsValid)
            {
                BookingItems.Update(value);
            }
            else
            {
                return BadRequest();
            }
            return new NoContentResult();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            BookingItems.Remove(id);
        }
    }
}
