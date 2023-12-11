using AppEntity.DTO;
using AppEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBLL.Interfaces
{
    public interface IProductBizLogic
    {
        Task<List<ProductDTO>> GetProducts();
        Task<bool> AddProducts(ProductDTO model);
    }
}
