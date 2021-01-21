using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MagusAppGateway.Models.Dtos;
using MagusAppGateway.Util.Result;

namespace MagusAppGateway.Services.IServices
{
    public interface IRoleService
    {
        Task<ResultModel> GetRolesByUserId(Guid userId);

        Task<ResultModel> GetRoles(RolesQueryDto rolesQueryDto);

        Task<ResultModel> UpdateRoles(RolesEditDto rolesEditDto);

        Task<ResultModel> CreateRoles(RolesEditDto rolesEditDto);

        Task<ResultModel> GetUserRolesByUserId(RolesQueryDto rolesQueryDto);

        Task<ResultModel> SetUserRoleByUserIdAndRoleIds(Guid userId, List<Guid> roleIds);

        Task<ResultModel> GetUserRoleAndIsHaveRoleByUserId(RolesQueryDto rolesQueryDto);
    }
}
