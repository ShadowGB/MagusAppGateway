using System.Threading.Tasks;
using MagusAppGateway.Services.Result;
using MagusAppGateway.Models.Dtos;
using System.Collections.Generic;

namespace MagusAppGateway.Services.IServices
{
    public interface IClientService
    {
        Task<ResultModel> GetList(ClientQueryDto clientQueryDto);

        Task<ResultModel> GetById(int id);

        Task<ResultModel> UpdateClient(ClientUpdateDto clientUpdateDto);

        Task<ResultModel> CreateClient(ClientCreateDto clientCreateDto);

        Task<ResultModel> ConfigClientCorsOrigin(List<ClientCorsOriginCreateDto> clientCorsOriginCreateDtos,int clientId);

        Task<ResultModel> ConfigClientGrantType(List<ClientGrantTypeCreateDto> clientGrantTypeCreateDtos, int clientId);

        Task<ResultModel> ConfigClientPostLogoutRedirectUri(List<ClientPostLogoutRedirectUriCreateDto> clientPostLogoutRedirectUriCreateDtos, int clientId);

        Task<ResultModel> ConfigClientRedirectUri(List<ClientRedirectUriCreateDto> clientRedirectUriCreateDtos, int clientId);

        Task<ResultModel> ConfigClientScope(List<ClientScopeCreateDto> clientScopeCreateDtos, int clientId);

        Task<ResultModel> ConfigClientSecret(List<ClientSecretCreateDto> clientSecretCreateDtos, int clientId);

    }
}
