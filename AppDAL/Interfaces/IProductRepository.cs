using AppEntity.DTO;
using AppEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDAL.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductDTO>> GetProducts();
        Task<bool> AddProducts(ProductDTO dto);

    }
}
