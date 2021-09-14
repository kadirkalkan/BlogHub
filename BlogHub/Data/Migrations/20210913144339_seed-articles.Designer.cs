﻿// <auto-generated />
using System;
using BlogHub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlogHub.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210913144339_seed-articles")]
    partial class seedarticles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlogHub.Data.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = 15,
                            AuthorId = "1d936220-0fb7-49bf-aa42-b5634f9481fe",
                            Content = "This is New Article Content You'll learn a lot of things from this article. Article No : 0",
                            CreatedTime = new DateTime(2021, 9, 13, 17, 43, 39, 233, DateTimeKind.Local).AddTicks(1358),
                            Title = "New Article Title0"
                        },
                        new
                        {
                            Id = 16,
                            AuthorId = "1d936220-0fb7-49bf-aa42-b5634f9481fe",
                            Content = "This is New Article Content You'll learn a lot of things from this article. Article No : 1",
                            CreatedTime = new DateTime(2021, 9, 13, 17, 43, 39, 234, DateTimeKind.Local).AddTicks(7640),
                            Title = "New Article Title1"
                        },
                        new
                        {
                            Id = 17,
                            AuthorId = "1d936220-0fb7-49bf-aa42-b5634f9481fe",
                            Content = "This is New Article Content You'll learn a lot of things from this article. Article No : 2",
                            CreatedTime = new DateTime(2021, 9, 13, 17, 43, 39, 234, DateTimeKind.Local).AddTicks(7752),
                            Title = "New Article Title2"
                        },
                        new
                        {
                            Id = 18,
                            AuthorId = "1d936220-0fb7-49bf-aa42-b5634f9481fe",
                            Content = "This is New Article Content You'll learn a lot of things from this article. Article No : 3",
                            CreatedTime = new DateTime(2021, 9, 13, 17, 43, 39, 234, DateTimeKind.Local).AddTicks(7770),
                            Title = "New Article Title3"
                        },
                        new
                        {
                            Id = 19,
                            AuthorId = "1d936220-0fb7-49bf-aa42-b5634f9481fe",
                            Content = "This is New Article Content You'll learn a lot of things from this article. Article No : 4",
                            CreatedTime = new DateTime(2021, 9, 13, 17, 43, 39, 234, DateTimeKind.Local).AddTicks(7783),
                            Title = "New Article Title4"
                        },
                        new
                        {
                            Id = 20,
                            AuthorId = "1d936220-0fb7-49bf-aa42-b5634f9481fe",
                            Content = "This is New Article Content You'll learn a lot of things from this article. Article No : 5",
                            CreatedTime = new DateTime(2021, 9, 13, 17, 43, 39, 234, DateTimeKind.Local).AddTicks(7800),
                            Title = "New Article Title5"
                        },
                        new
                        {
                            Id = 21,
                            AuthorId = "1d936220-0fb7-49bf-aa42-b5634f9481fe",
                            Content = "This is New Article Content You'll learn a lot of things from this article. Article No : 6",
                            CreatedTime = new DateTime(2021, 9, 13, 17, 43, 39, 234, DateTimeKind.Local).AddTicks(7813),
                            Title = "New Article Title6"
                        },
                        new
                        {
                            Id = 22,
                            AuthorId = "1d936220-0fb7-49bf-aa42-b5634f9481fe",
                            Content = "This is New Article Content You'll learn a lot of things from this article. Article No : 7",
                            CreatedTime = new DateTime(2021, 9, 13, 17, 43, 39, 234, DateTimeKind.Local).AddTicks(7826),
                            Title = "New Article Title7"
                        },
                        new
                        {
                            Id = 23,
                            AuthorId = "1d936220-0fb7-49bf-aa42-b5634f9481fe",
                            Content = "This is New Article Content You'll learn a lot of things from this article. Article No : 8",
                            CreatedTime = new DateTime(2021, 9, 13, 17, 43, 39, 234, DateTimeKind.Local).AddTicks(7838),
                            Title = "New Article Title8"
                        },
                        new
                        {
                            Id = 24,
                            AuthorId = "1d936220-0fb7-49bf-aa42-b5634f9481fe",
                            Content = "This is New Article Content You'll learn a lot of things from this article. Article No : 9",
                            CreatedTime = new DateTime(2021, 9, 13, 17, 43, 39, 234, DateTimeKind.Local).AddTicks(7897),
                            Title = "New Article Title9"
                        });
                });

            modelBuilder.Entity("BlogHub.Data.Models.HubUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BlogHub.Data.Models.Article", b =>
                {
                    b.HasOne("BlogHub.Data.Models.HubUser", "Author")
                        .WithMany("ArticleList")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BlogHub.Data.Models.HubUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BlogHub.Data.Models.HubUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlogHub.Data.Models.HubUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BlogHub.Data.Models.HubUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlogHub.Data.Models.HubUser", b =>
                {
                    b.Navigation("ArticleList");
                });
#pragma warning restore 612, 618
        }
    }
}