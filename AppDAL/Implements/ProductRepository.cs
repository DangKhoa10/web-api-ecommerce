using AppDAL.Interfaces;
using AppEntity.DTO;
using AppEntity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDAL.Implements
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddProducts(ProductDTO dto)
        {
             
            _context.Products.Add(dto);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
