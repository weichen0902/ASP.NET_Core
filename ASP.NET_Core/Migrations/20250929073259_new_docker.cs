using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET_Core.Migrations
{
    /// <inheritdoc />
    public partial class new_docker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Docker",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Docker",
                table: "News");
        }
    }
}
