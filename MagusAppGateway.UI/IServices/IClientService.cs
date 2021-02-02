using System.Threading.Tasks;
using MagusAppGateway.UI.ViewModel;
using MagusAppGateway.UI.Result;

namespace MagusAppGateway.UI.IServices
{
    public interface IClientService
    {
        Task<ResultModel<PagedList<ClientDto>>> GetClientPage(ClientQueryDto dto);

        Task<ResultModel<string>> AddClient(ClientEditDto dto);

        Task<ResultModel<string>> EditClient(ClientEditDto dto);

        Task<ResultModel<ClientDto>> GetById(int id);
    }
}
