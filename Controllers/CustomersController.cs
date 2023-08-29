using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProject.Models;
using Microsoft.AspNetCore.Authorization;
using ApiProject.Authentication;
using Humanizer;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ApiProject.Controllers
{
    [Authorize]
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly Project2DBContext _context;

        public CustomersController(Project2DBContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
          if (_context.Customers == null)
          {
              return NotFound();
          }
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(short id)
        {
          if (_context.Customers == null)
          {
              return NotFound();
          }
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(short id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
          if (_context.Customers == null)
          {
              return Problem("Entity set 'Project2DBContext.Customers'  is null.");
          }
            _context.Customers.Add(customer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerExists(customer.CustomerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        // PATCH: api/Customer/5
         [HttpPatch("{id}")]

        
           /* public async Task<IActionResult> PatchCustomer(int id)
         {
             if (id <= 0)
             {
                 return BadRequest();
             }

             var existingCustomer = await _context.Customers.FindAsync(id);
             if (existingCustomer == null)
             {
                 return NotFound();
             }

              if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           

            /* // Update the customer data
             existingCustomer.CustomerId = customer.CustomerId;
             existingCustomer.CustomerTitle = customer.CustomerTitle;
             existingCustomer.CustomerName = customer.CustomerName;
             existingCustomer.CustomerSurname = customer.CustomerSurname;
             existingCustomer.CellPhone = customer.CellPhone;

             //Project2DBContext.Update(existingCustomer);
             await _context.SaveChangesAsync();

             return Ok();

         }*/

       
       
        
 






        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(short id)
{
    if (_context.Customers == null)
    {
        return NotFound();
    }
    var customer = await _context.Customers.FindAsync(id);
    if (customer == null)
    {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(short id)
        {
            return (_context.Customers?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }
    }
}
