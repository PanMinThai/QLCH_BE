using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLCH_BE.Models;
using QLCH_BE.Repositories;

namespace QLCH_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierRepository _repository;
        public SupplierController(ISupplierRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<List<SupplierModel>>> Index() 
        {
            var list = await _repository.GetAllSuppliers();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierModel>> Detail(Guid id)
        {
            var suplier = await _repository.GetSuppliersById(id);
            return Ok(suplier);
        }
        [HttpPost]
        public async Task<ActionResult> Create(SupplierModel model)
        {
            var id = await _repository.CreateSupplier(model);
            var supplier = await _repository.GetSuppliersById(id);
            return Ok(supplier);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _repository.DeleteSupplier(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(SupplierModel model, Guid id)
        {
            await _repository.UpdateSupplier(model, id);
            return Ok();
        }
    }
}
