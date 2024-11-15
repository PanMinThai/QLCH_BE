using Microsoft.AspNetCore.Identity;
using QLCH_BE.Entities.Objects;

namespace QLCH_BE.Repositories
{
    public interface IPermissionRepository
    {
        Task<IdentityResult> GrantRoleToUserAsync(Guid userId, Guid roleId);
    }

    public class PermissionRepository : IPermissionRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public PermissionRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> GrantRoleToUserAsync(Guid userId, Guid roleId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return IdentityResult.Failed();

            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role == null)
                return IdentityResult.Failed();

            var currentRoles = await _userManager.GetRolesAsync(user);
            foreach (var currentRole in currentRoles)
            {
                await _userManager.RemoveFromRoleAsync(user, currentRole);
            }

            if (!await _userManager.IsInRoleAsync(user, role.Name))
                return await _userManager.AddToRoleAsync(user, role.Name);

            return IdentityResult.Success;
        }
    }
}
