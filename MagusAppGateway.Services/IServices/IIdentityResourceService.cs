using System.Threading.Tasks;
using MagusAppGateway.Models.Dtos;
using MagusAppGateway.Util.Result;

namespace MagusAppGateway.Services.IServices
{
    public interface IIdentityResourceService
    {
        Task<ResultModel> GetList(IdentityResourceQueryDto identityResourceQueryDto);

        Task<ResultModel> GetById(int id);

        Task<ResultModel> UpdateIdentityResource(IdentityResourceUpdateDto identityResourceUpdateDto);

        Task<ResultModel> CreateIdentityResource(IdentityResourceCreateDto identityResourceCreateDto);
    }
}
