using System.Threading.Tasks;
using MagusAppGateway.UI.ViewModel;
using MagusAppGateway.UI.Result;
using System.Collections.Generic;
using System;

namespace MagusAppGateway.UI.IServices
{
    public interface IOcelotService
    {
        Task<ResultModel<PagedList<OcelotConfigDto>>> GetConfigPageList(OcelotConfigQueryDto dto);

        Task<ResultModel<string>> CreateConfig(OcelotConfigEditDto dto);

        Task<ResultModel<string>> UpdateConfig(OcelotConfigEditDto dto);

        Task<ResultModel<string>> EnableConfig(Guid id);

        Task<ResultModel<string>> DeleteConfig(Guid id);

        Task<ResultModel<PagedList<RoutesDto>>> GetRoutePageList(RoutesQueryDto dto);

        Task<ResultModel<string>> CreateRoute(RoutesEditDto dto);

        Task<ResultModel<string>> UpdateRoute(RoutesEditDto dto);

        Task<ResultModel<string>> DelteRoute(Guid id);

        Task<ResultModel<RoutesDto>> GetRouteById(Guid id);

        Task<ResultModel<OcelotConfigDto>> GetConfigById(Guid id);

        Task<ResultModel<List<OcelotConfigDto>>> GetAllConfig();
    }
}
