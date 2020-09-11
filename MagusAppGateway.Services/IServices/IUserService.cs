using System.Threading.Tasks;
using MagusAppGateway.Services.Result;
using System;
using MagusAppGateway.Models.Dtos;

namespace MagusAppGateway.Services.IServices
{
    public interface IUserService
    {
        Task<ResultModel> GetUsers(UserQueryDto userQueryDto);

        Task<ResultModel> GetById(Guid id);

        Task<ResultModel> UpdateUser(UserUpdateDto userUpdateDto);

        Task<ResultModel> CreateUser(UserCreateDto userCreateDto);

        Task<ResultModel> DisableUser(Guid id);

        Task<ResultModel> EnableUser(Guid id);

        Task<ResultModel> Login(UserLoginDto userLoginDto);

        Task<ResultModel> ApplyToken(ApplyTokenDto applyTokenDto);
    }
}
