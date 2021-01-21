using System.Threading.Tasks;
using MagusAppGateway.UI.ViewModel;
using MagusAppGateway.UI.Result;

namespace MagusAppGateway.UI.IServices
{
    public interface IClientService
    {
        Task<ResultModel<PagedList<ClientDto>>> GetClientPage(ClientQueryDto dto);
    }
}
