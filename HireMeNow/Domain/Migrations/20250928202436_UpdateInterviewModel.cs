using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInterviewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interview_JobApplication_ApplicationID1",
                table: "Interview");

            migrationBuilder.DropIndex(
                name: "IX_Interview_ApplicationID1",
                table: "Interview");

            migrationBuilder.DropColumn(
                name: "ApplicationID1",
                table: "Interview");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_ApplicationID",
                table: "Interview",
                column: "ApplicationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_JobApplication_ApplicationID",
                table: "Interview",
                column: "ApplicationID",
                principalTable: "JobApplication",
                principalColumn: "JobApplicationID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interview_JobApplication_ApplicationID",
                table: "Interview");

            migrationBuilder.DropIndex(
                name: "IX_Interview_ApplicationID",
                table: "Interview");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationID1",
                table: "Interview",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Interview_ApplicationID1",
                table: "Interview",
                column: "ApplicationID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_JobApplication_ApplicationID1",
                table: "Interview",
                column: "ApplicationID1",
                principalTable: "JobApplication",
                principalColumn: "JobApplicationID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
