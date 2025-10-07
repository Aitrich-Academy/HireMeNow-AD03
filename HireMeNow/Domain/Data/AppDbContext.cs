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
            modelBuilder.Entity<SystemUser>().UseTpcMappingStrategy();

            modelBuilder.Entity<SystemUser>()
            .ToTable("SystemUsers");

            modelBuilder.Entity<AuthUser>()
            .ToTable("AuthUsers");

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
