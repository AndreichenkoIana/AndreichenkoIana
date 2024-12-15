using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketPlace.Data;
using MarketPlace.Models;

namespace MarketPlace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductGroups : ControllerBase
    {
        [HttpPost(template: "addgroup")]
        public ActionResult AddGroup(string name, string description)
        {
            try
            {
                using (var ctx = new ProductsContext())
                {
                    if (ctx.ProductGroups.Count(x => x.Name.ToLower() == x.Name.ToLower()) > 0)
                    {
                        return StatusCode(409);
                    }
                    else
                    {
                        ctx.ProductGroups.Add(new ProductGroup { Name = name, Description = description });
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

        [HttpGet(template: "getgroups")]
        public ActionResult<IEnumerable<ProductGroupModel>> GetGroups()
        {
            try
            {
                using (var ctx = new ProductsContext())
                {
                    var list = ctx.ProductGroups.Select(x => new ProductGroupModel { Id = x.Id, Name = x.Name, Description = x.Description }).ToList();
                    return list;
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete(template: "deletegroup/{id}")]
        public ActionResult DeleteGroup(int id)
        {
            try
            {
                using (var ctx = new ProductsContext())
                {
                    var group = ctx.ProductGroups.FirstOrDefault(x => x.Id == id);
                    if (group == null)
                    {
                        return NotFound();
                    }

                    ctx.ProductGroups.Remove(group);
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
