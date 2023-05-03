using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace taller_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ShopContext _context;
        
        public ProductController(ShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string? name = "", string? description= "", float? price=null, int?  quantity = null) 
        {
            var products = _context.Products.ToList();
            if (name != "")
                products = products.FindAll(x => x.Name.Equals(name));
            if (description != "")
                products = products.FindAll(x => x.Description.Contains(description));
            if (price != null)
                products = products.FindAll(x => x.Price == price);
            if (quantity != null)
                products = products.FindAll(x => x.Quantity == quantity);
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            Product product1 = _context.Products.ToList().Find(x => x.Name.Equals(product.Name));
            if (product1 == null)
            {
                _context.Products.Add(new Product(product.Name, product.Description, product.Price, product.Quantity));
                _context.SaveChanges();
                return Ok("Product added");
            }
            else
            {
                return BadRequest("Product already exists");
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        { 
            Product product1 = _context.Products.ToList().Find(x => x.Id == product.Id);
            if (product1 != null)
            {
                product1.Name = product.Name;
                product1.Description = product.Description;
                product1.Price = product.Price;
                product1.Quantity = product.Quantity;
                _context.SaveChanges();
                return Ok("Product updated");
            }
            else
            {
                return BadRequest("Product does not exist");
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] string id)
        {
            Product product = _context.Products.ToList().Find(x => x.Id.ToString().Equals(id));
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return Ok("Product deleted");
            }
            else
            {
                return BadRequest("Product does not exist");
            }
        }


    }
}
