using BlogHub.Data.Models;
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
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Article>().Property(e => e.CreatedTime).HasDefaultValueSql("getutcdate()");

            for (int i = 0; i < 10; i++)
            {
                builder.Entity<Article>().HasData(new Article() { Id = 15 + i, Title = "New Article Title" + i, Content = "This is New Article Content You'll learn a lot of things from this article. Article No : " + i, AuthorId = "1d936220-0fb7-49bf-aa42-b5634f9481fe" });
            }
        }

        public DbSet<Article> Articles { get; set; }
    }
}
