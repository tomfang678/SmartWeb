using Smart.Framework.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smart.Core.Log;
using System.Data.Entity;
using Smart.Account.Contract.Model;

namespace Smart.Account.DAL
{
    public class AccountDBContext : DbContextBase
    {
        public AccountDBContext()
            : base("")
        {

        }
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<AccountDBContext>(null);
            modelBuilder.Entity<User>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Users)
                .Map(m =>
                {
                    m.ToTable("UserRole");
                    m.MapLeftKey("UserID");
                    m.MapRightKey("RoleID");
                });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<LoginInfo> LoginInfos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
