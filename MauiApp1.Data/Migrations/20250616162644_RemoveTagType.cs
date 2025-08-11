using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MauiApp1.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTagType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TagType",
                table: "Tag");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TagType",
                table: "Tag",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
