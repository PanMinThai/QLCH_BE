using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLCH_BE.Models;
using QLCH_BE.Repositories;

namespace QLCH_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchRepository _repository;
        public BranchController(IBranchRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<List<BranchModel>>> Index()
        {
            var list = await _repository.GetAllBranchesAsync();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BranchModel>> Detail(Guid id)
        {
            var branch = await _repository.GetBranchByIdAsync(id);
            return Ok(branch);
        }
        [HttpPost]
        public async Task<ActionResult> Create(BranchModel model)
        {
            var id = await _repository.CreateBranchAsync(model);
            var branch = await _repository.GetBranchByIdAsync(id);
            return Ok(branch);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _repository.DeleteBranchAsync(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(BranchModel model, Guid id)
        {
            await _repository.UpdateBranchAsync(model,id);
            return Ok();
        }
    }
}
