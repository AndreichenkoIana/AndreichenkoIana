using MarketDb.Abstraction;
using MarketDb.Data;
using MarketDb.DTO;
using MarketDb.Models;
using MarketDb.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace MarketDb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductGroups : ControllerBase
    {
        private IGroupRepository _groupRepository;
        public ProductGroups(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        [HttpPost(template: "addgroup")]
        public ActionResult AddGroup([FromBody] ProductGroupDto productGroupDto)
        {
            var result = _groupRepository.AddGroup(productGroupDto);
            return Ok(result);
        }

        [HttpGet(template: "getgroups")]
        public ActionResult<IEnumerable<ProductGroupDto>> GetGroups()
        {
            var list = _groupRepository.GetGroups();
            return Ok(list);
        }

        //[HttpDelete(template: "deletegroup/{id}")]
        //public ActionResult DeleteGroup(int id)
        //{
        //    try
        //    {
        //        using (_ctx)
        //        {
        //            var group = _ctx.ProductGroups.FirstOrDefault(x => x.Id == id);
        //            if (group == null)
        //            {
        //                return NotFound();
        //            }

        //            _ctx.ProductGroups.Remove(group);
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
