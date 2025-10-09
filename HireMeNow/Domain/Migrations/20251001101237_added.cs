using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthUsers",
                columns: table => new
                {
                    SystemUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthUsers", x => x.SystemUserID);
                });

            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    IndustryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.IndustryId);
                });

            migrationBuilder.CreateTable(
                name: "JobProviderCompanies",
                columns: table => new
                {
                    JobProviderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    IndustryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobProviderCompanies", x => x.JobProviderID);
                });

            migrationBuilder.CreateTable(
                name: "JobSeekers",
                columns: table => new
                {
                    JobSeekerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeekers", x => x.JobSeekerID);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    State = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "SignUpRequests",
                columns: table => new
                {
                    SignInId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignUpRequests", x => x.SignInId);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillID);
                });

            migrationBuilder.CreateTable(
                name: "SystemUsers",
                columns: table => new
                {
                    SystemUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUsers", x => x.SystemUserID);
                });

            migrationBuilder.CreateTable(
                name: "CompanyUsers",
                columns: table => new
                {
                    CompanyUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CompanyUserRole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    JobProviderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUsers", x => x.CompanyUserID);
                    table.ForeignKey(
                        name: "FK_CompanyUsers_JobProviderCompanies_JobProviderID",
                        column: x => x.JobProviderID,
                        principalTable: "JobProviderCompanies",
                        principalColumn: "JobProviderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobSeekerProfiles",
                columns: table => new
                {
                    JobSeekerProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobSeekerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileSummary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeekerProfiles", x => x.JobSeekerProfileId);
                    table.ForeignKey(
                        name: "FK_JobSeekerProfiles_JobSeekers_JobSeekerId",
                        column: x => x.JobSeekerId,
                        principalTable: "JobSeekers",
                        principalColumn: "JobSeekerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobPosts",
                columns: table => new
                {
                    JobPostID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    JobSummary = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    JobType = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Company = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndustryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CompanyUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPosts", x => x.JobPostID);
                    table.ForeignKey(
                        name: "FK_JobPosts_CompanyUsers_CompanyUserId",
                        column: x => x.CompanyUserId,
                        principalTable: "CompanyUsers",
                        principalColumn: "CompanyUserID");
                });

            migrationBuilder.CreateTable(
                name: "ShortLists",
                columns: table => new
                {
                    ShortListID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobSeekerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobProviderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShortListStatus = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortLists", x => x.ShortListID);
                    table.ForeignKey(
                        name: "FK_ShortLists_CompanyUsers_CompanyUserID",
                        column: x => x.CompanyUserID,
                        principalTable: "CompanyUsers",
                        principalColumn: "CompanyUserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShortLists_JobProviderCompanies_JobProviderID",
                        column: x => x.JobProviderID,
                        principalTable: "JobProviderCompanies",
                        principalColumn: "JobProviderID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "JobSeekerProfileSkills",
                columns: table => new
                {
                    JobSeekerProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeekerProfileSkills", x => new { x.JobSeekerProfileId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_JobSeekerProfileSkills_JobSeekerProfiles_JobSeekerProfileId",
                        column: x => x.JobSeekerProfileId,
                        principalTable: "JobSeekerProfiles",
                        principalColumn: "JobSeekerProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSeekerProfileSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    QualificationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobseekerProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.QualificationID);
                    table.ForeignKey(
                        name: "FK_Qualifications_JobSeekerProfiles_JobseekerProfileId",
                        column: x => x.JobseekerProfileId,
                        principalTable: "JobSeekerProfiles",
                        principalColumn: "JobSeekerProfileId");
                });

            migrationBuilder.CreateTable(
                name: "Resumes",
                columns: table => new
                {
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobSeekerProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ResumeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumes", x => x.ResumeId);
                    table.ForeignKey(
                        name: "FK_Resumes_JobSeekerProfiles_JobSeekerProfileId",
                        column: x => x.JobSeekerProfileId,
                        principalTable: "JobSeekerProfiles",
                        principalColumn: "JobSeekerProfileId");
                });

            migrationBuilder.CreateTable(
                name: "WorkExperiences",
                columns: table => new
                {
                    WorkExperienceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobSeekerProfileID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperiences", x => x.WorkExperienceID);
                    table.ForeignKey(
                        name: "FK_WorkExperiences_JobSeekerProfiles_JobSeekerProfileID",
                        column: x => x.JobSeekerProfileID,
                        principalTable: "JobSeekerProfiles",
                        principalColumn: "JobSeekerProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavedJobs",
                columns: table => new
                {
                    SavedJobID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobSeekerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SavedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedJobs", x => x.SavedJobID);
                    table.ForeignKey(
                        name: "FK_SavedJobs_JobPosts_JobPostId",
                        column: x => x.JobPostId,
                        principalTable: "JobPosts",
                        principalColumn: "JobPostID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavedJobs_JobSeekers_JobSeekerID",
                        column: x => x.JobSeekerID,
                        principalTable: "JobSeekers",
                        principalColumn: "JobSeekerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    JobApplicationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobSeekerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoverLetter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppliedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.JobApplicationID);
                    table.ForeignKey(
                        name: "FK_JobApplications_JobPosts_JobPostId",
                        column: x => x.JobPostId,
                        principalTable: "JobPosts",
                        principalColumn: "JobPostID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobApplications_JobSeekers_JobSeekerId",
                        column: x => x.JobSeekerId,
                        principalTable: "JobSeekers",
                        principalColumn: "JobSeekerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobApplications_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "ResumeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interviews",
                columns: table => new
                {
                    InterviewID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InterviewDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    InterviewTime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InterviewMode = table.Column<int>(type: "int", nullable: false),
                    InterviewStatus = table.Column<int>(type: "int", nullable: false),
                    JobSeekerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShortListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviews", x => x.InterviewID);
                    table.ForeignKey(
                        name: "FK_Interviews_JobApplications_ApplicationID1",
                        column: x => x.ApplicationID1,
                        principalTable: "JobApplications",
                        principalColumn: "JobApplicationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_JobProviderID",
                table: "CompanyUsers",
                column: "JobProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_SystemUserID",
                table: "CompanyUsers",
                column: "SystemUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_ApplicationID1",
                table: "Interviews",
                column: "ApplicationID1");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobPostId",
                table: "JobApplications",
                column: "JobPostId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobSeekerId",
                table: "JobApplications",
                column: "JobSeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_ResumeId",
                table: "JobApplications",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_CompanyUserId",
                table: "JobPosts",
                column: "CompanyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekerProfiles_JobSeekerId",
                table: "JobSeekerProfiles",
                column: "JobSeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekerProfileSkills_SkillId",
                table: "JobSeekerProfileSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_JobseekerProfileId",
                table: "Qualifications",
                column: "JobseekerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_JobSeekerProfileId",
                table: "Resumes",
                column: "JobSeekerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedJobs_JobPostId",
                table: "SavedJobs",
                column: "JobPostId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedJobs_JobSeekerID",
                table: "SavedJobs",
                column: "JobSeekerID");

            migrationBuilder.CreateIndex(
                name: "IX_ShortLists_CompanyUserID",
                table: "ShortLists",
                column: "CompanyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ShortLists_JobProviderID",
                table: "ShortLists",
                column: "JobProviderID");

            migrationBuilder.CreateIndex(
                name: "UQ__SignUpRe__A9D105349BAE5C47",
                table: "SignUpRequests",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_JobSeekerProfileID",
                table: "WorkExperiences",
                column: "JobSeekerProfileID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthUsers");

            migrationBuilder.DropTable(
                name: "Industries");

            migrationBuilder.DropTable(
                name: "Interviews");

            migrationBuilder.DropTable(
                name: "JobSeekerProfileSkills");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Qualifications");

            migrationBuilder.DropTable(
                name: "SavedJobs");

            migrationBuilder.DropTable(
                name: "ShortLists");

            migrationBuilder.DropTable(
                name: "SignUpRequests");

            migrationBuilder.DropTable(
                name: "SystemUsers");

            migrationBuilder.DropTable(
                name: "WorkExperiences");

            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "JobPosts");

            migrationBuilder.DropTable(
                name: "Resumes");

            migrationBuilder.DropTable(
                name: "CompanyUsers");

            migrationBuilder.DropTable(
                name: "JobSeekerProfiles");

            migrationBuilder.DropTable(
                name: "JobProviderCompanies");

            migrationBuilder.DropTable(
                name: "JobSeekers");
        }
    }
}
