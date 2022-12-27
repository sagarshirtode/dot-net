using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller 
    {
        [HttpGet]
        public async IAsyncEnumerable<ProductMaster> Get()
        {
            ProductMaster data = new ProductMaster();
            data.Id = 1;
            data.Name = "Test";
            data.Description = "Test2";
            data.productCategoria.type = "cat1";
            yield return data;
        }
        [HttpGet("{id:long}")]
        public IActionResult GetById(int id)
        {
            id = id + 100;
            if (id == 12345)
            {
                return NotFound();
            }
            var obj = new ProductMaster();
            var obj2 = new ProductCategoria();
            var obj3 = new List<int>();
            obj3.Add(100);
            obj3.Add(101);
            obj3.Add(102);
            obj3.Add(103);

            DateTime dt = DateTime.Now;
            

            obj.Id = id;
            obj.cDate = dt.Day + "-" +dt.Month + "-" + dt.Year;
            obj.Name = "Test";
            obj.Description = "descrph hgd ihgkjdfhnk";
            obj.role = obj3;

            obj2.type = "hfhfghf";
            obj.productCategoria = obj2;
            //var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

            return Ok(obj);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                    return BadRequest();

                return employee;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }


    }
}
