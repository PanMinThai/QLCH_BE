using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLCH_BE.Models;
using QLCH_BE.Repositories;

namespace QLCH_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeController(EmployeeRepository repository) {  _repository = repository; }
        [HttpGet]
        public async Task<ActionResult<List<EmployeeModel>>> Index() 
        {
            var list = await _repository.GetAllEmployees();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeModel>> Detail(Guid id)
        {
            var employee = await _repository.GetEmployeeById(id);
            return Ok(employee);
        }
        [HttpPost]
        public async Task<ActionResult> Create(EmployeeModel model)
        {
            var id = await _repository.CreateEmployee(model);
            var employee = await _repository.GetEmployeeById(id);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _repository.DeleteEmployee(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(EmployeeModel model, Guid id)
        {
            await _repository.UpdateEmployee(model, id);
            return Ok();
        }
    }
}
