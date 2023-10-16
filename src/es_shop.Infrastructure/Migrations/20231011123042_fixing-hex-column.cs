using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixinghexcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hex",
                table: "TB_COLOR");

            migrationBuilder.AddColumn<string>(
                name: "TXT_COLOR",
                table: "TB_COLOR",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TXT_COLOR",
                table: "TB_COLOR");

            migrationBuilder.AddColumn<string>(
                name: "Hex",
                table: "TB_COLOR",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
