using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication.Migrations
{
    /// <inheritdoc />
    public partial class studentAzibtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "studenttable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Session_ID = table.Column<int>(type: "int", nullable: false),
                    Programe_ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateofBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousSchool = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplyDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PreviousPercentage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studenttable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studenttable_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studenttable_ProgrameTables_Programe_ID",
                        column: x => x.Programe_ID,
                        principalTable: "ProgrameTables",
                        principalColumn: "ProgrameId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_studenttable_sessiontables_Session_ID",
                        column: x => x.Session_ID,
                        principalTable: "sessiontables",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studenttable_Programe_ID",
                table: "studenttable",
                column: "Programe_ID");

            migrationBuilder.CreateIndex(
                name: "IX_studenttable_Session_ID",
                table: "studenttable",
                column: "Session_ID");

            migrationBuilder.CreateIndex(
                name: "IX_studenttable_UserId",
                table: "studenttable",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studenttable");
        }
    }
}
