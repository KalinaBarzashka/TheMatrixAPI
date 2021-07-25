using Microsoft.EntityFrameworkCore.Migrations;

namespace TheMatrixAPI.Data.Migrations
{
    public partial class AddedActorCharacterRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActorId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Actors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ActorId",
                table: "Characters",
                column: "ActorId",
                unique: true,
                filter: "[ActorId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Actors_ActorId",
                table: "Characters",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Actors_ActorId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_ActorId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Actors");
        }
    }
}
