using MagusAppGateway.Contexts;
using MagusAppGateway.Models;
using MagusAppGateway.Models.Dtos;
using MagusAppGateway.Services.IServices;
using MagusAppGateway.Util.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagusAppGateway.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public RoleService(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }

        public async Task<ResultModel> CreateRoles(RolesEditDto rolesEditDto)
        {
            if(string.IsNullOrWhiteSpace(rolesEditDto.RoleName))
            {
                return new ResultModel(ResultCode.Fail, "请输入角色名称");
            }
            if (_userDatabaseContext.Users.Any(x => x.UserRoles == rolesEditDto.UserRoles))
            {
                return new ResultModel(ResultCode.Fail, "角色已存在");
            }
            var result = new ResultModel();
            var resultStatus = new ResultStatus();
            try
            {
                var roles = new Roles();
                roles.RoleName = rolesEditDto.RoleName;
                roles.Id = Guid.NewGuid();
                _userDatabaseContext.Roles.Add(roles);
                await _userDatabaseContext.SaveChangesAsync();
                resultStatus.text = "创建角色成功";
                resultStatus.code = ResultCode.Success;
                result.status = resultStatus;
                return result;
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> GetRoles(RolesQueryDto rolesQueryDto)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var query = _userDatabaseContext.Roles.Where(x => 1 == 1);
                    if (!string.IsNullOrWhiteSpace(rolesQueryDto.RoleName))
                    {
                        query = query.Where(x => x.RoleName.Contains(rolesQueryDto.RoleName));
                    }
                    //后面要做根据条件排序
                    query = query.OrderBy(x => x.RoleName);
                    var list = query.Select(x => new RolesDto
                    {
                        RoleId = x.Id.ToString(),
                        RoleName = x.RoleName
                    });
                    var page = PagedList<RolesDto>.ToPagedList(list, rolesQueryDto.CurrentPage, rolesQueryDto.PageSize);
                    return new ResultModel(ResultCode.Success, page);
                }
                catch (Exception ex)
                {
                    return new ResultModel(ResultCode.Fail, ex.Message);
                }
            });
        }

        public async Task<ResultModel> GetUserRolesByUserId(RolesQueryDto rolesQueryDto)
        {
           return await Task.Run(() => {
               try
               {
                   var roleQuery = from a in _userDatabaseContext.Roles
                               join b in _userDatabaseContext.UserRoles
                               on a.Id equals b.RoleId
                               where b.UserId == rolesQueryDto.UserId
                               select new UserRoleDto
                               {
                                   RoleId = a.Id.ToString(),
                                   RoleName = a.RoleName,
                                   IsHaveRole = false
                               };

                   var page = PagedList<UserRoleDto>.ToPagedList(roleQuery, rolesQueryDto.CurrentPage, rolesQueryDto.PageSize);
                   var roleIdPage = page.Data.Select(x => Guid.Parse(x.RoleId)).ToList();
                   var userRoleQuery = _userDatabaseContext.UserRoles.Where(x => x.UserId == rolesQueryDto.UserId && roleIdPage.Contains(x.RoleId));
                   page.Data.ForEach(x =>
                   {
                       if (userRoleQuery.Any(u => u.RoleId.ToString() == x.RoleId))
                       {
                           x.IsHaveRole = true;
                       }
                   });
                   return new ResultModel(ResultCode.Success, page);
               }
               catch (Exception ex)
               {
                   return new ResultModel(ResultCode.Fail, ex.Message);
               }
           });
        }

        public async Task<ResultModel> GetRolesByUserId(Guid userId)
        {
            try
            {
                var query = await _userDatabaseContext.UserRoles.Where(x => x.UserId == userId).Select(x => x.RoleId).ToListAsync();
                var roleQuery = _userDatabaseContext.Roles.Where(x => query.Contains(x.Id));
                var list = roleQuery.ToList();
                return new ResultModel(ResultCode.Success, list);
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> SetUserRoleByUserIdAndRoleIds(Guid userId, List<Guid> roleIds)
        {
            try
            {
                _userDatabaseContext.UserRoles.RemoveRange(_userDatabaseContext.UserRoles.Where(x => x.UserId == userId));
                var userRoles = new List<UserRole>();
                roleIds.ForEach(x =>
                {
                    userRoles.Add(new UserRole
                    {
                        Id = Guid.NewGuid(),
                        RoleId = x,
                        UserId = userId
                    });
                });
                _userDatabaseContext.UserRoles.AddRange(userRoles);
                await _userDatabaseContext.SaveChangesAsync();
                return new ResultModel(ResultCode.Success, "设置角色成功");
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> UpdateRoles(RolesEditDto rolesEditDto)
        {
            if(string.IsNullOrWhiteSpace(rolesEditDto.RoleName))
            {
                return new ResultModel(ResultCode.Fail, "请输入角色名称");
            }
            if (_userDatabaseContext.Roles.Any(x => x.RoleName == rolesEditDto.RoleName && x.Id == rolesEditDto.RoleId))
            {
                return new ResultModel(ResultCode.Fail, "角色已存在");
            }
            try
            {
                var role = _userDatabaseContext.Roles.FirstOrDefault(x => x.Id == rolesEditDto.RoleId);
                role.RoleName = rolesEditDto.RoleName;
                _userDatabaseContext.Roles.Update(role);
                await _userDatabaseContext.SaveChangesAsync();
                return new ResultModel(ResultCode.Success, "更新角色成功");
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> GetUserRoleAndIsHaveRoleByUserId(RolesQueryDto rolesQueryDto)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var query = _userDatabaseContext.Roles.Where(x => 1 == 1);
                    if (!string.IsNullOrWhiteSpace(rolesQueryDto.RoleName))
                    {
                        query = query.Where(x => x.RoleName.Contains(rolesQueryDto.RoleName));
                    }
                    var dtoQuery = query.Select(x => new UserRoleDto
                    {
                        RoleId = x.Id.ToString(),
                        RoleName = x.RoleName,
                        IsHaveRole = false
                    });
                    //var page = PagedList<UserRoleDto>.ToPagedList(dtoQuery, rolesQueryDto.CurrentPage, rolesQueryDto.PageSize);
                    //var roleIdPage = page.Data.Select(x => Guid.Parse(x.RoleId)).ToList();
                    //var userRoleQuery = _userDatabaseContext.UserRoles.Where(x => x.UserId == rolesQueryDto.UserId && roleIdPage.Contains(x.RoleId));
                    //page.Data.ForEach(x =>
                    //{
                    //    if (userRoleQuery.Any(u => u.RoleId.ToString() == x.RoleId))
                    //    {
                    //        x.IsHaveRole = true;
                    //    }
                    //});
                    return new ResultModel(ResultCode.Success, dtoQuery.ToList());
                }
                catch (Exception ex)
                {
                    return new ResultModel(ResultCode.Fail, ex.Message);
                }
            });
        }
    }
}
