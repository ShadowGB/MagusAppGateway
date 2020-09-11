using System.Threading.Tasks;
using MagusAppGateway.Services.Result;
using MagusAppGateway.Models.Dtos;

namespace MagusAppGateway.Services.IServices
{
    public interface IApiScopeService
    {
        Task<ResultModel> GetList(ApiScopeQueryDto apiScopeDto);

       Task<ResultModel> GetById(int id);

        Task<ResultModel> UpdateApiScope(ApiScopeUpdateDto apiScopeUpdateDto);

        Task<ResultModel> CreateApiScope(ApiScopeCreateDto apiScopeCreateDto);
    }
}
