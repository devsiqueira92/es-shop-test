using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class shirtspecification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_SHIRT_TB_COLOR_COD_COLOR",
                table: "TB_SHIRT");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_SHIRT_TB_TYPE_COD_FABRIC",
                table: "TB_SHIRT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_SHIRT",
                table: "TB_SHIRT");

            migrationBuilder.DropIndex(
                name: "IX_TB_SHIRT_COD_COLOR",
                table: "TB_SHIRT");

            migrationBuilder.DropIndex(
                name: "IX_TB_SHIRT_COD_FABRIC",
                table: "TB_SHIRT");

            migrationBuilder.DropColumn(
                name: "COD_COLOR",
                table: "TB_SHIRT");

            migrationBuilder.DropColumn(
                name: "COD_FABRIC",
                table: "TB_SHIRT");

            migrationBuilder.RenameTable(
                name: "TB_SHIRT",
                newName: "Shirts");

            migrationBuilder.RenameColumn(
                name: "TXT_NAME",
                table: "Shirts",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Shirts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shirts",
                table: "Shirts",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "TB_SHIRT_SPECIFICATION",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_COLOR = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_FABRIC = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_SHIRT = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShirtEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DAT_CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DAT_UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FLG_IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SHIRT_SPECIFICATION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_SHIRT_SPECIFICATION_Shirts_COD_SHIRT",
                        column: x => x.COD_SHIRT,
                        principalTable: "Shirts",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TB_SHIRT_SPECIFICATION_Shirts_ShirtEntityId",
                        column: x => x.ShirtEntityId,
                        principalTable: "Shirts",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TB_SHIRT_SPECIFICATION_TB_COLOR_COD_COLOR",
                        column: x => x.COD_COLOR,
                        principalTable: "TB_COLOR",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TB_SHIRT_SPECIFICATION_TB_TYPE_COD_FABRIC",
                        column: x => x.COD_FABRIC,
                        principalTable: "TB_TYPE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_SHIRT_SPECIFICATION_COD_COLOR",
                table: "TB_SHIRT_SPECIFICATION",
                column: "COD_COLOR");

            migrationBuilder.CreateIndex(
                name: "IX_TB_SHIRT_SPECIFICATION_COD_FABRIC",
                table: "TB_SHIRT_SPECIFICATION",
                column: "COD_FABRIC");

            migrationBuilder.CreateIndex(
                name: "IX_TB_SHIRT_SPECIFICATION_COD_SHIRT",
                table: "TB_SHIRT_SPECIFICATION",
                column: "COD_SHIRT");

            migrationBuilder.CreateIndex(
                name: "IX_TB_SHIRT_SPECIFICATION_ShirtEntityId",
                table: "TB_SHIRT_SPECIFICATION",
                column: "ShirtEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_SHIRT_SPECIFICATION");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shirts",
                table: "Shirts");

            migrationBuilder.RenameTable(
                name: "Shirts",
                newName: "TB_SHIRT");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TB_SHIRT",
                newName: "TXT_NAME");

            migrationBuilder.AlterColumn<string>(
                name: "TXT_NAME",
                table: "TB_SHIRT",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "COD_COLOR",
                table: "TB_SHIRT",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "COD_FABRIC",
                table: "TB_SHIRT",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_SHIRT",
                table: "TB_SHIRT",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_SHIRT_COD_COLOR",
                table: "TB_SHIRT",
                column: "COD_COLOR");

            migrationBuilder.CreateIndex(
                name: "IX_TB_SHIRT_COD_FABRIC",
                table: "TB_SHIRT",
                column: "COD_FABRIC");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_SHIRT_TB_COLOR_COD_COLOR",
                table: "TB_SHIRT",
                column: "COD_COLOR",
                principalTable: "TB_COLOR",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_SHIRT_TB_TYPE_COD_FABRIC",
                table: "TB_SHIRT",
                column: "COD_FABRIC",
                principalTable: "TB_TYPE",
                principalColumn: "ID");
        }
    }
}
