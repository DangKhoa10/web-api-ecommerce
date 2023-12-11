using AppBLL.Interfaces;
using AppDAL.Interfaces;
using AppEntity.DTO;
using AppEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBLL.Implements
{
    public class ProductBizLogic : IProductBizLogic
    {
        private readonly IProductRepository _productRepository;

        public ProductBizLogic(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> AddProducts(ProductDTO model)
        {
            return await _productRepository.AddProducts(model);
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
            return await _productRepository.GetProducts();
        }
    }
}
