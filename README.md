# MagusAppGateway
集成IdentityServer4的Ocelot网关

# 账号
用户名：admin   

密码：123456   

ClientId:mvc   

ClientSerect:123   

# 项目结构
MagusAppGateway.Auth：IdentityServer4授权站点   

MagusAppGateway.ConfigWebApi：配置中心   

MagusAppGateway.Contexts：数据库上下文类库   

MagusAppGateway.Gateway：Ocelot网关站点   

MagusAppGateway.Models：数据实体类和Dto   

MagusAppGateway.Services：服务类库   

GoodsService：测试用的Demo服务   

OrderService：测试用的Demo服务   


# 开发环境
Viusal Studio 2019

# 数据库
PostgreSQL   

其他数据库的支持以后再做（实在是来不及啦啦啦）

# 怎样配置
## 数据库配置
在Auth和ConfigWebApi中的appsetting.json里，DBConnection属性   

请运行项目中的db.sql文件   

## Ocelot授权配置
在Gateway项目中的ocelot.json中配置，AuthenticationProviderKey要和IdentityServer4中的APIScope表中的Name属性一致   

## 授权端点配置
在appsettings.json中的IdentityAddress属性   

## 关于Ocelot和IdentityServer4的配置
请去看官网，谢谢   


# 关于发布
请自己生成SSL秘钥，生成方式自行必应（强烈不建议用百度搜索）   

# 用户表
__在生产过程中请勿使用这个项目里的用户表，密码都是明文存储的__

# 关于作者
渣渣小开发一枚，邮箱：237213310@qq.com