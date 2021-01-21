using System.Threading.Tasks;
using System;
using MagusAppGateway.Models.Dtos;
using MagusAppGateway.Util.Result;

namespace MagusAppGateway.Services.IServices
{
    public interface IUserService
    {
        Task<ResultModel> GetUsers(UserQueryDto userQueryDto);

        Task<ResultModel> GetById(Guid id);

        Task<ResultModel> GetByName(string username);

        Task<ResultModel> UpdateUser(UserEditDto userUpdateDto);

        Task<ResultModel> CreateUser(UserEditDto userCreateDto);

        Task<ResultModel> DisableUser(Guid id);

        Task<ResultModel> EnableUser(Guid id);

        Task<ResultModel> Login(UserLoginDto userLoginDto);

        Task<ResultModel> ApplyToken(ApplyTokenDto applyTokenDto);
    }
}
