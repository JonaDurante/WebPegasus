using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebPegasus.Data.Migrations
{
    /// <inheritdoc />
    public partial class CustomUserEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PilaName",
                table: "Usuarios",
                type: "nvarchar(100)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PilaName",
                table: "Usuarios");
        }
    }
}
