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
    [Route("api/Customer")]
    public class CustomerController : Controller
    {
        private ICustomerRepository CustomerItems { get; set; }

        public CustomerController(ICustomerRepository customerItems)
        {
            CustomerItems = customerItems;
        }

        // GET: api/Customer
        [HttpGet]
        public IEnumerable<Customers> Get() => CustomerItems.GetAll();

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult Get(int id)
        {
            var item = CustomerItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        
        // POST: api/Customer
        [HttpPost]
        public IActionResult Post([FromBody]Customers value)
        {            
            if (this.ModelState.IsValid)
            {
                CustomerItems.Add(value);
            }
            else
            {
                return BadRequest();
            }
            return CreatedAtRoute("GetCustomer", new { controller = "Customer", id = value.CustomerId }, value);
        }
        
        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Customers value)
        {
            var Customer = CustomerItems.Find(id);
            TryValidateModel(value);
            if (this.ModelState.IsValid)
            {
                CustomerItems.Update(value);
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
            CustomerItems.Remove(id);
        }
    }
}
