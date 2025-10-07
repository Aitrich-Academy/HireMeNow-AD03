using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class NoChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPost_CompanyUser_CreatorID",
                table: "JobPost");

            migrationBuilder.DropIndex(
                name: "IX_JobPost_CreatorID",
                table: "JobPost");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyUserId",
                table: "JobPost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobPost_CompanyUserId",
                table: "JobPost",
                column: "CompanyUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPost_CompanyUser_CompanyUserId",
                table: "JobPost",
                column: "CompanyUserId",
                principalTable: "CompanyUser",
                principalColumn: "CompanyUserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPost_CompanyUser_CompanyUserId",
                table: "JobPost");

            migrationBuilder.DropIndex(
                name: "IX_JobPost_CompanyUserId",
                table: "JobPost");

            migrationBuilder.DropColumn(
                name: "CompanyUserId",
                table: "JobPost");

            migrationBuilder.CreateIndex(
                name: "IX_JobPost_CreatorID",
                table: "JobPost",
                column: "CreatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPost_CompanyUser_CreatorID",
                table: "JobPost",
                column: "CreatorID",
                principalTable: "CompanyUser",
                principalColumn: "CompanyUserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
