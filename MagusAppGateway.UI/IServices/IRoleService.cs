using MagusAppGateway.UI.Result;
using MagusAppGateway.UI.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagusAppGateway.UI.IServices
{
    public interface IRoleService
    {
        Task<ResultModel<PagedList<UserRoleDto>>> GetUserRole(UserRoleDto dto);

        Task<ResultModel<List<UserRoleDto>>> GetUserRoleAndIsHaveRoleByUserId(UserRoleDto dto);

        Task<ResultModel<string>> SetUserRoleByUserIdAndRoleIds(SetUserRoleDto dto);

        Task<ResultModel<PagedList<RoleDto>>> GetRolePage(RoleQueryDto dto);

        Task<ResultModel<string>> AddRole(RoleDto dto);

        Task<ResultModel<string>> EditRole(RoleDto dto);

        Task<ResultModel<RoleDto>> GetRoleById(int id);

        Task<ResultModel<List<RoleDto>>> GetAllRole();
    }
}
