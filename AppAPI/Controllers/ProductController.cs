using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppEntity.DTO;
using AppDAL;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductDTO()
        {
          if (_context.Products == null)
          {
              return NotFound();
          }
            return await _context.Products.ToListAsync();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductDTO(int id)
        {
          if (_context.Products == null)
          {
              return NotFound();
          }
            var productDTO = await _context.Products.FindAsync(id);

            if (productDTO == null)
            {
                return NotFound();
            }

            return productDTO;
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductDTO(int id, ProductDTO productDTO)
        {
            if (id != productDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(productDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductDTOExists(id))
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

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> PostProductDTO(ProductDTO productDTO)
        {
          if (_context.Products == null)
          {
              return Problem("Entity set 'AppAPIContext.ProductDTO'  is null.");
          }
            _context.Products.Add(productDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductDTO", new { id = productDTO.Id }, productDTO);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDTO(int id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var productDTO = await _context.Products.FindAsync(id);
            if (productDTO == null)
            {
                return NotFound();
            }

            _context.Products.Remove(productDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductDTOExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
