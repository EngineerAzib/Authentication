using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication.Migrations
{
    /// <inheritdoc />
    public partial class designationtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentTables",
                table: "StudentTables");

            migrationBuilder.RenameTable(
                name: "StudentTables",
                newName: "SubjectTables");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectTables",
                table: "SubjectTables",
                column: "SubjectID");

            migrationBuilder.CreateTable(
                name: "DesignationTable",
                columns: table => new
                {
                    DesignationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(459)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignationTable", x => x.DesignationID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesignationTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectTables",
                table: "SubjectTables");

            migrationBuilder.RenameTable(
                name: "SubjectTables",
                newName: "StudentTables");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentTables",
                table: "StudentTables",
                column: "SubjectID");
        }
    }
}
