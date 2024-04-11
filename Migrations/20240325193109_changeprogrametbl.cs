using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication.Migrations
{
    /// <inheritdoc />
    public partial class changeprogrametbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgrameTables_AspNetUsers_UserId",
                table: "ProgrameTables");

            migrationBuilder.DropIndex(
                name: "IX_ProgrameTables_UserId",
                table: "ProgrameTables");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProgrameTables");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ProgrameTables",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrameTables_UserId",
                table: "ProgrameTables",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrameTables_AspNetUsers_UserId",
                table: "ProgrameTables",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
