using System;
using System.Linq;
using System.Threading.Tasks;
using MagusAppGateway.Services.IServices;
using AutoMapper;
using MagusAppGateway.Contexts;
using MagusAppGateway.Models.Dtos;
using MagusAppGateway.Models;
using IdentityModel.Client;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using MagusAppGateway.Util;
using Microsoft.EntityFrameworkCore;
using MagusAppGateway.Util.Result;

namespace MagusAppGateway.Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserDatabaseContext _userDatabaseContext;
        private readonly IConfiguration _configuration;

        public UserService(UserDatabaseContext userDatabaseContext,IConfiguration configuration)
        {
            _userDatabaseContext = userDatabaseContext;
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

        public async Task<ResultModel> CreateUser(UserEditDto userCreateDto)
        {
            if (string.IsNullOrWhiteSpace(userCreateDto.Username))
            {
                return new ResultModel(ResultCode.Fail, "请输入用户名");
            }
            if (string.IsNullOrWhiteSpace(userCreateDto.Password))
            {
                return new ResultModel(ResultCode.Fail, "请输入密码");
            }
            if(userCreateDto.Enabled==null)
            {
                return new ResultModel(ResultCode.Fail, "请输入是否启用");
            }
            if (_userDatabaseContext.Users.Any(x => x.Username == userCreateDto.Username))
            {
                return new ResultModel(ResultCode.Fail, "此用户已存在");
            }
            var result = new ResultModel();
            var resultStatus = new ResultStatus();
            try
            {
                var users = new Users();
                users.Password = MD5Helper.GetMD5Hash(userCreateDto.Password);
                users.Username = userCreateDto.Username;
                users.Id = Guid.NewGuid();
                users.Enabled = userCreateDto.Enabled.Value;
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
               var user = _userDatabaseContext.Users.Select(x => new UserDto
               {
                   UserId = x.Id.ToString(),
                   Username = x.Username,
                   Enabled = x.Enabled
               }).FirstOrDefault(x => x.UserId == id.ToString());
                if (user == null)
                {
                    return new ResultModel(ResultCode.Fail, "没有对应用户");
                }
                return new ResultModel(ResultCode.Success, user);
            });
        }

        public async Task<ResultModel> GetByName(string username)
        {
            return await Task.Run(() => {
                var user = _userDatabaseContext.Users.FirstOrDefault(x => x.Username == username);
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
                    //后面要做根据条件排序
                    query = query.OrderBy(x => x.Username);
                    var list = query.Select(x => new UserDto
                    {
                        UserId = x.Id.ToString(),
                        Username = x.Username,
                        Enabled = x.Enabled
                    });
                    var page = PagedList<UserDto>.ToPagedList(list, userQueryDto.CurrentPage, userQueryDto.PageSize);
                    return new ResultModel(ResultCode.Success, page);
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
                var user = _userDatabaseContext.Users.FirstOrDefault(x => x.Username == userLoginDto.Username && x.Password == MD5Helper.GetMD5Hash(userLoginDto.Password));
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

        public async Task<ResultModel> UpdateUser(UserEditDto userUpdateDto)
        {
            if (userUpdateDto.UserId == null)
            {
                return new ResultModel(ResultCode.Fail, "请输入用户编号");
            }
            if(string.IsNullOrWhiteSpace(userUpdateDto.Username))
            {
                return new ResultModel(ResultCode.Fail, "请输入用户名");
            }
            if (_userDatabaseContext.Users.Any(x => x.Username == userUpdateDto.Username && x.Id != userUpdateDto.UserId))
            {
                return new ResultModel(ResultCode.Fail, "此用户已存在");
            }
            //if (string.IsNullOrWhiteSpace(userUpdateDto.Password))
            //{
            //    return new ResultModel(ResultCode.Fail, "请输入密码");
            //}
            try
            {
                var user = _userDatabaseContext.Users.FirstOrDefault(x => x.Id == userUpdateDto.UserId);
                //userUpdateDto.Password = MD5Helper.GetMD5Hash(userUpdateDto.Password);
                user.Username = userUpdateDto.Username;
                user.Enabled = userUpdateDto.Enabled.Value;
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
