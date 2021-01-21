using System.Threading.Tasks;
using MagusAppGateway.Models.Dtos;
using MagusAppGateway.Util.Result;

namespace MagusAppGateway.Services.IServices
{
    public interface IApiScopeService
    {
        Task<ResultModel> GetList(ApiScopeQueryDto apiScopeDto);

        Task<ResultModel> GetById(int id);

        Task<ResultModel> UpdateApiScope(ApiScopeEditDto dto);

        Task<ResultModel> CreateApiScope(ApiScopeEditDto dto);
    }
}
