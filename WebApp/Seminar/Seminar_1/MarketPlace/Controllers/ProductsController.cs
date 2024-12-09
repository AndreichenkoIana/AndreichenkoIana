using MarketPlace.Data;
using MarketPlace.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MarketPlace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Products : ControllerBase
    {
        [HttpPost(template: "addproduct")]
        public ActionResult AddProduct(string name, string description, int groupId, string price)
        {
            try
            {
                using (var ctx = new ProductsContext())
                {
                    if (ctx.Procucts.Count(x => x.Name.ToLower() == name.ToLower()) > 0)
                    {
                        return StatusCode(409);
                    }
                    else
                    {
                        ctx.Procucts.Add(new Product { Name = name, Description = description, ProductGroupId = groupId, Price = price });
                        ctx.SaveChanges();
                    }
                }

                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }


        [HttpGet(template: "getproducts")]
        public ActionResult<IEnumerable<ProductModel>> GetProducts()
        {
            try
            {
                using (var ctx = new ProductsContext())
                {
                    var list = ctx.Procucts.Select(x => new ProductModel { Id = x.Id, Name = x.Name, Description = x.Description, GroupName = x.ProductGroup.Name, Price = x.Price }).ToList();
                    return list;
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut(template: "updateprice/{id}")]
        public ActionResult UpdatePrice(int id, string price)
        {
            try
            {
                using (var ctx = new ProductsContext())
                {
                    var product = ctx.Procucts.FirstOrDefault(x => x.Id == id);
                    if (product == null)
                    {
                        return NotFound();
                    }

                    product.Price = price;

                    ctx.SaveChanges();
                }

                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete(template: "deleteproduct/{id}")]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                using (var ctx = new ProductsContext())
                {
                    var product = ctx.Procucts.FirstOrDefault(x => x.Id == id);
                    if (product == null)
                    {
                        return NotFound();
                    }

                    ctx.Procucts.Remove(product);
                    ctx.SaveChanges();
                }

                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
