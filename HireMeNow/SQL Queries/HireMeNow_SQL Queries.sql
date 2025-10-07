Create Database HireMeNowDB_AD03
----Select Queries For HireMeNowDB_AD03------
-----------JobProviderTables -----------------
select * From JobProviderCompany;
select * From CompanyUsers;
select * From Interview;
select * From ShortList;
select * From JobPost;

-----------JobSeekerTables -----------------
SELECT * FROM SYSTEMUSER;
SELECT * FROM JOBSEEKER;
SELECT * FROM RESUME;
SELECT * FROM JOBSEEKERPROFILE;
SELECT * FROM QUALIFICATION;
SELECT * FROM SKILL;
SELECT * FROM JOBSEEKERPROFILESKILL;
SELECT * FROM WORKEXPERIENCE;
SELECT * FROM JOBPOST; -- SAME TABLE IN JOBPROVIDER
SELECT * FROM SAVEDJOB;
SELECT * FROM JOBAPPLICATION

---------Admin Tables ------------------------
select * from SystemUser;
select * from SignUpRequest;
select * from Location;
select * from Industry;
----------------------------------------------------AdminTables --------------------------------------------------------
--SystemUser (Signup user info)--
--CREATE TABLE [dbo].[SystemUser](
--[SystemUserID] [uniqueidentifier] NOT NULL primary key,
--[UserName] [nvarchar](max) NULL,
--[FirstName] [nvarchar](max) NOT NULL,
--[LastName] [nvarchar](max) NULL,
--[Phone] [nvarchar](max) NOT NULL,
--[Email] [nvarchar](450) NOT NULL,
--[Role] [int] NOT NULL
--);

-- AuthUser--
CREATE TABLE [dbo].[AuthUser](
AuthUserID UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
Password NVARCHAR(255) NOT NULL,
ConnectionId NVARCHAR(255) NULL,
OnlineStatus BIT NOT NULL DEFAULT 0,
CONSTRAINT FK_AuthUser_SystemUser FOREIGN KEY (Id)
REFERENCES [dbo].[SystemUser](SystemUserID) ON DELETE CASCADE
);


--SignUpRequest--
CREATE TABLE [dbo].[SignUpRequest](
    [SignInId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [UserName] NVARCHAR(100) NOT NULL,
    [FirstName] NVARCHAR(100) NOT NULL,
    [LastName] NVARCHAR(100) NULL,
    [Email] NVARCHAR(200) NOT NULL UNIQUE,
    [Phone] NVARCHAR(20) NOT NULL,
    [PasswordHash] NVARCHAR(255) NOT NULL,  
    [Status] [int] NOT NULL DEFAULT 'Pending'-- 'Pending', 'Verified', 'Created'----
);


-- Industry
CREATE TABLE [dbo].[Industry](
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [Name] VARCHAR(100) NOT NULL,
    [Description] VARCHAR(255) NULL
);


-- Location
CREATE TABLE [dbo].[Location](
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [Name] NVARCHAR(150) NOT NULL,         
    [State] NVARCHAR(150) NOT NULL,        
    [Country] NVARCHAR(150) NOT NULL,      
    [PostalCode] NVARCHAR(20) NULL
);

----------------------------------------------------JobProviderTables -----------------------------------------------------

-- Job Provider Company
CREATE TABLE JobProviderCompany (
    JobProviderID UNIQUEIDENTIFIER PRIMARY KEY,
    CompanyName NVARCHAR(200) NOT NULL,
    Email NVARCHAR(200) NOT NULL,
    Location NVARCHAR(200),
    Role NVARCHAR(50), -- e.g. Admin/JobSeeker/JobProvider/CompanyUser
    IndustryId UNIQUEIDENTIFIER NOT NULL
);

-- Company Users (Employers/Recruiters/HR)
CREATE TABLE CompanyUsers (
    CompanyUserID UNIQUEIDENTIFIER PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100),
    Role NVARCHAR(50), -- JobSeeker / JobProvider / CompanyUser
    CompanyName NVARCHAR(200),
    Email NVARCHAR(200) NOT NULL,
    Phone NVARCHAR(20),
    JobProviderID UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY (JobProviderID) REFERENCES JobProviderCompany(JobProviderID)
);



-- Interview
CREATE TABLE Interview (
    InterviewID UNIQUEIDENTIFIER PRIMARY KEY,
    InterviewDate DATETIME NOT NULL,
    InterviewTime NVARCHAR(50),
    Mode [int], -- Online/Offline
    Status [int], --  Scheduled,AcceptedByJobSeeker,AcceptedByJobProvider,InterviewConducted,RejectedByJobSeeker,CancelledByJobProvider
    JobSeekerID UNIQUEIDENTIFIER NOT NULL,
    ApplicationID UNIQUEIDENTIFIER NOT NULL
    
);

-- ShortList
CREATE TABLE ShortList (
    ShortListID UNIQUEIDENTIFIER PRIMARY KEY,
    ApplicationID UNIQUEIDENTIFIER NOT NULL,
    JobSeekerID UNIQUEIDENTIFIER NOT NULL,
    CompanyUserID UNIQUEIDENTIFIER NOT NULL,
    JobProviderID UNIQUEIDENTIFIER NOT NULL,
    ShortListStatus NVARCHAR(50) -- e.g. Pending/Selected/Rejected
    FOREIGN KEY (CompanyUserID) REFERENCES CompanyUsers(CompanyUserID),
    FOREIGN KEY (JobProviderID) REFERENCES JobProviderCompany(JobProviderID)
    
);
--JobPost
CREATE TABLE [dbo].[JobPost](
	[JobPostID] [uniqueidentifier] NOT NULL primary key,
	[JobTitle] [nchar](10) NOT NULL,
	[JobSummary] [nvarchar](50) NOT NULL,
	[JobLocation] [uniqueidentifier] NOT NULL,
	[Company] [uniqueidentifier] NOT NULL,
	[Category] [uniqueidentifier] NOT NULL,
	[Industry] [uniqueidentifier] NOT NULL,
	[PostedBy] [uniqueidentifier] NOT NULL,
	[PostedDate] [datetime] NOT NULL
);



----------------------------------------------------Job Seeker Tables------------------------------------------------
--SystemUser
CREATE TABLE [dbo].[SystemUser](
	[SystemUserID] [uniqueidentifier] NOT NULL primary key,
	[UserName] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](450) NOT NULL,
	[Role] [int] NOT NULL
);

--JobSeeker
CREATE TABLE [dbo].[JobSeeker](
	[JobSeekerID] [uniqueidentifier] NOT NULL primary key foreign key references [SystemUser](SystemUserID),
	[UserName] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](450) NOT NULL,
	[Role] [int] NOT NULL,
	[Image] [varbinary](max) NULL
);

CREATE TABLE [dbo].[Resume](
	[ResumeID] [uniqueidentifier] NOT NULL primary key,
	[ResumeTitle] [nvarchar](max) NULL,
	[File] [varbinary](max) NULL
);

CREATE TABLE [dbo].[JobSeekerProfile](
	[JobSeekerProfileID] [uniqueidentifier] NOT NULL primary key,
	[JobSeekerId] [uniqueidentifier] NOT NULL foreign key references [JobSeeker](JobSeekerID),
	[ResumeID] [uniqueidentifier] NOT NULL foreign key references [Resume](ResumeID),
	[ProfileName] [nvarchar](max) NULL,
	[ProfileSummary] [nvarchar](max) NULL,
);

CREATE TABLE [dbo].[Qualification](
	[QualificationID] [uniqueidentifier] NOT NULL primary key,
	[JobseekerProfileId] [uniqueidentifier] NULL foreign key references [JobSeekerProfile](JobSeekerProfileID),
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL
);

CREATE TABLE [dbo].[Skill](
	[SkillID] [uniqueidentifier] NOT NULL primary key,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL
);

CREATE TABLE [dbo].[JobSeekerProfileSkill](
	[JobSeekerProfileSkillID] [uniqueidentifier] NOT NULL primary key,
	[JobSeekerProfileID] [uniqueidentifier] NOT NULL foreign key references [JobSeekerProfile](JobSeekerProfileID),
    [SkillId] [uniqueidentifier] NOT NULL foreign key references [Skill](SkillID)
 );

CREATE TABLE [dbo].[WorkExperience](
	[WorkExperienceID] [uniqueidentifier] NOT NULL primary key,
	[JobSeekerProfileID] [uniqueidentifier] NOT NULL foreign key references [JobSeekerProfile](JobSeekerProfileID),
	[JobTitle] [nvarchar](max) NOT NULL,
	[CompanyName] [nvarchar](max) NOT NULL,
	[Summary] [nvarchar](max) NOT NULL,
	[ServiceStart] [datetime2](7) NOT NULL,
	[ServiceEnd] [datetime2](7) NOT NULL
);

--CREATE TABLE [dbo].[JobPost](
--	[JobPostID] [uniqueidentifier] NOT NULL primary key,
--	[JobTitle] [nchar](10) NOT NULL,
--	[JobSummary] [nvarchar](50) NOT NULL,
--	[JobLocation] [uniqueidentifier] NOT NULL,
--	[Company] [uniqueidentifier] NOT NULL,
--	[Category] [uniqueidentifier] NOT NULL,
--	[Industry] [uniqueidentifier] NOT NULL,
--	[PostedBy] [uniqueidentifier] NOT NULL,
--	[PostedDate] [datetime] NOT NULL
--);


CREATE TABLE [dbo].SavedJob(
	[SavedJobID] [uniqueidentifier] NOT NULL primary key,
	[JobSeekerID] [uniqueidentifier] NOT NULL foreign key references [JobSeeker](JobSeekerID),
	[JobPostId] [uniqueidentifier] NOT NULL foreign key references [JobPost](JobPostID),
	[SavedDate] [datetime2](7) NOT NULL
);

CREATE TABLE [dbo].JobApplication(
	[JobApplicationID] [uniqueidentifier] NOT NULL primary key,
	[JobSeekerId] [uniqueidentifier] NOT NULL foreign key references [JobSeeker](JobSeekerID),
	[JobPostId] [uniqueidentifier] NOT NULL foreign key references [JobPost](JobPostID),
	[ResumeId] [uniqueidentifier] NOT NULL foreign key references [Resume](ResumeID),
	[CoverLetter] [nvarchar](max) NOT NULL,
	[AppliedDate] [datetime2](7) NOT NULL,--Eg: Pending,Viewed,Shortlisted,Rejected
	[Status] [int] NOT NULL
);



