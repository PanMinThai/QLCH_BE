using QLCH_BE.Entities.AccountManagement;
using QLCH_BE.Helper;
using QLCH_BE.Modal;
using QLCH_BE.Models.AccountManagement;

namespace QLCH_BE.Service
{
    public interface IUserRoleServices
    {
        Task<APIResponse> AssignRolePermission(List<RolePermissionModel> _data);
        Task<List<RoleModel>> GetAllRoles();
        Task<List<MenuModel>> GetAllMenus();
        Task<List<MenuModel>> GetAllMenuByRole(Guid RoleId);
        Task<MenuPermission> GetMenuPermissionByRole(Guid RoleId, Guid MenuId);
    }
}
    