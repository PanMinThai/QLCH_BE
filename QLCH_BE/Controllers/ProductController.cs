using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLCH_BE.Models;
using QLCH_BE.Repositories;

namespace QLCH_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductModel>>> Index()
        {
            var list = await _repository.GetAllProducts();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> Detail(Guid id)
        {
            var product = await _repository.GetProductById(id);
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult> Create(ProductModel model)
        {
            var id = await _repository.CreateProduct(model);
            var CreatedProduct = await _repository.GetProductById(id);
            return Ok(CreatedProduct);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _repository.DeleteProduct(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(ProductModel model, Guid id)
        {
            await _repository.UpdateProduct(model,id);
            return Ok();
        }
    }
}
