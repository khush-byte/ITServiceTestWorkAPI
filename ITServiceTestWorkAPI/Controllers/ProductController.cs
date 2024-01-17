using ITServiceTestWorkAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace ITServiceTestWorkAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly List<ProductModel> _products;

        public ProductController()
        {
            _products = new List<ProductModel>();
        }

        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return _products;
        }

        [HttpGet("{id}")]
        public ActionResult<ProductModel> GetById(int id)
        {
            var product = _products.FirstOrDefault(t => t.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public ActionResult<ProductModel> Create(ProductModel product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductModel product)
        {
            var existingProduct = _products.FirstOrDefault(t => t.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.DateIncome = product.DateIncome;
            existingProduct.DateUpdate = product.DateUpdate;
            existingProduct.Percent = product.Percent;
            existingProduct.IncomePrice = product.IncomePrice;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(t => t.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _products.Remove(product);

            return NoContent();
        }
    }
}
