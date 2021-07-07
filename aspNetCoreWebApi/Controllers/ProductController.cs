using aspNetCoreWebApi.Models1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace aspNetCoreWebApi.Controllers
{
    [ApiController]
    [Consumes("application/xml")]
    [Route("api/[controller]")]

    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/Product
        /// <summary>
        /// Get specific Products.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products
                .Select(x => productTo(x))
                .ToListAsync();
        }

        // Get: api/Product/{id}
        /// <summary>
        /// Get a specific Product.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(long id)
        {
            var prd = await _context.Products.FindAsync(id);

            if (prd == null)
            {
                return NotFound();
            }

            return productTo(prd);
        }

        // Put: api/Product/{id}
        /// <summary>
        /// Change a specific Product.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(long id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            var prd = await _context.Products.FindAsync(id);
            if (prd == null)
            {
                return NotFound();
            }

            prd.Name = product.Name;
            prd.Description = product.Description;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ProductExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/TodoItems
        /// <summary>
        /// Add a specific TodoItem.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Product>> CreateTodoItem(Product product)
        {
            var prd = new Product
            {
                Description = product.Description,
                Name = product.Name
            };

            _context.Products.Add(prd);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetProduct),
                new { id = prd.Id },
                productTo(prd));
        }

        // DELETE: api/TodoItems/{id}
        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            var prd = await _context.Products.FindAsync(id);

            if (prd == null)
            {
                return NotFound();
            }

            _context.Products.Remove(prd);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool ProductExists(long id) =>
         _context.Products.Any(e => e.Id == id);

        private static Product productTo(Product product) =>
            new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description
            };
    }


}
