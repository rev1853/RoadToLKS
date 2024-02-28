using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EsemkaStoreAPI.Models;
using EsemkaStoreAPI.DTOs;

namespace EsemkaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly EsemkaStoreContext _context;

        public ProductController(EsemkaStoreContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductDTO product)
        {
            try
            {
                var result = _context.Products.Update(new Product
                {
                    Id = id,
                    Name = product.Name,
                    Brand = product.Brand,
                    Stock = product.Stock,
                    Price = product.Price,
                    CategoryId = product.CategoryID
                });
                await _context.SaveChangesAsync();

                return Ok(result.Entity);
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
        }

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductDTO product)
        {
            var result = _context.Products.Update(new Product
            {
                Name = product.Name,
                Brand = product.Brand,
                Stock = product.Stock,
                Price = product.Price,
                CategoryId = product.CategoryID
            });
            await _context.SaveChangesAsync();

            return Ok(result.Entity);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
