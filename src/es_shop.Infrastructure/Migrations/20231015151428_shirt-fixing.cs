using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class shirtfixing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_SHIRT_SPECIFICATION_Shirts_COD_SHIRT",
                table: "TB_SHIRT_SPECIFICATION");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_SHIRT_SPECIFICATION_Shirts_ShirtEntityId",
                table: "TB_SHIRT_SPECIFICATION");

            migrationBuilder.DropIndex(
                name: "IX_TB_SHIRT_SPECIFICATION_COD_SHIRT",
                table: "TB_SHIRT_SPECIFICATION");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shirts",
                table: "Shirts");

            migrationBuilder.DropColumn(
                name: "COD_SHIRT",
                table: "TB_SHIRT_SPECIFICATION");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_SHIRT",
                table: "TB_SHIRT",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_SHIRT_SPECIFICATION_TB_SHIRT_ShirtEntityId",
                table: "TB_SHIRT_SPECIFICATION",
                column: "ShirtEntityId",
                principalTable: "TB_SHIRT",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_SHIRT_SPECIFICATION_TB_SHIRT_ShirtEntityId",
                table: "TB_SHIRT_SPECIFICATION");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_SHIRT",
                table: "TB_SHIRT");

            migrationBuilder.RenameTable(
                name: "TB_SHIRT",
                newName: "Shirts");

            migrationBuilder.RenameColumn(
                name: "TXT_NAME",
                table: "Shirts",
                newName: "Name");

            migrationBuilder.AddColumn<Guid>(
                name: "COD_SHIRT",
                table: "TB_SHIRT_SPECIFICATION",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_TB_SHIRT_SPECIFICATION_COD_SHIRT",
                table: "TB_SHIRT_SPECIFICATION",
                column: "COD_SHIRT");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_SHIRT_SPECIFICATION_Shirts_COD_SHIRT",
                table: "TB_SHIRT_SPECIFICATION",
                column: "COD_SHIRT",
                principalTable: "Shirts",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_SHIRT_SPECIFICATION_Shirts_ShirtEntityId",
                table: "TB_SHIRT_SPECIFICATION",
                column: "ShirtEntityId",
                principalTable: "Shirts",
                principalColumn: "ID");
        }
    }
}
