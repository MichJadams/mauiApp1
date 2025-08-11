using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MauiApp1.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Tag_TagId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_TagId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Applications");

            migrationBuilder.CreateTable(
                name: "JobApplicationTag",
                columns: table => new
                {
                    JobApplicationsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplicationTag", x => new { x.JobApplicationsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_JobApplicationTag_Applications_JobApplicationsId",
                        column: x => x.JobApplicationsId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobApplicationTag_Tag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobApplicationTag_TagsId",
                table: "JobApplicationTag",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobApplicationTag");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Applications",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_TagId",
                table: "Applications",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Tag_TagId",
                table: "Applications",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
