/*
 Navicat Premium Data Transfer

 Source Server         : 本机PG
 Source Server Type    : PostgreSQL
 Source Server Version : 120001
 Source Host           : localhost:5432
 Source Catalog        : MagusGateway_User
 Source Schema         : public

 Target Server Type    : PostgreSQL
 Target Server Version : 120001
 File Encoding         : 65001

 Date: 11/09/2020 18:24:18
*/


-- ----------------------------
-- Sequence structure for ApiResourceClaims_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."ApiResourceClaims_Id_seq";
CREATE SEQUENCE "public"."ApiResourceClaims_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for ApiResourceProperties_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."ApiResourceProperties_Id_seq";
CREATE SEQUENCE "public"."ApiResourceProperties_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for ApiResourceScopes_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."ApiResourceScopes_Id_seq";
CREATE SEQUENCE "public"."ApiResourceScopes_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for ApiResourceSecrets_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."ApiResourceSecrets_Id_seq";
CREATE SEQUENCE "public"."ApiResourceSecrets_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for ApiResources_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."ApiResources_Id_seq";
CREATE SEQUENCE "public"."ApiResources_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for ApiScopeClaims_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."ApiScopeClaims_Id_seq";
CREATE SEQUENCE "public"."ApiScopeClaims_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for ApiScopeProperties_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."ApiScopeProperties_Id_seq";
CREATE SEQUENCE "public"."ApiScopeProperties_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for ApiScopes_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."ApiScopes_Id_seq";
CREATE SEQUENCE "public"."ApiScopes_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for ClientClaims_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."ClientClaims_Id_seq";
CREATE SEQUENCE "public"."ClientClaims_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for ClientCorsOrigins_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."ClientCorsOrigins_Id_seq";
CREATE SEQUENCE "public"."ClientCorsOrigins_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for ClientGrantTypes_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."ClientGrantTypes_Id_seq";
CREATE SEQUENCE "public"."ClientGrantTypes_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for ClientIdPRestrictions_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."ClientIdPRestrictions_Id_seq";
CREATE SEQUENCE "public"."ClientIdPRestrictions_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for ClientPostLogoutRedirectUris_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."ClientPostLogoutRedirectUris_Id_seq";
CREATE SEQUENCE "public"."ClientPostLogoutRedirectUris_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for ClientProperties_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."ClientProperties_Id_seq";
CREATE SEQUENCE "public"."ClientProperties_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for ClientRedirectUris_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."ClientRedirectUris_Id_seq";
CREATE SEQUENCE "public"."ClientRedirectUris_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for ClientScopes_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."ClientScopes_Id_seq";
CREATE SEQUENCE "public"."ClientScopes_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for ClientSecrets_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."ClientSecrets_Id_seq";
CREATE SEQUENCE "public"."ClientSecrets_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for Clients_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."Clients_Id_seq";
CREATE SEQUENCE "public"."Clients_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for IdentityResourceClaims_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."IdentityResourceClaims_Id_seq";
CREATE SEQUENCE "public"."IdentityResourceClaims_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for IdentityResourceProperties_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."IdentityResourceProperties_Id_seq";
CREATE SEQUENCE "public"."IdentityResourceProperties_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for IdentityResources_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."IdentityResources_Id_seq";
CREATE SEQUENCE "public"."IdentityResources_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Table structure for ApiResourceClaims
-- ----------------------------
DROP TABLE IF EXISTS "public"."ApiResourceClaims";
CREATE TABLE "public"."ApiResourceClaims" (
  "Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "Type" varchar(200) COLLATE "pg_catalog"."default" NOT NULL,
  "ApiResourceId" int4 NOT NULL
)
;

-- ----------------------------
-- Records of ApiResourceClaims
-- ----------------------------

-- ----------------------------
-- Table structure for ApiResourceProperties
-- ----------------------------
DROP TABLE IF EXISTS "public"."ApiResourceProperties";
CREATE TABLE "public"."ApiResourceProperties" (
  "Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "Key" varchar(250) COLLATE "pg_catalog"."default" NOT NULL,
  "Value" varchar(2000) COLLATE "pg_catalog"."default" NOT NULL,
  "ApiResourceId" int4 NOT NULL
)
;

-- ----------------------------
-- Records of ApiResourceProperties
-- ----------------------------

-- ----------------------------
-- Table structure for ApiResourceScopes
-- ----------------------------
DROP TABLE IF EXISTS "public"."ApiResourceScopes";
CREATE TABLE "public"."ApiResourceScopes" (
  "Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "Scope" varchar(200) COLLATE "pg_catalog"."default" NOT NULL,
  "ApiResourceId" int4 NOT NULL
)
;

-- ----------------------------
-- Records of ApiResourceScopes
-- ----------------------------

-- ----------------------------
-- Table structure for ApiResourceSecrets
-- ----------------------------
DROP TABLE IF EXISTS "public"."ApiResourceSecrets";
CREATE TABLE "public"."ApiResourceSecrets" (
  "Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "Description" varchar(1000) COLLATE "pg_catalog"."default",
  "Value" varchar(4000) COLLATE "pg_catalog"."default" NOT NULL,
  "Expiration" timestamp(6),
  "Type" varchar(250) COLLATE "pg_catalog"."default" NOT NULL,
  "Created" timestamp(6) NOT NULL,
  "ApiResourceId" int4 NOT NULL
)
;

-- ----------------------------
-- Records of ApiResourceSecrets
-- ----------------------------

-- ----------------------------
-- Table structure for ApiResources
-- ----------------------------
DROP TABLE IF EXISTS "public"."ApiResources";
CREATE TABLE "public"."ApiResources" (
  "Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "Enabled" bool NOT NULL,
  "Name" varchar(200) COLLATE "pg_catalog"."default" NOT NULL,
  "DisplayName" varchar(200) COLLATE "pg_catalog"."default",
  "Description" varchar(1000) COLLATE "pg_catalog"."default",
  "AllowedAccessTokenSigningAlgorithms" varchar(100) COLLATE "pg_catalog"."default",
  "ShowInDiscoveryDocument" bool NOT NULL,
  "Created" timestamp(6) NOT NULL,
  "Updated" timestamp(6),
  "LastAccessed" timestamp(6),
  "NonEditable" bool NOT NULL
)
;

-- ----------------------------
-- Records of ApiResources
-- ----------------------------

-- ----------------------------
-- Table structure for ApiScopeClaims
-- ----------------------------
DROP TABLE IF EXISTS "public"."ApiScopeClaims";
CREATE TABLE "public"."ApiScopeClaims" (
  "Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "Type" varchar(200) COLLATE "pg_catalog"."default" NOT NULL,
  "ScopeId" int4 NOT NULL
)
;

-- ----------------------------
-- Records of ApiScopeClaims
-- ----------------------------

-- ----------------------------
-- Table structure for ApiScopeProperties
-- ----------------------------
DROP TABLE IF EXISTS "public"."ApiScopeProperties";
CREATE TABLE "public"."ApiScopeProperties" (
  "Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "Key" varchar(250) COLLATE "pg_catalog"."default" NOT NULL,
  "Value" varchar(2000) COLLATE "pg_catalog"."default" NOT NULL,
  "ScopeId" int4 NOT NULL
)
;

-- ----------------------------
-- Records of ApiScopeProperties
-- ----------------------------

-- ----------------------------
-- Table structure for ApiScopes
-- ----------------------------
DROP TABLE IF EXISTS "public"."ApiScopes";
CREATE TABLE "public"."ApiScopes" (
  "Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "Enabled" bool NOT NULL,
  "Name" varchar(200) COLLATE "pg_catalog"."default" NOT NULL,
  "DisplayName" varchar(200) COLLATE "pg_catalog"."default",
  "Description" varchar(1000) COLLATE "pg_catalog"."default",
  "Required" bool NOT NULL,
  "Emphasize" bool NOT NULL,
  "ShowInDiscoveryDocument" bool NOT NULL
)
;

-- ----------------------------
-- Records of ApiScopes
-- ----------------------------
INSERT INTO "public"."ApiScopes" VALUES (1, 't', 'api1', 'Test Api', '这是一个测试API', 'f', 'f', 't');

-- ----------------------------
-- Table structure for ClientClaims
-- ----------------------------
DROP TABLE IF EXISTS "public"."ClientClaims";
CREATE TABLE "public"."ClientClaims" (
  "Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "Type" varchar(250) COLLATE "pg_catalog"."default" NOT NULL,
  "Value" varchar(250) COLLATE "pg_catalog"."default" NOT NULL,
  "ClientId" int4 NOT NULL
)
;

-- ----------------------------
-- Records of ClientClaims
-- ----------------------------

-- ----------------------------
-- Table structure for ClientCorsOrigins
-- ----------------------------
DROP TABLE IF EXISTS "public"."ClientCorsOrigins";
CREATE TABLE "public"."ClientCorsOrigins" (
  "Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "Origin" varchar(150) COLLATE "pg_catalog"."default" NOT NULL,
  "ClientId" int4 NOT NULL
)
;

-- ----------------------------
-- Records of ClientCorsOrigins
-- ----------------------------
INSERT INTO "public"."ClientCorsOrigins" VALUES (5, 'http://127.0.0.1:5002', 15);

-- ----------------------------
-- Table structure for ClientGrantTypes
-- ----------------------------
DROP TABLE IF EXISTS "public"."ClientGrantTypes";
CREATE TABLE "public"."ClientGrantTypes" (
  "Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "GrantType" varchar(250) COLLATE "pg_catalog"."default" NOT NULL,
  "ClientId" int4 NOT NULL
)
;

-- ----------------------------
-- Records of ClientGrantTypes
-- ----------------------------
INSERT INTO "public"."ClientGrantTypes" VALUES (6, 'password', 15);
INSERT INTO "public"."ClientGrantTypes" VALUES (7, 'client_credentials', 15);

-- ----------------------------
-- Table structure for ClientIdPRestrictions
-- ----------------------------
DROP TABLE IF EXISTS "public"."ClientIdPRestrictions";
CREATE TABLE "public"."ClientIdPRestrictions" (
  "Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "Provider" varchar(200) COLLATE "pg_catalog"."default" NOT NULL,
  "ClientId" int4 NOT NULL
)
;

-- ----------------------------
-- Records of ClientIdPRestrictions
-- ----------------------------

-- ----------------------------
-- Table structure for ClientPostLogoutRedirectUris
-- ----------------------------
DROP TABLE IF EXISTS "public"."ClientPostLogoutRedirectUris";
CREATE TABLE "public"."ClientPostLogoutRedirectUris" (
  "Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "PostLogoutRedirectUri" varchar(2000) COLLATE "pg_catalog"."default" NOT NULL,
  "ClientId" int4 NOT NULL
)
;

-- ----------------------------
-- Records of ClientPostLogoutRedirectUris
-- ----------------------------
INSERT INTO "public"."ClientPostLogoutRedirectUris" VALUES (5, 'http://127.0.0.1:5001/logout', 15);

-- ----------------------------
-- Table structure for ClientProperties
-- ----------------------------
DROP TABLE IF EXISTS "public"."ClientProperties";
CREATE TABLE "public"."ClientProperties" (
  "Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "Key" varchar(250) COLLATE "pg_catalog"."default" NOT NULL,
  "Value" varchar(2000) COLLATE "pg_catalog"."default" NOT NULL,
  "ClientId" int4 NOT NULL
)
;

-- ----------------------------
-- Records of ClientProperties
-- ----------------------------

-- ----------------------------
-- Table structure for ClientRedirectUris
-- ----------------------------
DROP TABLE IF EXISTS "public"."ClientRedirectUris";
CREATE TABLE "public"."ClientRedirectUris" (
  "Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "RedirectUri" varchar(2000) COLLATE "pg_catalog"."default" NOT NULL,
  "ClientId" int4 NOT NULL
)
;

-- ----------------------------
-- Records of ClientRedirectUris
-- ----------------------------
INSERT INTO "public"."ClientRedirectUris" VALUES (6, 'http://127.0.0.1:5001/login', 15);

-- ----------------------------
-- Table structure for ClientScopes
-- ----------------------------
DROP TABLE IF EXISTS "public"."ClientScopes";
CREATE TABLE "public"."ClientScopes" (
  "Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "Scope" varchar(200) COLLATE "pg_catalog"."default" NOT NULL,
  "ClientId" int4 NOT NULL
)
;

-- ----------------------------
-- Records of ClientScopes
-- ----------------------------
INSERT INTO "public"."ClientScopes" VALUES (8, 'openid', 15);
INSERT INTO "public"."ClientScopes" VALUES (9, 'profile', 15);
INSERT INTO "public"."ClientScopes" VALUES (5, 'api1', 15);

-- ----------------------------
-- Table structure for ClientSecrets
-- ----------------------------
DROP TABLE IF EXISTS "public"."ClientSecrets";
CREATE TABLE "public"."ClientSecrets" (
  "Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "Description" varchar(2000) COLLATE "pg_catalog"."default",
  "Value" varchar(4000) COLLATE "pg_catalog"."default" NOT NULL,
  "Expiration" timestamp(6),
  "Type" varchar(250) COLLATE "pg_catalog"."default" NOT NULL,
  "Created" timestamp(6) NOT NULL,
  "ClientId" int4 NOT NULL
)
;

-- ----------------------------
-- Records of ClientSecrets
-- ----------------------------
INSERT INTO "public"."ClientSecrets" VALUES (5, '测试', 'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', '2022-09-09 02:55:04.59', 'SharedSecret', '2020-09-10 16:52:50.723394', 15);

-- ----------------------------
-- Table structure for Clients
-- ----------------------------
DROP TABLE IF EXISTS "public"."Clients";
CREATE TABLE "public"."Clients" (
  "Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "Enabled" bool NOT NULL,
  "ClientId" varchar(200) COLLATE "pg_catalog"."default" NOT NULL,
  "ProtocolType" varchar(200) COLLATE "pg_catalog"."default" NOT NULL,
  "RequireClientSecret" bool NOT NULL,
  "ClientName" varchar(200) COLLATE "pg_catalog"."default",
  "Description" varchar(1000) COLLATE "pg_catalog"."default",
  "ClientUri" varchar(2000) COLLATE "pg_catalog"."default",
  "LogoUri" varchar(2000) COLLATE "pg_catalog"."default",
  "RequireConsent" bool NOT NULL,
  "AllowRememberConsent" bool NOT NULL,
  "AlwaysIncludeUserClaimsInIdToken" bool NOT NULL,
  "RequirePkce" bool NOT NULL,
  "AllowPlainTextPkce" bool NOT NULL,
  "RequireRequestObject" bool NOT NULL,
  "AllowAccessTokensViaBrowser" bool NOT NULL,
  "FrontChannelLogoutUri" varchar(2000) COLLATE "pg_catalog"."default",
  "FrontChannelLogoutSessionRequired" bool NOT NULL,
  "BackChannelLogoutUri" varchar(2000) COLLATE "pg_catalog"."default",
  "BackChannelLogoutSessionRequired" bool NOT NULL,
  "AllowOfflineAccess" bool NOT NULL,
  "IdentityTokenLifetime" int4 NOT NULL,
  "AllowedIdentityTokenSigningAlgorithms" varchar(100) COLLATE "pg_catalog"."default",
  "AccessTokenLifetime" int4 NOT NULL,
  "AuthorizationCodeLifetime" int4 NOT NULL,
  "ConsentLifetime" int4,
  "AbsoluteRefreshTokenLifetime" int4 NOT NULL,
  "SlidingRefreshTokenLifetime" int4 NOT NULL,
  "RefreshTokenUsage" int4 NOT NULL,
  "UpdateAccessTokenClaimsOnRefresh" bool NOT NULL,
  "RefreshTokenExpiration" int4 NOT NULL,
  "AccessTokenType" int4 NOT NULL,
  "EnableLocalLogin" bool NOT NULL,
  "IncludeJwtId" bool NOT NULL,
  "AlwaysSendClientClaims" bool NOT NULL,
  "ClientClaimsPrefix" varchar(200) COLLATE "pg_catalog"."default",
  "PairWiseSubjectSalt" varchar(200) COLLATE "pg_catalog"."default",
  "Created" timestamp(6) NOT NULL,
  "Updated" timestamp(6),
  "LastAccessed" timestamp(6),
  "UserSsoLifetime" int4,
  "UserCodeType" varchar(100) COLLATE "pg_catalog"."default",
  "DeviceCodeLifetime" int4 NOT NULL,
  "NonEditable" bool NOT NULL
)
;

-- ----------------------------
-- Records of Clients
-- ----------------------------
INSERT INTO "public"."Clients" VALUES (15, 't', 'mvc', 'oidc', 't', 'mvc client', 'MVC客户端', '', '', 'f', 't', 't', 't', 't', 't', 't', '', 't', '', 't', 't', 300, '', 3600, 300, NULL, 2592000, 1296000, 1, 't', 1, 0, 't', 't', 't', 'client_', '', '2020-09-10 16:52:52.585424', NULL, NULL, NULL, '', 300, 'f');

-- ----------------------------
-- Table structure for DeviceCodes
-- ----------------------------
DROP TABLE IF EXISTS "public"."DeviceCodes";
CREATE TABLE "public"."DeviceCodes" (
  "UserCode" varchar(200) COLLATE "pg_catalog"."default" NOT NULL,
  "DeviceCode" varchar(200) COLLATE "pg_catalog"."default" NOT NULL,
  "SubjectId" varchar(200) COLLATE "pg_catalog"."default",
  "SessionId" varchar(100) COLLATE "pg_catalog"."default",
  "ClientId" varchar(200) COLLATE "pg_catalog"."default" NOT NULL,
  "Description" varchar(200) COLLATE "pg_catalog"."default",
  "CreationTime" timestamp(6) NOT NULL,
  "Expiration" timestamp(6) NOT NULL,
  "Data" varchar(50000) COLLATE "pg_catalog"."default" NOT NULL
)
;

-- ----------------------------
-- Records of DeviceCodes
-- ----------------------------

-- ----------------------------
-- Table structure for IdentityResourceClaims
-- ----------------------------
DROP TABLE IF EXISTS "public"."IdentityResourceClaims";
CREATE TABLE "public"."IdentityResourceClaims" (
  "Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "Type" varchar(200) COLLATE "pg_catalog"."default" NOT NULL,
  "IdentityResourceId" int4 NOT NULL
)
;

-- ----------------------------
-- Records of IdentityResourceClaims
-- ----------------------------

-- ----------------------------
-- Table structure for IdentityResourceProperties
-- ----------------------------
DROP TABLE IF EXISTS "public"."IdentityResourceProperties";
CREATE TABLE "public"."IdentityResourceProperties" (
  "Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "Key" varchar(250) COLLATE "pg_catalog"."default" NOT NULL,
  "Value" varchar(2000) COLLATE "pg_catalog"."default" NOT NULL,
  "IdentityResourceId" int4 NOT NULL
)
;

-- ----------------------------
-- Records of IdentityResourceProperties
-- ----------------------------

-- ----------------------------
-- Table structure for IdentityResources
-- ----------------------------
DROP TABLE IF EXISTS "public"."IdentityResources";
CREATE TABLE "public"."IdentityResources" (
  "Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "Enabled" bool NOT NULL,
  "Name" varchar(200) COLLATE "pg_catalog"."default" NOT NULL,
  "DisplayName" varchar(200) COLLATE "pg_catalog"."default",
  "Description" varchar(1000) COLLATE "pg_catalog"."default",
  "Required" bool NOT NULL,
  "Emphasize" bool NOT NULL,
  "ShowInDiscoveryDocument" bool NOT NULL,
  "Created" timestamp(6) NOT NULL,
  "Updated" timestamp(6),
  "NonEditable" bool NOT NULL
)
;

-- ----------------------------
-- Records of IdentityResources
-- ----------------------------
INSERT INTO "public"."IdentityResources" VALUES (7, 't', 'profile', 'User profile', 'Your user profile information (first name, last name, etc.)', 'f', 't', 't', '0001-01-01 00:18:00', '0001-01-01 00:00:00', 'f');
INSERT INTO "public"."IdentityResources" VALUES (8, 't', 'openid', 'Your user identifier', 'NULL', 't', 'f', 't', '0001-01-01 00:18:00', '0001-01-01 00:00:00', 'f');

-- ----------------------------
-- Table structure for PersistedGrants
-- ----------------------------
DROP TABLE IF EXISTS "public"."PersistedGrants";
CREATE TABLE "public"."PersistedGrants" (
  "Key" varchar(200) COLLATE "pg_catalog"."default" NOT NULL,
  "Type" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "SubjectId" varchar(200) COLLATE "pg_catalog"."default",
  "SessionId" varchar(100) COLLATE "pg_catalog"."default",
  "ClientId" varchar(200) COLLATE "pg_catalog"."default" NOT NULL,
  "Description" varchar(200) COLLATE "pg_catalog"."default",
  "CreationTime" timestamp(6) NOT NULL,
  "Expiration" timestamp(6),
  "ConsumedTime" timestamp(6),
  "Data" varchar(50000) COLLATE "pg_catalog"."default" NOT NULL
)
;

-- ----------------------------
-- Records of PersistedGrants
-- ----------------------------
INSERT INTO "public"."PersistedGrants" VALUES ('ZqLwLho8t0Nccc7HCtaDrGVzXHDlVlILf8Ns6VJm840=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-10 12:01:24', '2020-10-10 12:01:24', NULL, '{"CreationTime":"2020-09-10T12:01:24Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://127.0.0.1:5000/resources"],"Issuer":"https://127.0.0.1:5000","CreationTime":"2020-09-10T12:01:24Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599739284","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"B7E20C081FB78B458BBA90D22EC60C53","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599739284","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('Oupsuq5hdF/X4yXgKhbgMrSrzhMrFVbkjlBz76yPbaI=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-10 15:05:29', '2020-10-10 15:05:29', NULL, '{"CreationTime":"2020-09-10T15:05:29Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-10T15:05:29Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599750329","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"16F3B12BA86F1179BEB07FBF9FC80996","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599750329","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('En2bi0nIZIe+Up+LUipcnFWVfOixQXV+BrpX2G6X11k=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-10 15:08:06', '2020-10-10 15:08:06', NULL, '{"CreationTime":"2020-09-10T15:08:06Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-10T15:08:06Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599750486","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"E2395E7B3733291FE19776FA43A392AA","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599750486","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('U7b1yLFpIBNGZWlWcz8Zly5jMxPq+urPAq9Wx5WZwFE=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-10 15:08:19', '2020-10-10 15:08:19', NULL, '{"CreationTime":"2020-09-10T15:08:19Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-10T15:08:19Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599750499","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"E3D49D35DB53B0E090748B50A6092451","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599750499","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('3gpYSDHMpxb4XRCdcD1oZj1MSmZeFLanuTb2lqjqQvo=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-10 15:21:03', '2020-10-10 15:21:03', NULL, '{"CreationTime":"2020-09-10T15:21:03Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-10T15:21:03Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599751263","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"D0AB6C6915EB465A92EC560D8DCC5809","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599751263","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('/o1zMGGflMVjmoii7TLZBdH/JCOCuLNe3+ALr0TK/yM=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-10 15:23:58', '2020-10-10 15:23:58', NULL, '{"CreationTime":"2020-09-10T15:23:58Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-10T15:23:58Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599751438","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"6D148C3B68B4616243095D2774936B47","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599751438","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('dSDmRwIsdc3fST09J/9CbQA9e/i7JUBYZqpE8euuY6g=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-10 15:32:58', '2020-10-10 15:32:58', NULL, '{"CreationTime":"2020-09-10T15:32:58Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-10T15:32:58Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599751978","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"DA7325DD3B96CCF34A25F1A017061FD8","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599751978","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('fitJUeO2YvRh2tQNhGnyJ/Hdy6ZvimShAr+2DMKFCdo=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-10 15:42:44', '2020-10-10 15:42:44', NULL, '{"CreationTime":"2020-09-10T15:42:44Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-10T15:42:44Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599752564","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"5BD3F8FBC1958000FD50DD15482B293C","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599752564","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('eov6d2ACpOk7+RdwKGORyiGpcYxN3oiRsI0qPl7K6tg=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-10 15:43:49', '2020-10-10 15:43:49', NULL, '{"CreationTime":"2020-09-10T15:43:49Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-10T15:43:48Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599752628","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"2F0B3295DE40860BE02D66FB6A303D92","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599752628","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('l5Br74lykz1QqVlOrOp4O800Tb87ZhpOpSncMOF6H2U=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-10 15:45:30', '2020-10-10 15:45:30', NULL, '{"CreationTime":"2020-09-10T15:45:30Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-10T15:45:30Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599752730","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"B1F463FECFD18E35F703166ACDCD1F1C","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599752730","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('mzUH94fypjchu4yR4pVLcJgYsO7Pce+HIZ3W6mUeCyk=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-10 15:48:52', '2020-10-10 15:48:52', NULL, '{"CreationTime":"2020-09-10T15:48:52Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-10T15:48:52Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599752932","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"A2DCB021D9A7976D2F7B4CC09A927BAF","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599752932","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('GoUAYQYlbqE2CBNI+ND3YYCUWs4J/u9aDKXZS+WrlfM=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-10 16:14:40', '2020-10-10 16:14:40', NULL, '{"CreationTime":"2020-09-10T16:14:40Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-10T16:14:40Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599754480","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"0A0B22CB7A3DF43359FDF7D56519EC44","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599754480","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('iCbT2whtamUT+Nyz6csDpGqpKHXcoyG3Ey8dL9/SbU0=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-10 16:16:49', '2020-10-10 16:16:49', NULL, '{"CreationTime":"2020-09-10T16:16:49Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-10T16:16:49Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599754609","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"C2E0C1FDCDB64B03553696FBEE3BE6C6","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599754609","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('vx4mTAPaVbFTwsyfnfAJp4qKrrS97Y8mb+m7xDdVRLA=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-10 16:18:57', '2020-10-10 16:18:57', NULL, '{"CreationTime":"2020-09-10T16:18:57Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-10T16:18:56Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599754736","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"A1482C2A809CCC19EFAFDF7DAC7AFEC2","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599754736","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('N0h5FKmA40zrlJ8vH6BzniuNKoRI7MyBfy2hgUMx0wI=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-10 16:30:44', '2020-10-10 16:30:44', NULL, '{"CreationTime":"2020-09-10T16:30:44Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-10T16:30:44Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599755444","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"F4AA00352F732546099387BD898F0B63","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599755444","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('cjqjKB8LbVyFQwLDMjEsa5Cys7iZCoKhsy5jk6mf8vE=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-10 16:46:03', '2020-10-10 16:46:03', NULL, '{"CreationTime":"2020-09-10T16:46:03Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-10T16:46:03Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599756363","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"0A3CA24C137C62C8FFFD34B32EC8ACD3","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599756363","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('d6RnsfwhOxhPEXs5F4mEON7EeHcdRgqFsgMSr7tSuug=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-10 16:50:07', '2020-10-10 16:50:07', NULL, '{"CreationTime":"2020-09-10T16:50:07Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://127.0.0.1:5000/resources"],"Issuer":"https://127.0.0.1:5000","CreationTime":"2020-09-10T16:50:07Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599756607","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"2AC3AEAE22C0F2FDE51F3D28F9706A47","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599756607","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('SiXTf8OTgNHLiTu+MxEop4uTtRW+ByBFCMxV2Ou33js=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-10 16:53:19', '2020-10-10 16:53:19', NULL, '{"CreationTime":"2020-09-10T16:53:19Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://127.0.0.1:5000/resources"],"Issuer":"https://127.0.0.1:5000","CreationTime":"2020-09-10T16:53:19Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599756799","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"26D4B25D39F0532E58A6C7A2D4C70417","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599756799","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('Pnih3wAPBzKAuZM3pyGtjRT0K5T4Z3p2KHmcb/EWawU=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-10 17:00:01', '2020-10-10 17:00:01', NULL, '{"CreationTime":"2020-09-10T17:00:01Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://127.0.0.1:5000/resources"],"Issuer":"https://127.0.0.1:5000","CreationTime":"2020-09-10T17:00:01Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599757201","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"E4E0FF627618A06D63E6712CAA13D13E","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599757201","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('sLmLcjZNywlt9+ALCnbWiR2CuEz28NatC+TLjXOspUQ=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-10 17:01:49', '2020-10-10 17:01:49', NULL, '{"CreationTime":"2020-09-10T17:01:49Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://127.0.0.1:5000/resources"],"Issuer":"https://127.0.0.1:5000","CreationTime":"2020-09-10T17:01:49Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599757309","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"9A50C3C4E00796B8A197CBB2AE141CE9","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599757309","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('RddyVid9qPY+thml4h41iGmUR0gZGF4Lq3BJLzNgUTg=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-10 17:05:00', '2020-10-10 17:05:00', NULL, '{"CreationTime":"2020-09-10T17:05:00Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-10T17:05:00Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599757500","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"E6C0B9C367719F22DD0305FA8B3E81EE","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599757500","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('aa43IkGX9TBiEgwOh/PjozXejn2gYlvLAApfXtn9Y5I=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-10 17:05:49', '2020-10-10 17:05:49', NULL, '{"CreationTime":"2020-09-10T17:05:49Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-10T17:05:49Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599757549","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"2FCF30B046680B1CAEA22441C8811FD0","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599757549","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('s5JWeVsYswJvZ4WF/duME07EUeuKfVQtT0PVROOfaY0=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-10 17:06:53', '2020-10-10 17:06:53', NULL, '{"CreationTime":"2020-09-10T17:06:53Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-10T17:06:53Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599757613","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"E1561FFF0CB411516B7BBE17F0AA71B0","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599757613","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('Da/rW/pDxciMA91mXBwqTSu6wjaBU9ZTMI7ihcKLuMI=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-10 17:13:41', '2020-10-10 17:13:41', NULL, '{"CreationTime":"2020-09-10T17:13:41Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-10T17:13:41Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599758021","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"29263931DDACD312EFD96B6289485530","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599758021","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('iE/XU3bsx7m6eeka9R2FkX8QBS611Q//8eU/r36drOs=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-11 01:07:39', '2020-10-11 01:07:39', NULL, '{"CreationTime":"2020-09-11T01:07:39Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-11T01:07:38Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"testapi","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599786458","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"CD532517BBE0977E276020FCBB26B4FA","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599786458","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('xaLHvpdMlC4begiHMM9H85bGEU5+b1s3SJqTkv4xRYo=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-11 01:25:27', '2020-10-11 01:25:27', NULL, '{"CreationTime":"2020-09-11T01:25:27Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-11T01:25:27Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599787527","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"D5A2BAA12AD8FE74017914F9BFF08904","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599787527","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('1ofZBgjF6ThgLsdjnMjFxf1Pw6TJrC8RT+p9a4i/Vq8=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-11 01:33:38', '2020-10-11 01:33:38', NULL, '{"CreationTime":"2020-09-11T01:33:38Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-11T01:33:38Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599788018","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"049D83F813550B03F9B39789B19F2C9F","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599788018","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('JT40sTFGKlbyXSY5e2rUqJqgmDcdapsm2O8R0AKjFc0=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-11 01:35:18', '2020-10-11 01:35:18', NULL, '{"CreationTime":"2020-09-11T01:35:18Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-11T01:35:18Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599788118","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"DA93BA51DCC43AF42BAF7448F43FA42B","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599788118","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('vJL5bep36NwOYJ1fAx3/aGdKXsZUAioWnV7SHzAzqg8=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-11 04:33:53', '2020-10-11 04:33:53', NULL, '{"CreationTime":"2020-09-11T04:33:53Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-11T04:33:53Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599798833","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"D6A19DA172FAB93A0882291669ECF38E","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599798833","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('03n8hVfKi4CDz7+yU4fMmHdm8kWIOyb7oULLTqgPM5A=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-11 04:35:14', '2020-10-11 04:35:14', NULL, '{"CreationTime":"2020-09-11T04:35:14Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-11T04:35:14Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599798914","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"CEB52F25F8C03249ECDC21ADF987D4E8","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599798914","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('oL3gpjCBZhIvp1x+/F31jQa1o8M5T2UKAu2FM1YdLRA=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-11 07:05:55', '2020-10-11 07:05:55', NULL, '{"CreationTime":"2020-09-11T07:05:55Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-11T07:05:55Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599807955","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"7DCF15CC466EA55FD05081E918376694","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599807955","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('gKc+67zdOjeKegMQ1zFfiGloaDc87TCZ2gQi4nTqDd0=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-11 07:55:35', '2020-10-11 07:55:35', NULL, '{"CreationTime":"2020-09-11T07:55:35Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-11T07:55:34Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599810934","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"0EAF8AE1A5AA71859D0E3630F6408C5F","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599810934","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('uU9fGE+c9e2roAN2U0LWyfqcDMAgFKwpNAydGRUjLao=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-11 08:16:04', '2020-10-11 08:16:04', NULL, '{"CreationTime":"2020-09-11T08:16:04Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-11T08:16:04Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599812164","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"43861B3EDCB7D638A75CA37550F3934E","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599812164","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('XAL16cOfl14BnFKJVHp/TDTzYw799E6fLglIocDWv6s=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-11 08:22:07', '2020-10-11 08:22:07', NULL, '{"CreationTime":"2020-09-11T08:22:07Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-11T08:22:07Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599812527","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"6CDE71BED080E6F7C5AB87C5A3D5B619","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599812527","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('97vb5/3CX+ycm0uEjYZg77Pqcar3wxI++aX9YOO9oEs=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-11 08:27:13', '2020-10-11 08:27:13', NULL, '{"CreationTime":"2020-09-11T08:27:13Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-11T08:27:13Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599812833","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"0D006F4EEC9C1FC649A71646A953166F","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599812833","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('gY278mpT7fGqQ27rGCW8b30rGq14id01bvEH8EX2vIk=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-11 08:33:10', '2020-10-11 08:33:10', NULL, '{"CreationTime":"2020-09-11T08:33:10Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-11T08:33:10Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599813190","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"E130EA3CB8710AD0955FAD8C31E134BD","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599813190","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('hUzSKE0rGL5os/VPCX44iV4JfJl3fDCBVr4q3jrzs6U=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-11 08:39:58', '2020-10-11 08:39:58', NULL, '{"CreationTime":"2020-09-11T08:39:58Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-11T08:39:58Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599813598","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"914DDFA10F91F8E5231748D4AC2F6450","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599813598","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('BGpse73Ru2mAqLvy/BlNpkE+4m+of6cod6sDwMtKo/Q=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-11 08:47:44', '2020-10-11 08:47:44', NULL, '{"CreationTime":"2020-09-11T08:47:44Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-11T08:47:44Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599814064","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"621D42860241DF8FC246E41B6371588D","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599814064","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('8snIXIq/JJfajf5EDVrYVt7sbHAz42Tf2JFSUzuSpG8=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-11 08:52:06', '2020-10-11 08:52:06', NULL, '{"CreationTime":"2020-09-11T08:52:06Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-11T08:52:06Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599814326","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"F3439D7028D65C561B1A91C843A0204F","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599814326","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('nPSdEzQHvoLqY6tnhbi3f3nwnGaI4XQRD+rOfkqLaTg=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-11 08:53:46', '2020-10-11 08:53:46', NULL, '{"CreationTime":"2020-09-11T08:53:46Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-11T08:53:46Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599814426","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"4C4116BFE5DCCDFD34A723AB455846F9","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599814426","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('McOyvGhi5iWXRh+0B5ihU939oVWXlrfUBTC8cfQoDbY=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-11 08:57:57', '2020-10-11 08:57:57', NULL, '{"CreationTime":"2020-09-11T08:57:57Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-11T08:57:57Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599814677","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"CB887DF3E10D06C1AB08FE8B0CD16F3C","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599814677","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('bWjqFhe4qaFPAB4eZx5blooPdH2AC31VNzSPIRBpdOc=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-11 09:00:52', '2020-10-11 09:00:52', NULL, '{"CreationTime":"2020-09-11T09:00:52Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-11T09:00:52Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599814852","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"DB949DCD2C99D5799773D624801B0E29","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599814852","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('ePipL5IhmxZ6aTlgWkERHSjIx/gUIx2RDPJr47r1oHc=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-11 09:04:21', '2020-10-11 09:04:21', NULL, '{"CreationTime":"2020-09-11T09:04:21Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-11T09:04:21Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599815061","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"F6F155D53BB6D0DC976FDE57F1C16E82","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599815061","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('WH9oqdXwQT9wsDlUuNIpLrp6vLWDAvie2RVazTlX0QU=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-11 09:21:59', '2020-10-11 09:21:59', NULL, '{"CreationTime":"2020-09-11T09:21:59Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-11T09:21:59Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599816119","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"F2FD594720A87F6CA22BDF7EE0E3178B","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599816119","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');
INSERT INTO "public"."PersistedGrants" VALUES ('YmBlzM3KrRMd4t34T186WgsQbHKUJJdYCSQUU6q1Azs=', 'refresh_token', 'admin', NULL, 'mvc', NULL, '2020-09-11 09:43:59', '2020-10-11 09:43:59', NULL, '{"CreationTime":"2020-09-11T09:43:59Z","Lifetime":2592000,"ConsumedTime":null,"AccessToken":{"AllowedSigningAlgorithms":[],"Confirmation":null,"Audiences":["https://localhost:5000/resources"],"Issuer":"https://localhost:5000","CreationTime":"2020-09-11T09:43:59Z","Lifetime":3600,"Type":"access_token","ClientId":"mvc","AccessTokenType":0,"Description":null,"Claims":[{"Type":"client_id","Value":"mvc","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"api1","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"openid","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"profile","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"scope","Value":"offline_access","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"sub","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"auth_time","Value":"1599817439","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"},{"Type":"idp","Value":"local","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"amr","Value":"custom","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"id","Value":"1993b5c7-309a-4b61-b2b2-5a798a212a0c","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"name","Value":"admin","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"jti","Value":"16CA3F68AABC4CDE74B55FA0329AB0CF","ValueType":"http://www.w3.org/2001/XMLSchema#string"},{"Type":"iat","Value":"1599817439","ValueType":"http://www.w3.org/2001/XMLSchema#integer64"}],"Version":4},"Version":4}');

-- ----------------------------
-- Table structure for Users
-- ----------------------------
DROP TABLE IF EXISTS "public"."Users";
CREATE TABLE "public"."Users" (
  "Id" uuid NOT NULL,
  "Username" text COLLATE "pg_catalog"."default" NOT NULL,
  "Password" text COLLATE "pg_catalog"."default" NOT NULL,
  "Enabled" bool NOT NULL
)
;

-- ----------------------------
-- Records of Users
-- ----------------------------
INSERT INTO "public"."Users" VALUES ('1993b5c7-309a-4b61-b2b2-5a798a212a0c', 'admin', '123456', 't');

-- ----------------------------
-- Table structure for __EFMigrationsHistory
-- ----------------------------
DROP TABLE IF EXISTS "public"."__EFMigrationsHistory";
CREATE TABLE "public"."__EFMigrationsHistory" (
  "MigrationId" varchar(150) COLLATE "pg_catalog"."default" NOT NULL,
  "ProductVersion" varchar(32) COLLATE "pg_catalog"."default" NOT NULL
)
;

-- ----------------------------
-- Records of __EFMigrationsHistory
-- ----------------------------
INSERT INTO "public"."__EFMigrationsHistory" VALUES ('20200906152611_InitialIdentityServerPersistedGrantDbMigration', '3.1.5');
INSERT INTO "public"."__EFMigrationsHistory" VALUES ('20200906155405_InitialIdentityServerConfigurationDbMigration', '3.1.5');
INSERT INTO "public"."__EFMigrationsHistory" VALUES ('20200907013951_Init', '3.1.7');

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."ApiResourceClaims_Id_seq"
OWNED BY "public"."ApiResourceClaims"."Id";
SELECT setval('"public"."ApiResourceClaims_Id_seq"', 2, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."ApiResourceProperties_Id_seq"
OWNED BY "public"."ApiResourceProperties"."Id";
SELECT setval('"public"."ApiResourceProperties_Id_seq"', 2, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."ApiResourceScopes_Id_seq"
OWNED BY "public"."ApiResourceScopes"."Id";
SELECT setval('"public"."ApiResourceScopes_Id_seq"', 2, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."ApiResourceSecrets_Id_seq"
OWNED BY "public"."ApiResourceSecrets"."Id";
SELECT setval('"public"."ApiResourceSecrets_Id_seq"', 2, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."ApiResources_Id_seq"
OWNED BY "public"."ApiResources"."Id";
SELECT setval('"public"."ApiResources_Id_seq"', 2, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."ApiScopeClaims_Id_seq"
OWNED BY "public"."ApiScopeClaims"."Id";
SELECT setval('"public"."ApiScopeClaims_Id_seq"', 2, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."ApiScopeProperties_Id_seq"
OWNED BY "public"."ApiScopeProperties"."Id";
SELECT setval('"public"."ApiScopeProperties_Id_seq"', 2, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."ApiScopes_Id_seq"
OWNED BY "public"."ApiScopes"."Id";
SELECT setval('"public"."ApiScopes_Id_seq"', 2, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."ClientClaims_Id_seq"
OWNED BY "public"."ClientClaims"."Id";
SELECT setval('"public"."ClientClaims_Id_seq"', 2, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."ClientCorsOrigins_Id_seq"
OWNED BY "public"."ClientCorsOrigins"."Id";
SELECT setval('"public"."ClientCorsOrigins_Id_seq"', 6, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."ClientGrantTypes_Id_seq"
OWNED BY "public"."ClientGrantTypes"."Id";
SELECT setval('"public"."ClientGrantTypes_Id_seq"', 8, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."ClientIdPRestrictions_Id_seq"
OWNED BY "public"."ClientIdPRestrictions"."Id";
SELECT setval('"public"."ClientIdPRestrictions_Id_seq"', 2, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."ClientPostLogoutRedirectUris_Id_seq"
OWNED BY "public"."ClientPostLogoutRedirectUris"."Id";
SELECT setval('"public"."ClientPostLogoutRedirectUris_Id_seq"', 6, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."ClientProperties_Id_seq"
OWNED BY "public"."ClientProperties"."Id";
SELECT setval('"public"."ClientProperties_Id_seq"', 2, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."ClientRedirectUris_Id_seq"
OWNED BY "public"."ClientRedirectUris"."Id";
SELECT setval('"public"."ClientRedirectUris_Id_seq"', 7, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."ClientScopes_Id_seq"
OWNED BY "public"."ClientScopes"."Id";
SELECT setval('"public"."ClientScopes_Id_seq"', 10, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."ClientSecrets_Id_seq"
OWNED BY "public"."ClientSecrets"."Id";
SELECT setval('"public"."ClientSecrets_Id_seq"', 6, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."Clients_Id_seq"
OWNED BY "public"."Clients"."Id";
SELECT setval('"public"."Clients_Id_seq"', 16, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."IdentityResourceClaims_Id_seq"
OWNED BY "public"."IdentityResourceClaims"."Id";
SELECT setval('"public"."IdentityResourceClaims_Id_seq"', 5, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."IdentityResourceProperties_Id_seq"
OWNED BY "public"."IdentityResourceProperties"."Id";
SELECT setval('"public"."IdentityResourceProperties_Id_seq"', 5, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."IdentityResources_Id_seq"
OWNED BY "public"."IdentityResources"."Id";
SELECT setval('"public"."IdentityResources_Id_seq"', 9, true);

-- ----------------------------
-- Indexes structure for table ApiResourceClaims
-- ----------------------------
CREATE INDEX "IX_ApiResourceClaims_ApiResourceId" ON "public"."ApiResourceClaims" USING btree (
  "ApiResourceId" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table ApiResourceClaims
-- ----------------------------
ALTER TABLE "public"."ApiResourceClaims" ADD CONSTRAINT "PK_ApiResourceClaims" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table ApiResourceProperties
-- ----------------------------
CREATE INDEX "IX_ApiResourceProperties_ApiResourceId" ON "public"."ApiResourceProperties" USING btree (
  "ApiResourceId" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table ApiResourceProperties
-- ----------------------------
ALTER TABLE "public"."ApiResourceProperties" ADD CONSTRAINT "PK_ApiResourceProperties" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table ApiResourceScopes
-- ----------------------------
CREATE INDEX "IX_ApiResourceScopes_ApiResourceId" ON "public"."ApiResourceScopes" USING btree (
  "ApiResourceId" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table ApiResourceScopes
-- ----------------------------
ALTER TABLE "public"."ApiResourceScopes" ADD CONSTRAINT "PK_ApiResourceScopes" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table ApiResourceSecrets
-- ----------------------------
CREATE INDEX "IX_ApiResourceSecrets_ApiResourceId" ON "public"."ApiResourceSecrets" USING btree (
  "ApiResourceId" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table ApiResourceSecrets
-- ----------------------------
ALTER TABLE "public"."ApiResourceSecrets" ADD CONSTRAINT "PK_ApiResourceSecrets" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table ApiResources
-- ----------------------------
CREATE UNIQUE INDEX "IX_ApiResources_Name" ON "public"."ApiResources" USING btree (
  "Name" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table ApiResources
-- ----------------------------
ALTER TABLE "public"."ApiResources" ADD CONSTRAINT "PK_ApiResources" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table ApiScopeClaims
-- ----------------------------
CREATE INDEX "IX_ApiScopeClaims_ScopeId" ON "public"."ApiScopeClaims" USING btree (
  "ScopeId" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table ApiScopeClaims
-- ----------------------------
ALTER TABLE "public"."ApiScopeClaims" ADD CONSTRAINT "PK_ApiScopeClaims" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table ApiScopeProperties
-- ----------------------------
CREATE INDEX "IX_ApiScopeProperties_ScopeId" ON "public"."ApiScopeProperties" USING btree (
  "ScopeId" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table ApiScopeProperties
-- ----------------------------
ALTER TABLE "public"."ApiScopeProperties" ADD CONSTRAINT "PK_ApiScopeProperties" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table ApiScopes
-- ----------------------------
CREATE UNIQUE INDEX "IX_ApiScopes_Name" ON "public"."ApiScopes" USING btree (
  "Name" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table ApiScopes
-- ----------------------------
ALTER TABLE "public"."ApiScopes" ADD CONSTRAINT "PK_ApiScopes" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table ClientClaims
-- ----------------------------
CREATE INDEX "IX_ClientClaims_ClientId" ON "public"."ClientClaims" USING btree (
  "ClientId" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table ClientClaims
-- ----------------------------
ALTER TABLE "public"."ClientClaims" ADD CONSTRAINT "PK_ClientClaims" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table ClientCorsOrigins
-- ----------------------------
CREATE INDEX "IX_ClientCorsOrigins_ClientId" ON "public"."ClientCorsOrigins" USING btree (
  "ClientId" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table ClientCorsOrigins
-- ----------------------------
ALTER TABLE "public"."ClientCorsOrigins" ADD CONSTRAINT "PK_ClientCorsOrigins" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table ClientGrantTypes
-- ----------------------------
CREATE INDEX "IX_ClientGrantTypes_ClientId" ON "public"."ClientGrantTypes" USING btree (
  "ClientId" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table ClientGrantTypes
-- ----------------------------
ALTER TABLE "public"."ClientGrantTypes" ADD CONSTRAINT "PK_ClientGrantTypes" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table ClientIdPRestrictions
-- ----------------------------
CREATE INDEX "IX_ClientIdPRestrictions_ClientId" ON "public"."ClientIdPRestrictions" USING btree (
  "ClientId" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table ClientIdPRestrictions
-- ----------------------------
ALTER TABLE "public"."ClientIdPRestrictions" ADD CONSTRAINT "PK_ClientIdPRestrictions" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table ClientPostLogoutRedirectUris
-- ----------------------------
CREATE INDEX "IX_ClientPostLogoutRedirectUris_ClientId" ON "public"."ClientPostLogoutRedirectUris" USING btree (
  "ClientId" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table ClientPostLogoutRedirectUris
-- ----------------------------
ALTER TABLE "public"."ClientPostLogoutRedirectUris" ADD CONSTRAINT "PK_ClientPostLogoutRedirectUris" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table ClientProperties
-- ----------------------------
CREATE INDEX "IX_ClientProperties_ClientId" ON "public"."ClientProperties" USING btree (
  "ClientId" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table ClientProperties
-- ----------------------------
ALTER TABLE "public"."ClientProperties" ADD CONSTRAINT "PK_ClientProperties" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table ClientRedirectUris
-- ----------------------------
CREATE INDEX "IX_ClientRedirectUris_ClientId" ON "public"."ClientRedirectUris" USING btree (
  "ClientId" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table ClientRedirectUris
-- ----------------------------
ALTER TABLE "public"."ClientRedirectUris" ADD CONSTRAINT "PK_ClientRedirectUris" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table ClientScopes
-- ----------------------------
CREATE INDEX "IX_ClientScopes_ClientId" ON "public"."ClientScopes" USING btree (
  "ClientId" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table ClientScopes
-- ----------------------------
ALTER TABLE "public"."ClientScopes" ADD CONSTRAINT "PK_ClientScopes" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table ClientSecrets
-- ----------------------------
CREATE INDEX "IX_ClientSecrets_ClientId" ON "public"."ClientSecrets" USING btree (
  "ClientId" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table ClientSecrets
-- ----------------------------
ALTER TABLE "public"."ClientSecrets" ADD CONSTRAINT "PK_ClientSecrets" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table Clients
-- ----------------------------
CREATE UNIQUE INDEX "IX_Clients_ClientId" ON "public"."Clients" USING btree (
  "ClientId" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table Clients
-- ----------------------------
ALTER TABLE "public"."Clients" ADD CONSTRAINT "PK_Clients" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table DeviceCodes
-- ----------------------------
CREATE UNIQUE INDEX "IX_DeviceCodes_DeviceCode" ON "public"."DeviceCodes" USING btree (
  "DeviceCode" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST
);
CREATE INDEX "IX_DeviceCodes_Expiration" ON "public"."DeviceCodes" USING btree (
  "Expiration" "pg_catalog"."timestamp_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table DeviceCodes
-- ----------------------------
ALTER TABLE "public"."DeviceCodes" ADD CONSTRAINT "PK_DeviceCodes" PRIMARY KEY ("UserCode");

-- ----------------------------
-- Indexes structure for table IdentityResourceClaims
-- ----------------------------
CREATE INDEX "IX_IdentityResourceClaims_IdentityResourceId" ON "public"."IdentityResourceClaims" USING btree (
  "IdentityResourceId" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table IdentityResourceClaims
-- ----------------------------
ALTER TABLE "public"."IdentityResourceClaims" ADD CONSTRAINT "PK_IdentityResourceClaims" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table IdentityResourceProperties
-- ----------------------------
CREATE INDEX "IX_IdentityResourceProperties_IdentityResourceId" ON "public"."IdentityResourceProperties" USING btree (
  "IdentityResourceId" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table IdentityResourceProperties
-- ----------------------------
ALTER TABLE "public"."IdentityResourceProperties" ADD CONSTRAINT "PK_IdentityResourceProperties" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table IdentityResources
-- ----------------------------
CREATE UNIQUE INDEX "IX_IdentityResources_Name" ON "public"."IdentityResources" USING btree (
  "Name" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table IdentityResources
-- ----------------------------
ALTER TABLE "public"."IdentityResources" ADD CONSTRAINT "PK_IdentityResources" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table PersistedGrants
-- ----------------------------
CREATE INDEX "IX_PersistedGrants_Expiration" ON "public"."PersistedGrants" USING btree (
  "Expiration" "pg_catalog"."timestamp_ops" ASC NULLS LAST
);
CREATE INDEX "IX_PersistedGrants_SubjectId_ClientId_Type" ON "public"."PersistedGrants" USING btree (
  "SubjectId" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST,
  "ClientId" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST,
  "Type" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST
);
CREATE INDEX "IX_PersistedGrants_SubjectId_SessionId_Type" ON "public"."PersistedGrants" USING btree (
  "SubjectId" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST,
  "SessionId" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST,
  "Type" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table PersistedGrants
-- ----------------------------
ALTER TABLE "public"."PersistedGrants" ADD CONSTRAINT "PK_PersistedGrants" PRIMARY KEY ("Key");

-- ----------------------------
-- Primary Key structure for table Users
-- ----------------------------
ALTER TABLE "public"."Users" ADD CONSTRAINT "PK_Users" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table __EFMigrationsHistory
-- ----------------------------
ALTER TABLE "public"."__EFMigrationsHistory" ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");

-- ----------------------------
-- Foreign Keys structure for table ApiResourceClaims
-- ----------------------------
ALTER TABLE "public"."ApiResourceClaims" ADD CONSTRAINT "FK_ApiResourceClaims_ApiResources_ApiResourceId" FOREIGN KEY ("ApiResourceId") REFERENCES "public"."ApiResources" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table ApiResourceProperties
-- ----------------------------
ALTER TABLE "public"."ApiResourceProperties" ADD CONSTRAINT "FK_ApiResourceProperties_ApiResources_ApiResourceId" FOREIGN KEY ("ApiResourceId") REFERENCES "public"."ApiResources" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table ApiResourceScopes
-- ----------------------------
ALTER TABLE "public"."ApiResourceScopes" ADD CONSTRAINT "FK_ApiResourceScopes_ApiResources_ApiResourceId" FOREIGN KEY ("ApiResourceId") REFERENCES "public"."ApiResources" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table ApiResourceSecrets
-- ----------------------------
ALTER TABLE "public"."ApiResourceSecrets" ADD CONSTRAINT "FK_ApiResourceSecrets_ApiResources_ApiResourceId" FOREIGN KEY ("ApiResourceId") REFERENCES "public"."ApiResources" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table ApiScopeClaims
-- ----------------------------
ALTER TABLE "public"."ApiScopeClaims" ADD CONSTRAINT "FK_ApiScopeClaims_ApiScopes_ScopeId" FOREIGN KEY ("ScopeId") REFERENCES "public"."ApiScopes" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table ApiScopeProperties
-- ----------------------------
ALTER TABLE "public"."ApiScopeProperties" ADD CONSTRAINT "FK_ApiScopeProperties_ApiScopes_ScopeId" FOREIGN KEY ("ScopeId") REFERENCES "public"."ApiScopes" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table ClientClaims
-- ----------------------------
ALTER TABLE "public"."ClientClaims" ADD CONSTRAINT "FK_ClientClaims_Clients_ClientId" FOREIGN KEY ("ClientId") REFERENCES "public"."Clients" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table ClientCorsOrigins
-- ----------------------------
ALTER TABLE "public"."ClientCorsOrigins" ADD CONSTRAINT "FK_ClientCorsOrigins_Clients_ClientId" FOREIGN KEY ("ClientId") REFERENCES "public"."Clients" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table ClientGrantTypes
-- ----------------------------
ALTER TABLE "public"."ClientGrantTypes" ADD CONSTRAINT "FK_ClientGrantTypes_Clients_ClientId" FOREIGN KEY ("ClientId") REFERENCES "public"."Clients" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table ClientIdPRestrictions
-- ----------------------------
ALTER TABLE "public"."ClientIdPRestrictions" ADD CONSTRAINT "FK_ClientIdPRestrictions_Clients_ClientId" FOREIGN KEY ("ClientId") REFERENCES "public"."Clients" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table ClientPostLogoutRedirectUris
-- ----------------------------
ALTER TABLE "public"."ClientPostLogoutRedirectUris" ADD CONSTRAINT "FK_ClientPostLogoutRedirectUris_Clients_ClientId" FOREIGN KEY ("ClientId") REFERENCES "public"."Clients" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table ClientProperties
-- ----------------------------
ALTER TABLE "public"."ClientProperties" ADD CONSTRAINT "FK_ClientProperties_Clients_ClientId" FOREIGN KEY ("ClientId") REFERENCES "public"."Clients" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table ClientRedirectUris
-- ----------------------------
ALTER TABLE "public"."ClientRedirectUris" ADD CONSTRAINT "FK_ClientRedirectUris_Clients_ClientId" FOREIGN KEY ("ClientId") REFERENCES "public"."Clients" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table ClientScopes
-- ----------------------------
ALTER TABLE "public"."ClientScopes" ADD CONSTRAINT "FK_ClientScopes_Clients_ClientId" FOREIGN KEY ("ClientId") REFERENCES "public"."Clients" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table ClientSecrets
-- ----------------------------
ALTER TABLE "public"."ClientSecrets" ADD CONSTRAINT "FK_ClientSecrets_Clients_ClientId" FOREIGN KEY ("ClientId") REFERENCES "public"."Clients" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table IdentityResourceClaims
-- ----------------------------
ALTER TABLE "public"."IdentityResourceClaims" ADD CONSTRAINT "FK_IdentityResourceClaims_IdentityResources_IdentityResourceId" FOREIGN KEY ("IdentityResourceId") REFERENCES "public"."IdentityResources" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table IdentityResourceProperties
-- ----------------------------
ALTER TABLE "public"."IdentityResourceProperties" ADD CONSTRAINT "FK_IdentityResourceProperties_IdentityResources_IdentityResour~" FOREIGN KEY ("IdentityResourceId") REFERENCES "public"."IdentityResources" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;
