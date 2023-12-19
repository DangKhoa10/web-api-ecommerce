using AppAuth.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAuth.Data
{
    public class DataContext : IdentityDbContext<UserDTO, RoleDTO , string>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserDTO>(entity =>
            {
                entity.ToTable("K_Users");
            });
            builder.Entity<RoleDTO>(entity =>
            {
                entity.ToTable("K_Roles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("K_UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("K_UserLogins");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("K_UserRoles");

            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("K_UserTokens");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("K_RoleClaims");
            });

        }
    }
}
