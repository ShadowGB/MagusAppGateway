using System.Threading.Tasks;
using MagusAppGateway.UI.ViewModel;
using MagusAppGateway.UI.Result;

namespace MagusAppGateway.UI.IServices
{
    public interface IUserService
    {
        Task<ResultModel<PagedList<UserDto>>> GetUserPage(UserQueryDto dto);

        Task<ResultModel<string>> AddUser(UserCreateOrEditDto dto);

        Task<ResultModel<string>> EditUser(UserCreateOrEditDto dto);

        Task<ResultModel<UserDto>> GetUserById(string id);
    }
}
