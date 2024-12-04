using Microsoft.AspNetCore.Mvc;

namespace ApiWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrudController: ControllerBase
    {
        static Dictionary<string, string> data = new Dictionary<string, string>();
        [HttpPost(template:"post")]
        public ActionResult Post(string key, string value)
        {
            try
            {
                data.Add(key, value);
                return Ok();
            }
            catch
            {
                return StatusCode(409);
            }
        }

        [HttpPost(template: "get")]
        public ActionResult Get(string key)
        {
            if (data.ContainsKey(key))
            {
                return Ok(data[key]);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost(template: "put")]
        public ActionResult Put(string key, string value)
        {
            if (data.ContainsKey(key))
            {
                data[key] = value;
            }
            else
            {
                data.Add(key, value);
            }
            return Ok();
        }

        [HttpPost(template: "patch")]
        public ActionResult Patch(string key, string value)
        {
            if (data.ContainsKey(key))
            {
                data[key] = value;
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost(template: "delete")]
        public ActionResult Delete(string key)
        {
            if (data.ContainsKey(key))
            {
                data.Remove(key);
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

    }
}
