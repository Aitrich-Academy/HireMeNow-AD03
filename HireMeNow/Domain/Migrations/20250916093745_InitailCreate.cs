using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitailCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Industry",
                columns: table => new
                {
                    IndustryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industry", x => x.IndustryId);
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
                name: "Resume",
                columns: table => new
                {
                    ResumeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resume", x => x.ResumeID);
                });

            migrationBuilder.CreateTable(
                name: "SignUpRequest",
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
                    table.PrimaryKey("PK_SignUpRequest", x => x.SignInId);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    SkillID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.SkillID);
                });

            migrationBuilder.CreateTable(
                name: "SystemUser",
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
                    table.PrimaryKey("PK_SystemUser", x => x.SystemUserID);
                });

            migrationBuilder.CreateTable(
                name: "AuthUsers",
                columns: table => new
                {
                    AuthUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthUsers", x => x.AuthUserId);
                    table.ForeignKey(
                        name: "FK_AuthUsers_SystemUser_Id",
                        column: x => x.Id,
                        principalTable: "SystemUser",
                        principalColumn: "SystemUserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobProviderCompany",
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
                    table.PrimaryKey("PK_JobProviderCompany", x => x.JobProviderID);
                    table.ForeignKey(
                        name: "FK_JobProviderCompany_SystemUser_JobProviderID",
                        column: x => x.JobProviderID,
                        principalTable: "SystemUser",
                        principalColumn: "SystemUserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobSeeker",
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
                    table.PrimaryKey("PK_JobSeeker", x => x.JobSeekerID);
                    table.ForeignKey(
                        name: "FK_JobSeeker_SystemUser_JobSeekerID",
                        column: x => x.JobSeekerID,
                        principalTable: "SystemUser",
                        principalColumn: "SystemUserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyUser",
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
                    table.PrimaryKey("PK_CompanyUser", x => x.CompanyUserID);
                    table.ForeignKey(
                        name: "FK_CompanyUser_JobProviderCompany_JobProviderID",
                        column: x => x.JobProviderID,
                        principalTable: "JobProviderCompany",
                        principalColumn: "JobProviderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyUser_SystemUser_SystemUserID",
                        column: x => x.SystemUserID,
                        principalTable: "SystemUser",
                        principalColumn: "SystemUserID",
                       onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "JobSeekerProfile",
                columns: table => new
                {
                    JobSeekerProfileID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobSeekerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileSummary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeekerProfile", x => x.JobSeekerProfileID);
                    table.ForeignKey(
                        name: "FK_JobSeekerProfile_JobSeeker_JobSeekerId",
                        column: x => x.JobSeekerId,
                        principalTable: "JobSeeker",
                        principalColumn: "JobSeekerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSeekerProfile_Resume_ResumeID",
                        column: x => x.ResumeID,
                        principalTable: "Resume",
                        principalColumn: "ResumeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobPost",
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
                    table.PrimaryKey("PK_JobPost", x => x.JobPostID);
                    table.ForeignKey(
                        name: "FK_JobPost_CompanyUser_CompanyUserId",
                        column: x => x.CompanyUserId,
                        principalTable: "CompanyUser",
                        principalColumn: "CompanyUserID");
                });

            migrationBuilder.CreateTable(
                name: "ShortList",
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
                    table.PrimaryKey("PK_ShortList", x => x.ShortListID);
                    table.ForeignKey(
                        name: "FK_ShortList_CompanyUser_CompanyUserID",
                        column: x => x.CompanyUserID,
                        principalTable: "CompanyUser",
                        principalColumn: "CompanyUserID",
                       onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ShortList_JobProviderCompany_JobProviderID",
                        column: x => x.JobProviderID,
                        principalTable: "JobProviderCompany",
                        principalColumn: "JobProviderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobSeekerProfileSkill",
                columns: table => new
                {
                    JobSeekerProfileSkillID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobSeekerProfileID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeekerProfileSkill", x => x.JobSeekerProfileSkillID);
                    table.ForeignKey(
                        name: "FK_JobSeekerProfileSkill_JobSeekerProfile_JobSeekerProfileID",
                        column: x => x.JobSeekerProfileID,
                        principalTable: "JobSeekerProfile",
                        principalColumn: "JobSeekerProfileID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSeekerProfileSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Qualification",
                columns: table => new
                {
                    QualificationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobseekerProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualification", x => x.QualificationID);
                    table.ForeignKey(
                        name: "FK_Qualification_JobSeekerProfile_JobseekerProfileId",
                        column: x => x.JobseekerProfileId,
                        principalTable: "JobSeekerProfile",
                        principalColumn: "JobSeekerProfileID");
                });

            migrationBuilder.CreateTable(
                name: "WorkExperience",
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
                    table.PrimaryKey("PK_WorkExperience", x => x.WorkExperienceID);
                    table.ForeignKey(
                        name: "FK_WorkExperience_JobSeekerProfile_JobSeekerProfileID",
                        column: x => x.JobSeekerProfileID,
                        principalTable: "JobSeekerProfile",
                        principalColumn: "JobSeekerProfileID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobApplication",
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
                    table.PrimaryKey("PK_JobApplication", x => x.JobApplicationID);
                    table.ForeignKey(
                        name: "FK_JobApplication_JobPost_JobPostId",
                        column: x => x.JobPostId,
                        principalTable: "JobPost",
                        principalColumn: "JobPostID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobApplication_JobSeeker_JobSeekerId",
                        column: x => x.JobSeekerId,
                        principalTable: "JobSeeker",
                        principalColumn: "JobSeekerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobApplication_Resume_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resume",
                        principalColumn: "ResumeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavedJob",
                columns: table => new
                {
                    SavedJobID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobSeekerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SavedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedJob", x => x.SavedJobID);
                    table.ForeignKey(
                        name: "FK_SavedJob_JobPost_JobPostId",
                        column: x => x.JobPostId,
                        principalTable: "JobPost",
                        principalColumn: "JobPostID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavedJob_JobSeeker_JobSeekerID",
                        column: x => x.JobSeekerID,
                        principalTable: "JobSeeker",
                        principalColumn: "JobSeekerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interview",
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
                    table.PrimaryKey("PK_Interview", x => x.InterviewID);
                    table.ForeignKey(
                        name: "FK_Interview_JobApplication_ApplicationID1",
                        column: x => x.ApplicationID1,
                        principalTable: "JobApplication",
                        principalColumn: "JobApplicationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthUsers_Id",
                table: "AuthUsers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUser_JobProviderID",
                table: "CompanyUser",
                column: "JobProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUser_SystemUserID",
                table: "CompanyUser",
                column: "SystemUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_ApplicationID1",
                table: "Interview",
                column: "ApplicationID1");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_JobPostId",
                table: "JobApplication",
                column: "JobPostId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_JobSeekerId",
                table: "JobApplication",
                column: "JobSeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_ResumeId",
                table: "JobApplication",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPost_CompanyUserId",
                table: "JobPost",
                column: "CompanyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekerProfile_JobSeekerId",
                table: "JobSeekerProfile",
                column: "JobSeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekerProfile_ResumeID",
                table: "JobSeekerProfile",
                column: "ResumeID");

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekerProfileSkill_JobSeekerProfileID",
                table: "JobSeekerProfileSkill",
                column: "JobSeekerProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekerProfileSkill_SkillId",
                table: "JobSeekerProfileSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualification_JobseekerProfileId",
                table: "Qualification",
                column: "JobseekerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedJob_JobPostId",
                table: "SavedJob",
                column: "JobPostId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedJob_JobSeekerID",
                table: "SavedJob",
                column: "JobSeekerID");

            migrationBuilder.CreateIndex(
                name: "IX_ShortList_CompanyUserID",
                table: "ShortList",
                column: "CompanyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ShortList_JobProviderID",
                table: "ShortList",
                column: "JobProviderID");

            migrationBuilder.CreateIndex(
                name: "UQ__SignUpRe__A9D105349BAE5C47",
                table: "SignUpRequest",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperience_JobSeekerProfileID",
                table: "WorkExperience",
                column: "JobSeekerProfileID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthUsers");

            migrationBuilder.DropTable(
                name: "Industry");

            migrationBuilder.DropTable(
                name: "Interview");

            migrationBuilder.DropTable(
                name: "JobSeekerProfileSkill");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Qualification");

            migrationBuilder.DropTable(
                name: "SavedJob");

            migrationBuilder.DropTable(
                name: "ShortList");

            migrationBuilder.DropTable(
                name: "SignUpRequest");

            migrationBuilder.DropTable(
                name: "WorkExperience");

            migrationBuilder.DropTable(
                name: "JobApplication");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "JobSeekerProfile");

            migrationBuilder.DropTable(
                name: "JobPost");

            migrationBuilder.DropTable(
                name: "JobSeeker");

            migrationBuilder.DropTable(
                name: "Resume");

            migrationBuilder.DropTable(
                name: "CompanyUser");

            migrationBuilder.DropTable(
                name: "JobProviderCompany");

            migrationBuilder.DropTable(
                name: "SystemUser");
        }
    }
}
