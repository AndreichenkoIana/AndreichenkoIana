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
        private readonly IProductRepository _productRepository;

        public Products(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        private string GetCsv(IEnumerable<ProductDto> products)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var product in products)
            {
                sb.AppendLine(product.Id + ";" + product.Name + ";" + product.Description + ";" + product.Price + "\n");
            }
            return sb.ToString();
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

        // Метод для возврата CSV-файла с товарами
        [HttpGet("getproductscsv")]
        public IActionResult GetProductsCsv()
        {
            var products = _productRepository.GetProducts();
            var content = GetCsv(products);

            // Создание CSV-файла в памяти
            //var csvBuilder = new StringBuilder();
            //csvBuilder.AppendLine("Id,Name,Price"); // Заголовки столбцов

            //foreach (var product in products)
            //{
            //    csvBuilder.AppendLine($"{product.Id},{product.Name},{product.Price}");
            //}

            var csvData = Encoding.UTF8.GetBytes(content);
            var fileName = "products" + DateTime.Now.ToBinary().ToString() + ".csv";
            System.IO.File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles", fileName), content);
            // Возвращаем файл
            return File(csvData, "text/csv", fileName);

        }

        // Метод для предоставления статичного файла со статистикой работы кэша
        [HttpGet("cache-stats")]
        public IActionResult GetCacheStats()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles", "cache-stats.json");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("Статистика кэша не найдена.");
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/json", "cache-stats.json");
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
