using System.Threading.Tasks;
using MagusAppGateway.Services.Result;
using MagusAppGateway.Models.Dtos;

namespace MagusAppGateway.Services.IServices
{
    public interface IClientService
    {
        Task<ResultModel> GetList(ClientQueryDto clientQueryDto);

        Task<ResultModel> GetById(int id);

        Task<ResultModel> UpdateClient(ClientUpdateDto clientUpdateDto);

        Task<ResultModel> CreateClient(ClientCreateDto clientCreateDto);

    }
}
