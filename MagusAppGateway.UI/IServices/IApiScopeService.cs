using System.Threading.Tasks;
using MagusAppGateway.UI.ViewModel;
using MagusAppGateway.UI.Result;

namespace MagusAppGateway.UI.IServices
{
    public interface IApiScopeService
    {
        Task<ResultModel<PagedList<ApiScopeDto>>> GetApiScopePage(ApiScopeQueryDto dto);

        Task<ResultModel<string>> AddApiScope(ApiScopeEditDto dto);

        Task<ResultModel<string>> EditApiScope(ApiScopeEditDto dto);

        Task<ResultModel<ApiScopeDto>> GetApiScopeById(int id);
    }
}
