using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLCH_BE.Entities.Common;
using QLCH_BE.Repositories;

namespace QLCH_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IPermissionRepository _repository;

        public RoleController( IPermissionRepository repository)
        {
            _repository = repository;
        }
        [Authorize(Roles = ApplicationRole.Admin)]
        [HttpPost("GrantRole")]
        public async Task<IActionResult> GrantRole([FromForm] Guid userId, [FromForm] Guid roleId)
        {
            //userId = Guid.Parse("2be6135a-0776-46fd-9a8b-11c383af620e");
            //roleId = Guid.Parse("e9e25901-0d84-4405-a522-5328fccc2e13");
            var result = await _repository.GrantRoleToUserAsync(userId, roleId);
            if (result.Succeeded)
                return Ok("Role granted successfully.");

            return BadRequest("Failed to grant role.");
        }
    }
}
