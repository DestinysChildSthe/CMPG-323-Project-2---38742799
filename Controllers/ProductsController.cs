﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProject.Models;
using Microsoft.AspNetCore.Authorization;
using ApiProject.Authentication;

namespace ApiProject.Controllers
{
    //[Authorize]
    //[Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly Project2DBContext _context;

        public ProductsController(Project2DBContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
          if (_context.Products == null)
          {
              return NotFound();
          }
            return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(short id)
        {
          if (_context.Products == null)
          {
              return NotFound();
          }
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }


        // GET: api/OrderDetails/5/products
        [HttpGet("{orderId}/products")]
        public async Task<ActionResult<Product>> GetProductsForOrder(short id)
        {
            //var order = _context.OrderDetails.Include(od => od.Products)
               // .FirstOrDefault(od => od.OrderId == orderId);

            if (_context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

          

            return product;
        }




        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(short id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
          if (_context.Products == null)
          {
              return Problem("Entity set 'Project2DBContext.Products'  is null.");
          }
            _context.Products.Add(product);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductExists(product.ProductId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // PATCH: api/Product
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchProduct(int id, [FromBody] Product updatedproduct)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            // Update the product data
            existingProduct.ProductId = updatedproduct.ProductId;
            existingProduct.ProductName = updatedproduct.ProductName;
            existingProduct.ProductDescription = updatedproduct.ProductDescription;
            existingProduct.UnitsInStock = updatedproduct.UnitsInStock;
            

            //Project2DBContext.Update(existingCustomer);
            await _context.SaveChangesAsync();

            return Ok();
        }
       

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(short id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(short id)
        {
            return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }

        // GET: api/Products/order/5
        [HttpGet("product/{productId}")]
        public IActionResult GetProductsForOrder(int orderId)
        {
            var products = _context.Orders
                .Where(product => product.OrderId == orderId)
                .ToList();

            if (products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }
    }
}
