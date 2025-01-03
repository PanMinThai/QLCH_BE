using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QLCH_BE.Entities.AccountManagement;
using QLCH_BE.Entities.Common;
using QLCH_BE.Helper;
using QLCH_BE.Modal;
using QLCH_BE.Models.AccountManagement;
using QLCH_BE.Service;

namespace QLCH_BE.Container
{
    public class UserRoleService : IUserRoleServices
    {
        private readonly StoreManagementDbContext _context;
        private readonly IMapper _mapper;
        public UserRoleService(StoreManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<APIResponse> AssignRolePermission(List<RolePermissionModel> rolePermissions)
        {
            var response = new APIResponse();
            try
            {
                if (rolePermissions == null || !rolePermissions.Any())
                {
                    response.Result = "fail";
                    response.Message = "No data provided.";
                    return response;
                }

                using var dbTransaction = await _context.Database.BeginTransactionAsync();

                foreach (var item in rolePermissions)
                {
                    // Tìm dữ liệu hiện có
                    var existingPermission = await _context.RolePermissions
                        .FirstOrDefaultAsync(rp => rp.RoleId == item.RoleId && rp.MenuId == item.MenuId);

                    if (existingPermission != null)
                    {
                        // Cập nhật quyền
                        _mapper.Map(item, existingPermission);
                    }
                    else
                    {
                        // Thêm mới quyền
                        var newPermission = _mapper.Map<RolePermission>(item);
                        await _context.RolePermissions.AddAsync(newPermission);
                    }
                }

                await _context.SaveChangesAsync();
                await dbTransaction.CommitAsync();

                response.Result = "pass";
                response.Message = "Permissions assigned successfully.";
            }
            catch (Exception ex)
            {
                await _context.Database.RollbackTransactionAsync();
                response.Result = "fail";
                response.Message = $"Error: {ex.Message}";
            }

            return response;
        }


        public async Task<List<MenuModel>> GetAllMenus()
        {
            var list = await _context.Menus.ToListAsync();
            return _mapper.Map< List<MenuModel>>(list);
        }

        public async Task<List<RoleModel>> GetAllRoles()
        {
            var list = await _context.Roles.ToListAsync();
            return _mapper.Map<List<RoleModel>>(list);
        }

        public async Task<List<MenuModel>> GetAllMenuByRole(Guid RoleId)
        {
            var accessData = (from rp in _context.RolePermissions.Where(rp => rp.RoleId == RoleId && rp.HaveView)
                              join m in _context.Menus on rp.MenuId equals m.MenuId
                              select new
                              {
                                  Id = rp.MenuId,
                                  Name = m.Name
                              }).ToList();

            var menuList = accessData.Select(item => new Menu
            {
                MenuId = item.Id,
                Name = item.Name
            }).ToList();

            return _mapper.Map<List<MenuModel>>(menuList);
        }

        public async Task<MenuPermission> GetMenuPermissionByRole(Guid roleId, Guid menuId)
        {
            var menupermission = new MenuPermission();

            var permissionData = await _context.RolePermissions
                .FirstOrDefaultAsync(rp => rp.RoleId == roleId && rp.MenuId == menuId);

            if (permissionData != null)
            {
                menupermission.Id = permissionData.MenuId; 
                menupermission.HaveView = permissionData.HaveView;
                menupermission.HaveAdd = permissionData.HaveAdd;
                menupermission.HaveEdit = permissionData.HaveEdit;
                menupermission.HaveDelete = permissionData.HaveDelete;
            }

            return menupermission;
        }

    }
}
