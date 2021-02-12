using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyIdentityServer.Api1.Model;

namespace UdemyIdentityServer.Api1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [Authorize(Policy = "ReadProduct")]
        [HttpGet]
        public IActionResult GetProducts()
        {
            var productList = new List<Product>()
            {
                new Product{ Id=1,Name="Kale",Price=300,Stock=500},
                new Product{ Id=2,Name="sİLGİ",Price=200,Stock=500},
                new Product{ Id=3,Name="Uç",Price=100,Stock=500},
                new Product{ Id=4,Name="Defter",Price=100,Stock=500}
            };

            return Ok(productList);
        }

        [Authorize(Policy = "UpdateOrCreate")]
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            return Ok($"id'si {id} olan ürün güncellendi");
        }
        [Authorize(Policy = "UpdateOrCreate")]
        [HttpGet]
        public IActionResult CreateProduct(Product product)
        {
            return Ok(product);
        }
    }
}
