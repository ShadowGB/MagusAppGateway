using System.Threading.Tasks;
using MagusAppGateway.Models.Dtos;
using System.Collections.Generic;
using MagusAppGateway.Util.Result;

namespace MagusAppGateway.Services.IServices
{
    public interface IClientService
    {
        Task<ResultModel> GetList(ClientQueryDto clientQueryDto);

        Task<ResultModel> GetById(int id);

        Task<ResultModel> UpdateClient(ClientEditDto dto);

        Task<ResultModel> CreateClient(ClientEditDto dto);

        Task<ResultModel> ConfigClientCorsOrigin(List<ClientCorsOriginEditDto> clientCorsOriginEditDtos,int clientId);

        Task<ResultModel> ConfigClientGrantType(List<ClientGrantTypeEditDto> clientGrantTypeEditDtos, int clientId);

        Task<ResultModel> ConfigClientPostLogoutRedirectUri(List<ClientPostLogoutRedirectUriEditDto> clientPostLogoutRedirectUriEditDtos, int clientId);

        Task<ResultModel> ConfigClientRedirectUri(List<ClientRedirectUriEditDto> clientRedirectUriEditDtos, int clientId);

        Task<ResultModel> ConfigClientScope(List<ClientScopeEditDto> clientScopeEditDtos, int clientId);

        Task<ResultModel> ConfigClientSecret(List<ClientSecretEditDto> clientSecretEditDtos, int clientId);

    }
}
