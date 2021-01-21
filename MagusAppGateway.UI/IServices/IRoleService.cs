using MagusAppGateway.UI.Result;
using MagusAppGateway.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagusAppGateway.UI.IServices
{
    public interface IRoleService
    {
        Task<ResultModel<PagedList<UserRoleDto>>> GetUserRole(UserRoleDto dto);

        Task<ResultModel<List<UserRoleDto>>> GetUserRoleAndIsHaveRoleByUserId(UserRoleDto dto);

        Task<ResultModel<string>> SetUserRoleByUserIdAndRoleIds(SetUserRoleDto dto);
    }
}
