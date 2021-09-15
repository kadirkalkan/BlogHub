using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogHub.Data.Migrations
{
    public partial class add_article_picture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArticlePicture",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArticlePicture",
                table: "Articles");
        }
    }
}
