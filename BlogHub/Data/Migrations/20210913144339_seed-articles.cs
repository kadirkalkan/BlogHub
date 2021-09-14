using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogHub.Data.Migrations
{
    public partial class seedarticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedTime", "Title" },
                values: new object[,]
                {
                    { 15, "1d936220-0fb7-49bf-aa42-b5634f9481fe", "This is New Article Content You'll learn a lot of things from this article. Article No : 0", new DateTime(2021, 9, 13, 17, 43, 39, 233, DateTimeKind.Local).AddTicks(1358), "New Article Title0" },
                    { 16, "1d936220-0fb7-49bf-aa42-b5634f9481fe", "This is New Article Content You'll learn a lot of things from this article. Article No : 1", new DateTime(2021, 9, 13, 17, 43, 39, 234, DateTimeKind.Local).AddTicks(7640), "New Article Title1" },
                    { 17, "1d936220-0fb7-49bf-aa42-b5634f9481fe", "This is New Article Content You'll learn a lot of things from this article. Article No : 2", new DateTime(2021, 9, 13, 17, 43, 39, 234, DateTimeKind.Local).AddTicks(7752), "New Article Title2" },
                    { 18, "1d936220-0fb7-49bf-aa42-b5634f9481fe", "This is New Article Content You'll learn a lot of things from this article. Article No : 3", new DateTime(2021, 9, 13, 17, 43, 39, 234, DateTimeKind.Local).AddTicks(7770), "New Article Title3" },
                    { 19, "1d936220-0fb7-49bf-aa42-b5634f9481fe", "This is New Article Content You'll learn a lot of things from this article. Article No : 4", new DateTime(2021, 9, 13, 17, 43, 39, 234, DateTimeKind.Local).AddTicks(7783), "New Article Title4" },
                    { 20, "1d936220-0fb7-49bf-aa42-b5634f9481fe", "This is New Article Content You'll learn a lot of things from this article. Article No : 5", new DateTime(2021, 9, 13, 17, 43, 39, 234, DateTimeKind.Local).AddTicks(7800), "New Article Title5" },
                    { 21, "1d936220-0fb7-49bf-aa42-b5634f9481fe", "This is New Article Content You'll learn a lot of things from this article. Article No : 6", new DateTime(2021, 9, 13, 17, 43, 39, 234, DateTimeKind.Local).AddTicks(7813), "New Article Title6" },
                    { 22, "1d936220-0fb7-49bf-aa42-b5634f9481fe", "This is New Article Content You'll learn a lot of things from this article. Article No : 7", new DateTime(2021, 9, 13, 17, 43, 39, 234, DateTimeKind.Local).AddTicks(7826), "New Article Title7" },
                    { 23, "1d936220-0fb7-49bf-aa42-b5634f9481fe", "This is New Article Content You'll learn a lot of things from this article. Article No : 8", new DateTime(2021, 9, 13, 17, 43, 39, 234, DateTimeKind.Local).AddTicks(7838), "New Article Title8" },
                    { 24, "1d936220-0fb7-49bf-aa42-b5634f9481fe", "This is New Article Content You'll learn a lot of things from this article. Article No : 9", new DateTime(2021, 9, 13, 17, 43, 39, 234, DateTimeKind.Local).AddTicks(7897), "New Article Title9" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 24);
        }
    }
}
