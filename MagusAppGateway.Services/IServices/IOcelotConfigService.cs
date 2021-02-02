using System;
using System.Threading.Tasks;
using MagusAppGateway.Models.Dtos;
using MagusAppGateway.Util.Result;

namespace MagusAppGateway.Services.IServices
{
    public interface IOcelotConfigService
    {
        Task<ResultModel> GetConfigPageList(OcelotConfigQueryDto dto);

        Task<ResultModel> CreateConfig(OcelotConfigEditDto dto);

        Task<ResultModel> UpdateConfig(OcelotConfigEditDto dto);

        Task<ResultModel> EnableConfig(Guid id);

        Task<ResultModel> DeleteConfig(Guid id);

        Task<ResultModel> GetRoutePageList(RoutesQueryDto dto);

        Task<ResultModel> CreateRoute(RoutesEditDto dto);

        Task<ResultModel> UpdateRoute(RoutesEditDto dto);

        Task<ResultModel> DelteRoute(Guid id);

        Task<ResultModel> GetRouteById(Guid id);

        Task<ResultModel> GetConfigById(Guid id);

        Task<ResultModel> GetAllConfig();
    }
}
