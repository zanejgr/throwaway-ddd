using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roots",
                columns: table => new
                {
                    RootId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsOkay = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roots", x => x.RootId);
                });

            migrationBuilder.CreateTable(
                name: "SharedObjects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UniqueProperties",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    RootId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniqueProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniqueProperties_Roots_RootId",
                        column: x => x.RootId,
                        principalTable: "Roots",
                        principalColumn: "RootId");
                });

            migrationBuilder.CreateTable(
                name: "RootSharedObject",
                columns: table => new
                {
                    RootsRootId = table.Column<int>(type: "INTEGER", nullable: false),
                    SharedObjectsId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootSharedObject", x => new { x.RootsRootId, x.SharedObjectsId });
                    table.ForeignKey(
                        name: "FK_RootSharedObject_Roots_RootsRootId",
                        column: x => x.RootsRootId,
                        principalTable: "Roots",
                        principalColumn: "RootId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootSharedObject_SharedObjects_SharedObjectsId",
                        column: x => x.SharedObjectsId,
                        principalTable: "SharedObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RootSharedObject_SharedObjectsId",
                table: "RootSharedObject",
                column: "SharedObjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_UniqueProperties_RootId",
                table: "UniqueProperties",
                column: "RootId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RootSharedObject");

            migrationBuilder.DropTable(
                name: "UniqueProperties");

            migrationBuilder.DropTable(
                name: "SharedObjects");

            migrationBuilder.DropTable(
                name: "Roots");
        }
    }
}
