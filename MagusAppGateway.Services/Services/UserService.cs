using System;
using System.Linq;
using System.Threading.Tasks;
using MagusAppGateway.Services.IServices;
using AutoMapper;
using MagusAppGateway.Services.Result;
using MagusAppGateway.Contexts;
using MagusAppGateway.Models.Dtos;
using MagusAppGateway.Models;
using IdentityModel.Client;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace MagusAppGateway.Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserDatabaseContext _userDatabaseContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserService(UserDatabaseContext userDatabaseContext,IMapper mapper, IConfiguration configuration)
        {
            _userDatabaseContext = userDatabaseContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ResultModel> ApplyToken(ApplyTokenDto applyTokenDto)
        {
            var client = new HttpClient();
            //var disco = await client.GetDiscoveryDocumentAsync(_configuration.GetSection("IdentityAddress").Value);
            //disco.Policy = new DiscoveryPolicy { RequireHttps = false };
            var disco = await client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest { Address = _configuration.GetSection("IdentityAddress").Value, Policy = new DiscoveryPolicy { RequireHttps = false } });
            if (disco.IsError)
            {
                return new ResultModel(ResultCode.Fail, disco.Error);
            }

            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = applyTokenDto.ClientId,
                ClientSecret = applyTokenDto.ClientSerect,
                GrantType = "password",
                UserName = applyTokenDto.Username,
                Password = applyTokenDto.Password
            });

            if (tokenResponse.IsError)
            {
                return new ResultModel(ResultCode.Fail, tokenResponse.Error);
            }

            var tokenJson = tokenResponse.Json.ToString();
            var tokenModel = JsonConvert.DeserializeObject<TokenResultDto>(tokenJson);
            return new ResultModel(ResultCode.Success, tokenModel);
        }

        public async Task<ResultModel> CreateUser(UserCreateDto userCreateDto)
        {
            var result = new ResultModel();
            var resultStatus = new ResultStatus();
            try
            {
                var users = new Users();
                _mapper.Map(userCreateDto, users);
                users.Id = Guid.NewGuid();
                _userDatabaseContext.Users.Add(users);
                await _userDatabaseContext.SaveChangesAsync();
                resultStatus.text = "创建用户成功";
                resultStatus.code = ResultCode.Success;
                result.status = resultStatus;
                return result;
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> DisableUser(Guid id)
        {
            var user = _userDatabaseContext.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return new ResultModel(ResultCode.Fail, "没有对应用户");
            }
            if (user.Enabled == false)
            {
                return new ResultModel(ResultCode.Fail,"此用户已禁用");
            }
            user.Enabled = false;
            try
            {
                _userDatabaseContext.Users.Update(user);
                await _userDatabaseContext.SaveChangesAsync();
                return new ResultModel(ResultCode.Success, "禁用用户成功");
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> EnableUser(Guid id)
        {
            var user = _userDatabaseContext.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return new ResultModel(ResultCode.Fail, "没有对应用户");
            }
            if (user.Enabled == true)
            {
                return new ResultModel(ResultCode.Fail, "此用户已启用");
            }
            user.Enabled = true;
            try
            {
                _userDatabaseContext.Users.Update(user);
                await _userDatabaseContext.SaveChangesAsync();
                return new ResultModel(ResultCode.Success, "启用用户成功");
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }

        public async Task<ResultModel> GetById(Guid id)
        {
           return await Task.Run(()=> {
                var user = _userDatabaseContext.Users.FirstOrDefault(x => x.Id == id);
                if (user == null)
                {
                    return new ResultModel(ResultCode.Fail, "没有对应用户");
                }
                return new ResultModel(ResultCode.Success, user);
            });

        }

        public async Task<ResultModel> GetUsers(UserQueryDto userQueryDto)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var query = _userDatabaseContext.Users.Where(x => 1 == 1);
                    if (userQueryDto.Enabled != null)
                    {
                        query = query.Where(x => x.Enabled == userQueryDto.Enabled);
                    }
                    if (!string.IsNullOrWhiteSpace(userQueryDto.Username))
                    {
                        query = query.Where(x => x.Username.Contains(userQueryDto.Username));
                    }
                    var list = query.ToList();
                    return new ResultModel(ResultCode.Success, list);
                }
                catch (Exception ex)
                {
                    return new ResultModel(ResultCode.Fail, ex.Message);
                }
            });
        }

        public async Task<ResultModel> Login(UserLoginDto userLoginDto)
        {
            return await Task.Run(() =>
            {
                if (string.IsNullOrWhiteSpace(userLoginDto.Username))
                {
                    return new ResultModel(ResultCode.Fail, "请填写用户名");
                }
                if (string.IsNullOrWhiteSpace(userLoginDto.Password))
                {
                    return new ResultModel(ResultCode.Fail, "请填写密码");
                }
                var user = _userDatabaseContext.Users.FirstOrDefault(x => x.Username == userLoginDto.Username && x.Password == userLoginDto.Password);
                if (user != null)
                {
                    if (user.Enabled == false)
                    {
                        return new ResultModel(ResultCode.Fail, "此用户已禁用");
                    }
                    user.Password = "";
                    return new ResultModel(ResultCode.Success, "登录成功", user);
                }
                else
                {
                    return new ResultModel(ResultCode.Fail, "用户名或者密码错");
                }
            });
        }

        public async Task<ResultModel> UpdateUser(UserUpdateDto userUpdateDto)
        {
            if (userUpdateDto.Id == null)
            {
                return new ResultModel(ResultCode.Fail, "请输入用户编号");
            }
            if(string.IsNullOrWhiteSpace(userUpdateDto.Username))
            {
                return new ResultModel(ResultCode.Fail, "请输入用户名");
            }
            if (string.IsNullOrWhiteSpace(userUpdateDto.Password))
            {
                return new ResultModel(ResultCode.Fail, "请输入密码");
            }
            try
            {
                var user = _userDatabaseContext.Users.FirstOrDefault(x => x.Id == userUpdateDto.Id);
                _mapper.Map(userUpdateDto, user);
                _userDatabaseContext.Users.Update(user);
                await _userDatabaseContext.SaveChangesAsync();
                return new ResultModel(ResultCode.Success, "更新用户成功");
            }
            catch (Exception ex)
            {
                return new ResultModel(ResultCode.Fail, ex.Message);
            }
        }
    }
}
