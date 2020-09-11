using System;
using System.Linq;
using System.Threading.Tasks;
using MagusAppGateway.Services.IServices;
using MagusAppGateway.Services.Result;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using MagusAppGateway.Contexts;
using MagusAppGateway.Models.Dtos;

namespace MagusAppGateway.Services.Services
{
    public class ApiScopeService : IApiScopeService
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public ApiScopeService(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }

        public async Task<ResultModel> CreateApiScope(ApiScopeCreateDto apiScopeCreateDto)
        {
            try
            {
                List<ApiScopeClaim> apiScopeClaims = new List<ApiScopeClaim>();
                foreach (var item in apiScopeCreateDto.UserClaims)
                {
                    apiScopeClaims.Add(new ApiScopeClaim
                    {
                        Type = item.Type
                    });
                }

                var apiScope = new ApiScope
                {
                    Enabled = apiScopeCreateDto.Enabled,
                    Name = apiScopeCreateDto.Name,
                    DisplayName = apiScopeCreateDto.DisplayName,
                    Description = apiScopeCreateDto.Description,
                    Required = apiScopeCreateDto.Required,
                    Emphasize = apiScopeCreateDto.Emphasize,
                    ShowInDiscoveryDocument = apiScopeCreateDto.ShowInDiscoveryDocument,
                    UserClaims = apiScopeClaims
                };

                //List<ApiScopeProperty> apiScopeProperties = new List<ApiScopeProperty>();
                //foreach (var item in apiScopeCreateDto.Properties)
                //{
                //    apiScopeProperties.Add(new ApiScopeProperty
                //    {
                //        Key = item.Key,
                //        Value = item.Value
                //    });
                //}
                //apiScope.Properties = apiScopeProperties;

                _userDatabaseContext.ApiScopes.Add(apiScope);
                await _userDatabaseContext.SaveChangesAsync();
                return new ResultModel(ResultCode.Success, "创建API域成功");
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> GetById(int id)
        {
            var apiScope = await _userDatabaseContext.ApiScopes.Where(x => x.Id == id)
                .Include(x => x.UserClaims)
                //.Include(x => x.Properties)
                .FirstOrDefaultAsync();

            if (apiScope == null)
            {
                return new ResultModel(ResultCode.Fail, "没有对应API域");
            }


            List<ApiScopeClaimDto> apiScopeClaimDtos = new List<ApiScopeClaimDto>();
            foreach (var item in apiScope.UserClaims)
            {
                apiScopeClaimDtos.Add(new ApiScopeClaimDto
                {
                    ScopeId = item.ScopeId,
                    Id = item.Id,
                    Type = item.Type
                });
            }

            //List<ApiScopePropertyDto> apiScopePropertyDtos = new List<ApiScopePropertyDto>();
            //foreach (var item in apiScope.Properties)
            //{
            //    apiScopePropertyDtos.Add(new ApiScopePropertyDto
            //    {
            //        Id = item.Id,
            //        Key = item.Key,
            //        Value = item.Value,
            //        ScopeId = item.ScopeId
            //    });
            //}

            var apiScopeDto = new ApiScopeDto
            {
                Id = apiScope.Id,
                Enabled = apiScope.Enabled,
                Name = apiScope.Name,
                DisplayName = apiScope.Name,
                Description = apiScope.Description,
                Required = apiScope.Required,
                Emphasize = apiScope.Emphasize,
                ShowInDiscoveryDocument = apiScope.ShowInDiscoveryDocument,
                UserClaims = apiScopeClaimDtos,
                //Properties = apiScopePropertyDtos
            };

            return new ResultModel(ResultCode.Success, apiScopeDto);
        }

        public async Task<ResultModel> GetList(ApiScopeQueryDto apiScopeQueryDto)
        {
            try
            {
                var query = _userDatabaseContext.IdentityResources.Where(x => 1 == 1);
                if (!string.IsNullOrWhiteSpace(apiScopeQueryDto.Name))
                {
                    query = query.Where(x => x.Name.Contains(apiScopeQueryDto.Name));
                }
                var list = await query.ToListAsync();
                return new ResultModel(ResultCode.Success, list);
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> UpdateApiScope(ApiScopeUpdateDto apiScopeUpdateDto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(apiScopeUpdateDto.Name))
                {
                    return new ResultModel(ResultCode.Fail, "请输入API域名称");
                }
                var apiScope = await _userDatabaseContext.ApiScopes.Where(x => x.Id == apiScopeUpdateDto.Id)
                    .Include(x => x.UserClaims)
                    .FirstOrDefaultAsync();

                List<ApiScopeClaim> apiScopeClaims = new List<ApiScopeClaim>();
                foreach (var item in apiScopeUpdateDto.UserClaims)
                {
                    apiScopeClaims.Add(new ApiScopeClaim
                    {
                        Type = item.Type
                    });
                }
                apiScope.Enabled = apiScopeUpdateDto.Enabled;
                apiScope.Name = apiScopeUpdateDto.Name;
                apiScope.DisplayName = apiScopeUpdateDto.DisplayName;
                apiScope.Description = apiScopeUpdateDto.Description;
                apiScope.Required = apiScopeUpdateDto.Required;
                apiScope.Emphasize = apiScopeUpdateDto.Emphasize;
                apiScope.ShowInDiscoveryDocument = apiScopeUpdateDto.ShowInDiscoveryDocument;
                apiScope.UserClaims = apiScopeClaims;

                _userDatabaseContext.ApiScopes.Update(apiScope);
                await _userDatabaseContext.SaveChangesAsync();
                return new ResultModel(ResultCode.Success, "更新API域成功");
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }
    }
}
