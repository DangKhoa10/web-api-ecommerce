using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppEntity.DTO;
using AppDAL;
using AppBLL.Interfaces;
using AppEntity.Model;
using Microsoft.AspNetCore.Authorization;
using AppAuth.Model;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBizLogic _productBizLogic;

        public ProductController(IProductBizLogic productBizLogic)
        {
            _productBizLogic = productBizLogic;
        }

        [HttpGet]
        [Authorize(Roles = RoleModel.Customer)]
        public async Task<ActionResult> GetProducts()
        {
            try
            {
                var dt = await _productBizLogic.GetProducts();
                return Ok(dt);
            }
            catch
            {
                return BadRequest();
            }
        }

       

        [HttpPost]
        public async Task<ActionResult> AddProducts(ProductDTO model)
        {
            try
            {
                var dt = await _productBizLogic.AddProducts(model);
                return Ok(dt);
            }
            catch
            {
                return BadRequest();
            }
        }

       
    }
}
