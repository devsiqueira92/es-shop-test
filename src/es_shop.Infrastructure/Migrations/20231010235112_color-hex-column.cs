using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class colorhexcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DAT_UPDATED_BY",
                table: "TB_TYPE");

            migrationBuilder.DropColumn(
                name: "DAT_UPDATED_BY",
                table: "TB_SHIRT");

            migrationBuilder.DropColumn(
                name: "DAT_UPDATED_BY",
                table: "TB_COLOR");

            migrationBuilder.RenameColumn(
                name: "TXT_COLOR",
                table: "TB_COLOR",
                newName: "TXT_HEX");

            migrationBuilder.AlterColumn<string>(
                name: "TXT_TYPE",
                table: "TB_TYPE",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<DateTime>(
                name: "DAT_UPDATED_AT",
                table: "TB_TYPE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DAT_UPDATED_AT",
                table: "TB_SHIRT",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "TXT_HEX",
                table: "TB_COLOR",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<DateTime>(
                name: "DAT_UPDATED_AT",
                table: "TB_COLOR",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Hex",
                table: "TB_COLOR",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DAT_UPDATED_AT",
                table: "TB_TYPE");

            migrationBuilder.DropColumn(
                name: "DAT_UPDATED_AT",
                table: "TB_SHIRT");

            migrationBuilder.DropColumn(
                name: "DAT_UPDATED_AT",
                table: "TB_COLOR");

            migrationBuilder.DropColumn(
                name: "Hex",
                table: "TB_COLOR");

            migrationBuilder.RenameColumn(
                name: "TXT_HEX",
                table: "TB_COLOR",
                newName: "TXT_COLOR");

            migrationBuilder.AlterColumn<string>(
                name: "TXT_TYPE",
                table: "TB_TYPE",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<Guid>(
                name: "DAT_UPDATED_BY",
                table: "TB_TYPE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DAT_UPDATED_BY",
                table: "TB_SHIRT",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "TXT_COLOR",
                table: "TB_COLOR",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

            migrationBuilder.AddColumn<Guid>(
                name: "DAT_UPDATED_BY",
                table: "TB_COLOR",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
