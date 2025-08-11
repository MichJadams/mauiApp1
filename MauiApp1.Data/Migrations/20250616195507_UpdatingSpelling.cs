using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MauiApp1.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingSpelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobPotingUrl",
                table: "ApplicationPage",
                newName: "JobPostingUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobPostingUrl",
                table: "ApplicationPage",
                newName: "JobPotingUrl");
        }
    }
}
