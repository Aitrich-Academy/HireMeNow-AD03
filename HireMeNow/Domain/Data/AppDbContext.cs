using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ShortList> ShortLists { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<SignUpRequest> SignUpRequests { get; set; }
        public DbSet<AuthUser> AuthUsers { get; set; }
        public DbSet<CompanyUser> CompanyUsers { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<JobProviderCompany> JobProviderCompanies { get; set; }
        public DbSet<JobSeeker> JobSeekers { get; set; }
        public DbSet<JobSeekerProfile> JobSeekerProfiles { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }

        public DbSet<SavedJob> SavedJobs { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<JobSeekerProfileSkill> JobSeekerProfileSkills {  get; set; }
        public DbSet<Resume> Resumes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            //Map DbSet to actual table name
            modelBuilder.Entity<ShortList>().ToTable("ShortList");
            modelBuilder.Entity<Interview>().ToTable("Interview");
            modelBuilder.Entity<JobApplication>().ToTable("JobApplication");
            modelBuilder.Entity<SignUpRequest>().ToTable("SignUpRequest");
            modelBuilder.Entity<CompanyUser>().ToTable("CompanyUser");
            modelBuilder.Entity<Industry>().ToTable("Industry");
            modelBuilder.Entity<JobPost>().ToTable("JobPost");
            modelBuilder.Entity<JobProviderCompany>().ToTable("JobProviderCompany");
            modelBuilder.Entity<JobSeeker>().ToTable("JobSeeker");
            modelBuilder.Entity<JobSeekerProfile>().ToTable("JobSeekerProfile");
            modelBuilder.Entity<Location>().ToTable("Location");
            modelBuilder.Entity<Qualification>().ToTable("Qualification");
            modelBuilder.Entity<SavedJob>().ToTable("SavedJob");
            modelBuilder.Entity<Skill>().ToTable("Skill");
            modelBuilder.Entity<SystemUser>().ToTable("SystemUser");
            modelBuilder.Entity<AuthUser>().ToTable("AuthUser");
            modelBuilder.Entity<WorkExperience>().ToTable("WorkExperience");
            modelBuilder.Entity<Resume>().ToTable("Resume");

            // -----------------------------
            // JobPost → JobProviderCompany
            // -----------------------------
            modelBuilder.Entity<JobPost>()
                .HasOne(j => j.JobProviderCompany)
                .WithMany(c => c.JobPosts)
                .HasForeignKey(j => j.JobProviderId)
                .OnDelete(DeleteBehavior.Restrict); // or Cascade if you prefer

            // -----------------------------
            // Restrict cascade deletes to avoid multiple cascade paths
            // -----------------------------

            // CompanyUser → JobProviderCompany
            modelBuilder.Entity<CompanyUser>()
                .HasOne(c => c.JobProviderNavigation)
                .WithMany(j => j.CompanyUsers)
                .OnDelete(DeleteBehavior.Restrict);

            // CompanyUser → SystemUser
            modelBuilder.Entity<CompanyUser>()
                .HasOne(c => c.CompanyUserNavigation)
                .WithMany(s => s.CompanyUsers)
                .OnDelete(DeleteBehavior.Restrict);

            // ShortList → JobProvider
            modelBuilder.Entity<ShortList>()
                .HasOne(s => s.JobProvider)
                .WithMany(j => j.ShortLists)
                .OnDelete(DeleteBehavior.Restrict);

            // ShortList → CompanyUser
            modelBuilder.Entity<ShortList>()
                .HasOne(s => s.CompanyUser)
                .WithMany(c => c.ShortLists)
                .OnDelete(DeleteBehavior.Restrict);

            // ShortList → JobApplication
            modelBuilder.Entity<ShortList>()
                .HasOne(s => s.JobApplication)
                .WithMany(a => a.ShortListStatus)
                .OnDelete(DeleteBehavior.Restrict);

            // ShortList → JobSeeker
            modelBuilder.Entity<ShortList>()
                .HasOne(s => s.JobSeeker)
                .WithMany(j => j.ShortLists)
                .OnDelete(DeleteBehavior.Restrict);

            // JobApplication → JobPost (keep cascade)
            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.JobPost)
                .WithMany(jp => jp.JobApplications)
                .HasForeignKey(ja => ja.JobPostId)
                .OnDelete(DeleteBehavior.Cascade);

            // JobApplication → JobSeeker (restrict)
            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.JobSeeker)
                .WithMany(js => js.JobApplications)
                .HasForeignKey(ja => ja.JobSeekerId)
                .OnDelete(DeleteBehavior.Restrict);

            // JobApplication → Resume (restrict)
            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.Resume)
                .WithMany(r => r.JobApplications)
                .HasForeignKey(ja => ja.ResumeId)
                .OnDelete(DeleteBehavior.Restrict);

            // SavedJob → JobSeeker
            modelBuilder.Entity<SavedJob>()
                .HasOne(sj => sj.JobSeeker)
                .WithMany(js => js.SavedJobs)
                .HasForeignKey(sj => sj.JobSeekerId)
                .OnDelete(DeleteBehavior.Restrict);

            // SavedJob → JobPost
            modelBuilder.Entity<SavedJob>()
                .HasOne(sj => sj.JobPost)
                .WithMany(jp => jp.SavedJobs)
                .HasForeignKey(sj => sj.JobPostId)
                .OnDelete(DeleteBehavior.Cascade);

            // JobSeeker → SystemUser one-to-one
            modelBuilder.Entity<JobSeeker>()
                .HasOne(js => js.JobSeekerNavigation)
                .WithOne(su => su.JobSeeker)
                .HasForeignKey<JobSeeker>(js => js.JobSeekerId);

            // Configure composite primary key for join table
            modelBuilder.Entity<JobSeekerProfileSkill>()
                .HasKey(jps => new { jps.JobSeekerProfileId, jps.SkillId });

            // Configure relationships
            modelBuilder.Entity<JobSeekerProfileSkill>()
                .HasOne(jps => jps.JobSeekerProfile)
                .WithMany(jp => jp.JobSeekerProfileSkills)
                .HasForeignKey(jps => jps.JobSeekerProfileId);

            modelBuilder.Entity<JobSeekerProfileSkill>()
                .HasOne(jps => jps.Skill)
                .WithMany(s => s.JobSeekerProfileSkills)
                .HasForeignKey(jps => jps.SkillId);
        }
    }
}
