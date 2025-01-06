using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoundBoard.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoundFiletypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoundFiletypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoundLibrary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoundLibrary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoundLibrary_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Musicfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhaseId = table.Column<int>(type: "int", nullable: false),
                    SoundFiletypeId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoundLibraryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musicfiles_Phase_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Phase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Musicfiles_SoundFiletypes_SoundFiletypeId",
                        column: x => x.SoundFiletypeId,
                        principalTable: "SoundFiletypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Musicfiles_SoundLibrary_SoundLibraryId",
                        column: x => x.SoundLibraryId,
                        principalTable: "SoundLibrary",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SoundFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoundFiletypeId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoundLibraryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoundFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoundFiles_SoundFiletypes_SoundFiletypeId",
                        column: x => x.SoundFiletypeId,
                        principalTable: "SoundFiletypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoundFiles_SoundLibrary_SoundLibraryId",
                        column: x => x.SoundLibraryId,
                        principalTable: "SoundLibrary",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Musicfiles_PhaseId",
                table: "Musicfiles",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Musicfiles_SoundFiletypeId",
                table: "Musicfiles",
                column: "SoundFiletypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Musicfiles_SoundLibraryId",
                table: "Musicfiles",
                column: "SoundLibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_SoundFiles_SoundFiletypeId",
                table: "SoundFiles",
                column: "SoundFiletypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SoundFiles_SoundLibraryId",
                table: "SoundFiles",
                column: "SoundLibraryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Musicfiles");

            migrationBuilder.DropTable(
                name: "SoundFiles");

            migrationBuilder.DropTable(
                name: "Phase");

            migrationBuilder.DropTable(
                name: "SoundFiletypes");

            migrationBuilder.DropTable(
                name: "SoundLibrary");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
