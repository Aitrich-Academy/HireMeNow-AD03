using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class JobPostModelChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostedBy",
                table: "JobPost",
                newName: "JobProviderID");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "JobPost",
                newName: "CreatorID");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "JobPost",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "JobPost");

            migrationBuilder.RenameColumn(
                name: "JobProviderID",
                table: "JobPost",
                newName: "PostedBy");

            migrationBuilder.RenameColumn(
                name: "CreatorID",
                table: "JobPost",
                newName: "Company");
        }
    }
}
