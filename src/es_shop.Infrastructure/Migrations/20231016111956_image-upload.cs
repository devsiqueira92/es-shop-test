using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class imageupload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_SHIRT_SPECIFICATION_IMAGES",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_IMAGE = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_SHIRT_SPECIFICATION = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DAT_CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DAT_UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FLG_IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SHIRT_SPECIFICATION_IMAGES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_SHIRT_SPECIFICATION_IMAGES_TB_SHIRT_SPECIFICATION_COD_SHIRT_SPECIFICATION",
                        column: x => x.COD_SHIRT_SPECIFICATION,
                        principalTable: "TB_SHIRT_SPECIFICATION",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_SHIRT_SPECIFICATION_IMAGES_COD_SHIRT_SPECIFICATION",
                table: "TB_SHIRT_SPECIFICATION_IMAGES",
                column: "COD_SHIRT_SPECIFICATION");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_SHIRT_SPECIFICATION_IMAGES");
        }
    }
}
