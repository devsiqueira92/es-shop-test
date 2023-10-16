using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class shirtcolumnfixing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_SHIRT_SPECIFICATION_TB_SHIRT_ShirtEntityId",
                table: "TB_SHIRT_SPECIFICATION");

            migrationBuilder.DropIndex(
                name: "IX_TB_SHIRT_SPECIFICATION_ShirtEntityId",
                table: "TB_SHIRT_SPECIFICATION");

            migrationBuilder.DropColumn(
                name: "ShirtEntityId",
                table: "TB_SHIRT_SPECIFICATION");

            migrationBuilder.AddColumn<Guid>(
                name: "COD_SHIRT",
                table: "TB_SHIRT_SPECIFICATION",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TB_SHIRT_SPECIFICATION_COD_SHIRT",
                table: "TB_SHIRT_SPECIFICATION",
                column: "COD_SHIRT");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_SHIRT_SPECIFICATION_TB_SHIRT_COD_SHIRT",
                table: "TB_SHIRT_SPECIFICATION",
                column: "COD_SHIRT",
                principalTable: "TB_SHIRT",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_SHIRT_SPECIFICATION_TB_SHIRT_COD_SHIRT",
                table: "TB_SHIRT_SPECIFICATION");

            migrationBuilder.DropIndex(
                name: "IX_TB_SHIRT_SPECIFICATION_COD_SHIRT",
                table: "TB_SHIRT_SPECIFICATION");

            migrationBuilder.DropColumn(
                name: "COD_SHIRT",
                table: "TB_SHIRT_SPECIFICATION");

            migrationBuilder.AddColumn<Guid>(
                name: "ShirtEntityId",
                table: "TB_SHIRT_SPECIFICATION",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_SHIRT_SPECIFICATION_ShirtEntityId",
                table: "TB_SHIRT_SPECIFICATION",
                column: "ShirtEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_SHIRT_SPECIFICATION_TB_SHIRT_ShirtEntityId",
                table: "TB_SHIRT_SPECIFICATION",
                column: "ShirtEntityId",
                principalTable: "TB_SHIRT",
                principalColumn: "ID");
        }
    }
}
