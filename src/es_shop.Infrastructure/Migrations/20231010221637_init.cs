using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_COLOR",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TXT_COLOR = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DAT_CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DAT_UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FLG_IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_COLOR", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_TYPE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TXT_TYPE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DAT_CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DAT_UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FLG_IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TYPE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_SHIRT",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TXT_NAME = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    COD_COLOR = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_FABRIC = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DAT_CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DAT_UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FLG_IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SHIRT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_SHIRT_TB_COLOR_COD_COLOR",
                        column: x => x.COD_COLOR,
                        principalTable: "TB_COLOR",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TB_SHIRT_TB_TYPE_COD_FABRIC",
                        column: x => x.COD_FABRIC,
                        principalTable: "TB_TYPE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_SHIRT_COD_COLOR",
                table: "TB_SHIRT",
                column: "COD_COLOR");

            migrationBuilder.CreateIndex(
                name: "IX_TB_SHIRT_COD_FABRIC",
                table: "TB_SHIRT",
                column: "COD_FABRIC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_SHIRT");

            migrationBuilder.DropTable(
                name: "TB_COLOR");

            migrationBuilder.DropTable(
                name: "TB_TYPE");
        }
    }
}
