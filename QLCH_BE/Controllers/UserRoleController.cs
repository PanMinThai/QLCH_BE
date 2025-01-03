using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLCH_BE.Entities.Common;
using QLCH_BE.Modal;
using QLCH_BE.Service;

namespace QLCH_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleServices userRole;
        public UserRoleController(IUserRoleServices roleServicecs) {
            this.userRole = roleServicecs;
        }

        [HttpPost("assignrolepermission")]
        [Authorize(Roles = ApplicationRole.Admin)]
        public async Task<IActionResult> assignrolepermission(List<RolePermissionModel> model)
        {
            var data = await this.userRole.AssignRolePermission(model);
            return Ok(data);
        }

        [HttpGet("GetAllRoles")]
        [Authorize(Roles = ApplicationRole.Admin)]
        public async Task<IActionResult> GetAllRoles()
        {
            var data = await this.userRole.GetAllRoles();
            if(data==null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("GetAllMenus")]
        [Authorize(Roles = ApplicationRole.Admin)]
        public async Task<IActionResult> GetAllMenus()
        {
            var data = await this.userRole.GetAllMenus();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("GetAllMenusByRole")]
        [Authorize(Roles = ApplicationRole.Admin)]
        public async Task<IActionResult> GetAllMenusByRole(Guid RoleId)
        {
            var data = await this.userRole.GetAllMenuByRole(RoleId);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("GetMenuPermissionByRole")]
        [Authorize(Roles = ApplicationRole.Admin)]
        public async Task<IActionResult> GetMenuPermissionByRole(Guid RoleId, Guid MenuId)
        {
            var data = await this.userRole.GetMenuPermissionByRole(RoleId, MenuId);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    
    }
}
