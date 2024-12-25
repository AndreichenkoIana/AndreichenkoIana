using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MarketDb.Models;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MarketDb.Data;
using MarketDb.Abstraction;
using MarketDb.Repo;
using MarketDb.DTO;

namespace MarketDb.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class Products : ControllerBase
    {
        private IProductRepository _productRepository;
        public Products(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpPost(template: "addproduct")]
        public ActionResult AddProduct([FromBody] ProductDto productDto)
        {
            var result = _productRepository.AddProduct(productDto);
            return Ok(result);
        }


        [HttpGet(template: "getproducts")]
        public ActionResult<IEnumerable<ProductDto>> GetProducts()
        {
            var list = _productRepository.GetProducts();
            return Ok(list);
        }

        //[HttpPut(template: "updateprice/{id}")]
        //public ActionResult UpdatePrice(int id, decimal price)
        //{
        //    try
        //    {
        //        using (_ctx)
        //        {
        //            var product = _ctx.Procucts.FirstOrDefault(x => x.Id == id);
        //            if (product == null)
        //            {
        //                return NotFound();
        //            }

        //            product.Price = price;

        //            _ctx.SaveChanges();
        //        }

        //        return Ok();
        //    }
        //    catch
        //    {
        //        return StatusCode(500);
        //    }
        //}

        //[HttpDelete(template: "deleteproduct/{id}")]
        //public ActionResult DeleteProduct(int id)
        //{
        //    try
        //    {
        //        using (_ctx)
        //        {
        //            var product = _ctx.Procucts.FirstOrDefault(x => x.Id == id);
        //            if (product == null)
        //            {
        //                return NotFound();
        //            }

        //            _ctx.Procucts.Remove(product);
        //            _ctx.SaveChanges();
        //        }

        //        return Ok();
        //    }
        //    catch
        //    {
        //        return StatusCode(500);
        //    }
        //}
    }
}
