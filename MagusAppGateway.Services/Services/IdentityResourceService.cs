using System;
using System.Linq;
using System.Threading.Tasks;
using MagusAppGateway.Services.IServices;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using MagusAppGateway.Contexts;
using MagusAppGateway.Models.Dtos;
using MagusAppGateway.Util.Result;

namespace MagusAppGateway.Services.Services
{
    public class IdentityResourceService : IIdentityResourceService
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public IdentityResourceService(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }

        public async Task<ResultModel> CreateIdentityResource(IdentityResourceCreateDto identityResourceCreateDto)
        {
            try
            {
                var identityResource = new IdentityResource();
                identityResource.Created = DateTime.Now;
                identityResource.Enabled = identityResourceCreateDto.Enabled;
                identityResource.Name = identityResourceCreateDto.Name;
                identityResource.DisplayName = identityResourceCreateDto.DisplayName;
                identityResource.Required = identityResourceCreateDto.Required;
                identityResource.Emphasize = identityResourceCreateDto.Emphasize;
                identityResource.ShowInDiscoveryDocument = identityResourceCreateDto.ShowInDiscoveryDocument;
                identityResource.NonEditable = identityResourceCreateDto.NonEditable;

                List<IdentityResourceClaim> identityResourceClaims = new List<IdentityResourceClaim>();
                foreach (var item in identityResourceCreateDto.UserClaims)
                {
                    identityResourceClaims.Add(new IdentityResourceClaim 
                    {
                        Type = item.Type
                    });
                }
                identityResource.UserClaims = identityResourceClaims;

                List<IdentityResourceProperty> identityResourceProperties = new List<IdentityResourceProperty>();
                foreach (var item in identityResourceCreateDto.Properties)
                {
                    identityResourceProperties.Add(new IdentityResourceProperty
                    {
                        Key = item.Key,
                        Value = item.Value,
                    });
                }
                identityResource.Properties = identityResourceProperties;

                _userDatabaseContext.IdentityResources.Add(identityResource);
                await _userDatabaseContext.SaveChangesAsync();
                return new ResultModel(ResultCode.Success, "创建认证资源成功");
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> GetById(int id)
        {
            ResultModel result = new ResultModel();
            ResultStatus resultStatus = new ResultStatus();
            result.status = resultStatus;
            var identityResource = await _userDatabaseContext.IdentityResources.Where(x => x.Id == id)
                .Include(x => x.UserClaims)
                .Include(x => x.Properties)
                .FirstOrDefaultAsync();

            if (identityResource == null)
            {
                return new ResultModel(ResultCode.Fail, "没有对应认证资源");
            }

            var identityResourceDto = new IdentityResourceDto();
            identityResourceDto.Id = identityResource.Id;
            identityResourceDto.Created = identityResource.Created;
            identityResourceDto.Updated = identityResource.Updated;
            identityResourceDto.Enabled = identityResource.Enabled;
            identityResourceDto.Name = identityResource.Name;
            identityResourceDto.DisplayName = identityResource.DisplayName;
            identityResourceDto.Required = identityResource.Required;
            identityResourceDto.Emphasize = identityResource.Emphasize;
            identityResourceDto.ShowInDiscoveryDocument = identityResource.ShowInDiscoveryDocument;
            identityResourceDto.NonEditable = identityResource.NonEditable;

            List<IdentityResourceClaimDto> identityResourceClaimDtos = new List<IdentityResourceClaimDto>();
            foreach (var item in identityResource.UserClaims)
            {
                identityResourceClaimDtos.Add(new IdentityResourceClaimDto
                {
                    Id = item.Id,
                    Type = item.Type,
                    IdentityResourceId = item.IdentityResourceId
                });
            }
            identityResourceDto.UserClaims = identityResourceClaimDtos;

            List<IdentityResourcePropertyDto> identityResourcePropertyDtos = new List<IdentityResourcePropertyDto>();
            foreach (var item in identityResource.Properties)
            {
                identityResourcePropertyDtos.Add(new IdentityResourcePropertyDto
                {
                    Id = item.Id,
                    Key = item.Key,
                    Value = item.Value,
                    IdentityResourceId = item.IdentityResourceId
                });
            }
            identityResourceDto.Properties = identityResourcePropertyDtos;

            resultStatus.code = ResultCode.Success;
            result.custom = identityResourceDto;
            result.status = resultStatus;
            return result;
        }


        public async Task<ResultModel> GetList(IdentityResourceQueryDto identityResourceQueryDto)
        {
            try
            {
                var query = _userDatabaseContext.IdentityResources.Where(x => 1 == 1);
                if (!string.IsNullOrWhiteSpace(identityResourceQueryDto.Name))
                {
                    query = query.Where(x => x.Name.Contains(identityResourceQueryDto.Name));
                }
                var list = await query.ToListAsync();
                return new ResultModel(ResultCode.Success, list);
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> UpdateIdentityResource(IdentityResourceUpdateDto identityResourceUpdateDto)
        {
            if (string.IsNullOrWhiteSpace(identityResourceUpdateDto.Name))
            {
                return new ResultModel(ResultCode.Fail, "请输入认证资源名称");
            }
            try
            {
                var identityResource = await _userDatabaseContext.IdentityResources.Where(x => x.Id == identityResourceUpdateDto.Id)
                    .Include(x => x.UserClaims)
                    .Include(x => x.Properties)
                    .FirstOrDefaultAsync();

                identityResource.Updated = DateTime.Now;
                identityResource.Enabled = identityResourceUpdateDto.Enabled;
                identityResource.Name = identityResourceUpdateDto.Name;
                identityResource.DisplayName = identityResourceUpdateDto.DisplayName;
                identityResource.Required = identityResourceUpdateDto.Required;
                identityResource.Emphasize = identityResourceUpdateDto.Emphasize;
                identityResource.ShowInDiscoveryDocument = identityResourceUpdateDto.ShowInDiscoveryDocument;
                identityResource.NonEditable = identityResourceUpdateDto.NonEditable;

                List<IdentityResourceClaim> identityResourceClaims = new List<IdentityResourceClaim>();
                foreach (var item in identityResourceUpdateDto.UserClaims)
                {
                    identityResourceClaims.Add(new IdentityResourceClaim
                    {
                        Type = item.Type
                    });
                }
                identityResource.UserClaims = identityResourceClaims;

                List<IdentityResourceProperty> identityResourceProperties = new List<IdentityResourceProperty>();
                foreach (var item in identityResourceUpdateDto.Properties)
                {
                    identityResourceProperties.Add(new IdentityResourceProperty
                    {
                        Key = item.Key,
                        Value = item.Value,
                    });
                }
                identityResource.Properties = identityResourceProperties;

                _userDatabaseContext.IdentityResources.Update(identityResource);
                await _userDatabaseContext.SaveChangesAsync();
                return new ResultModel(ResultCode.Success, "更新认证资源成功");
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

    }
}
