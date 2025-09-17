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

        protected AppDbContext()
        {
        }

        public DbSet<ShortList> ShortLists { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<SignUpRequest> SignUpRequests { get; set; }

        public DbSet<AuthUser> AuthUsers { get; set; }
        public DbSet<CompanyUser> CompanyUsers { get; set; }
        public DbSet<Industry> Industrys { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<JobProviderCompany> JobProviderCompanys { get; set; }
        public DbSet<JobSeeker> JobSeekers { get; set; }
        public DbSet<JobSeekerProfile> JobSeekerProfiles { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<SavedJob> SavedJobs { get; set; }
        //public DbSet<ShortList> ShortLists { get; set; }
        //public DbSet<SignUpRequest> SignUpRequests { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map DbSet to actual table name
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
            //modelBuilder.Entity<ShortList>().ToTable("ShortList");
            //modelBuilder.Entity<SignUpRequest>().ToTable("SignUpRequest");
            modelBuilder.Entity<Skill>().ToTable("Skill");
            modelBuilder.Entity<SystemUser>().ToTable("SystemUser");
            modelBuilder.Entity<WorkExperience>().ToTable("WorkExperience");
        }
    }
}
