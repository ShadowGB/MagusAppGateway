using Microsoft.EntityFrameworkCore;
using IdentityServer4.EntityFramework.Entities;
using MagusAppGateway.Models;

namespace MagusAppGateway.Contexts
{
    public class UserDatabaseContext:DbContext
    {
        public UserDatabaseContext(DbContextOptions<UserDatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //用户表主键
            modelBuilder.Entity<Users>().HasKey(x => x.Id);
            //身份认证资源
            modelBuilder.Entity<IdentityResourceProperty>().HasOne(x => x.IdentityResource).WithMany(x => x.Properties).HasForeignKey(x => x.IdentityResourceId);
            modelBuilder.Entity<IdentityResourceClaim>().HasOne(x => x.IdentityResource).WithMany(x => x.UserClaims).HasForeignKey(x => x.IdentityResourceId);
            //API
            modelBuilder.Entity<ApiScopeClaim>().HasOne(x => x.Scope).WithMany(x => x.UserClaims).HasForeignKey(x => x.ScopeId);
            //modelBuilder.Entity<ApiScopeProperty>().HasOne(x =>x.Scope).WithMany(x => x.Properties).HasForeignKey(x => x.ScopeId);
            //Client
            modelBuilder.Entity<ClientIdPRestriction>().HasOne(x => x.Client).WithMany(x => x.IdentityProviderRestrictions).HasForeignKey(x => x.ClientId);
            modelBuilder.Entity<ClientClaim>().HasOne(x => x.Client).WithMany(x => x.Claims).HasForeignKey(x => x.ClientId);
            modelBuilder.Entity<ClientCorsOrigin>().HasOne(x => x.Client).WithMany(x => x.AllowedCorsOrigins).HasForeignKey(x => x.ClientId);
            modelBuilder.Entity<ClientProperty>().HasOne(x => x.Client).WithMany(x => x.Properties).HasForeignKey(x => x.ClientId);
            modelBuilder.Entity<ClientScope>().HasOne(x => x.Client).WithMany(x => x.AllowedScopes).HasForeignKey(x => x.ClientId);
            modelBuilder.Entity<ClientSecret>().HasOne(x => x.Client).WithMany(x => x.ClientSecrets).HasForeignKey(x => x.ClientId);
            modelBuilder.Entity<ClientGrantType>().HasOne(x => x.Client).WithMany(x => x.AllowedGrantTypes).HasForeignKey(x => x.ClientId);
            modelBuilder.Entity<ClientRedirectUri>().HasOne(x => x.Client).WithMany(x => x.RedirectUris).HasForeignKey(x => x.ClientId);
            modelBuilder.Entity<ClientPostLogoutRedirectUri>().HasOne(x => x.Client).WithMany(x => x.PostLogoutRedirectUris).HasForeignKey(x => x.ClientId);


        }

        public DbSet<Users> Users { get; set; }

        #region 身份资源
        public DbSet<IdentityResource> IdentityResources { get; set; }

        public DbSet<IdentityResourceProperty> IdentityResourceProperties { get; set; }

        public DbSet<IdentityResourceClaim> IdentityResourceClaims { get; set; }
        #endregion

        #region API
        public DbSet<ApiScope> ApiScopes { get; set; }

        public DbSet<ApiScopeClaim> ApiScopeClaims { get; set; }

        public DbSet<ApiResourceProperty> ApiScopeProperties { get; set; }
        #endregion

        #region Client
        public DbSet<Client> Clients { get; set; }

        public DbSet<ClientIdPRestriction> ClientIdPRestrictions { get; set; }

        public DbSet<ClientClaim> ClientClaims { get; set; }

        public DbSet<ClientCorsOrigin> ClientCorsOrigins { get; set; }

        public DbSet<ClientProperty> ClientProperties { get; set; }

        public DbSet<ClientScope> ClientScopes { get; set; }

        public DbSet<ClientSecret> ClientSecrets { get; set; }

        public DbSet<ClientGrantType> ClientGrantTypes { get; set; }

        public DbSet<ClientRedirectUri> ClientRedirectUris { get; set; }

        public DbSet<ClientPostLogoutRedirectUri> ClientPostLogoutRedirectUris { get; set; } 
        #endregion
    }
}
