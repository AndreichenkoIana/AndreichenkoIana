using ApiWeb.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ApiWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [LogActionFilter]
    public class MathController:ControllerBase
    {
        [HttpGet(template: "someCalculation")]
        public async Task<ActionResult<int>> Calc(int x)
        {
            var t1 = Task.Run<int>(() =>
            {
                Task.Delay(100).Wait();
                return 10;
            }
            );

            var t2 = Task.Run<int>(() =>
            {
                Task.Delay(100).Wait();
                return 20;
            }
            );
            var x1 = await t1;
            var x2 = await t2;
            return Ok(x1 + x2);
        }


        [HttpGet(template: "Square")]
        public int Square(int x)
        {
            return x * x;
        }

        [HttpGet(template: "Divide")]
        public ActionResult<int> Divide(int x, int y)
        {
            try
            {
                var z = x / y;
                return StatusCode(200, z);
            }
            catch(DivideByZeroException e)
            {
                return BadRequest(e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
