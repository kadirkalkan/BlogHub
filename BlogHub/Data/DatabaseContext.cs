using BlogHub.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogHub.Data
{
    // Default ApplicationDBContext
    public class DatabaseContext : IdentityDbContext<HubUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Article>().Property(e => e.CreatedTime).HasDefaultValueSql("getutcdate()");

            /*
             * 
             * 
             * Identity Server Register İşleminde Oluşturduğu Kullanıcıya Ait Bilgileri Kendi Bünyesinde Barındırıp Bu Bilgilerle Her Login İşleminde Karşılaştırma Gerçekleştirdiğinden Dolayı Manuel Olarak Oluşturduğumuz Kullanıcılar Sisteme Login Olmazlar. Seed İşleminde Kullanıcı Oluşturamadığımızdan Kullanıcı İle Alakalı Diğer Tabloların Seed Edilmeside Mümkün Değildir.
             
            var passwordHashCreator = new PasswordHasher<HubUser>();
            var user = new HubUser()
            {
                Id = Guid.NewGuid().ToString(),         // Guid
                FullName = "Kadir KALKAN",              // String
                Email = "kadir.kalkan@bilgeadam.com",   // String
            };
            user.UserName = user.Email;
            user.NormalizedUserName = user.UserName.ToUpper();
            user.NormalizedEmail = user.Email.ToUpper();
            user.PasswordHash = passwordHashCreator.HashPassword(user, "Ankara1.");

            builder.Entity<HubUser>().HasData(user);

            for (int i = 0; i < 10; i++)
            {
                builder.Entity<Article>().HasData(new Article() { Id = 15 + i, Title = "New Article Title No : " + i, Content = "This is New Article Content You'll learn a lot of things from this article. Article No : " + i, AuthorId = user.Id });
            }
             
             */
        }

        public DbSet<Article> Articles { get; set; }
    }
}
