using Microsoft.EntityFrameworkCore.Migrations;

namespace TheMatrixAPI.Data.Migrations
{
    public partial class AddedTokenIdInApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TokenId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TokenId",
                table: "AspNetUsers");
        }
    }
}
