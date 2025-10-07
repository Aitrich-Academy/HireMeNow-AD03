using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Interface.JobProvider;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository.JobProvider
{
    public class ApplicationRepository:IApplicationRepository
    {
        private readonly AppDbContext _context;
        public ApplicationRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<JobApplication> GetApplicationByIdAsync(Guid applicationId)
        {
            return await _context.JobApplications
                .Include(ja => ja.JobPost)
                .Include(ja => ja.JobSeeker)
                .FirstOrDefaultAsync(ja => ja.JobApplicationId == applicationId);
        }
        public async Task<List<JobApplication>> GetApplicationsByJobPostIdAsync(Guid jobPostId)
        {
            return await _context.JobApplications
            .Include(ja => ja.JobSeeker)
            .Include(ja => ja.JobPost)
            .Where(ja => ja.JobPostId == jobPostId)
            .ToListAsync();
        }
        public async Task<int> CountByJobPostIdAsync(Guid jobPostId)
        => await _context.JobApplications.CountAsync(a => a.JobPostId == jobPostId);

       
        public async Task UpdateAsync(JobApplication application)
        {
            _context.JobApplications.Update(application);
            await _context.SaveChangesAsync();
        }
        
        //public async Task<JobApplication?> GetApplicationByIdAsync(Guid applicationId)
        //{
        //    return await _context.JobApplications
        //        .Include(a => a.JobPost)
        //        .FirstOrDefaultAsync(a => a.JobApplicationId == applicationId);
        //}

        public async Task<ShortList> AddAsync(ShortList shortlist)
        {
            await _context.ShortLists.AddAsync(shortlist);
            return shortlist;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<ShortList>> GetShortlistsByProviderAsync(Guid jobProviderId)
        {
            return await _context.ShortLists
                .Include(s => s.JobApplication)
                .ThenInclude(a => a.JobPost)
                .Where(s => s.JobProviderId == jobProviderId)
                .ToListAsync();
        }
        public async Task<ShortList?> GetByIdAsync(Guid shortlistId)
        {
            return await _context.ShortLists
                .FirstOrDefaultAsync(s => s.ShortListId == shortlistId);
        }
        public async Task<ShortList?> GetShortlistByIdAsync(Guid shortlistId)
        {
            return await _context.ShortLists
                .Include(s => s.JobApplication)
                .Include(s => s.JobSeeker)
                .Include(s => s.CompanyUser)
                .Include(s => s.JobProvider)
                .FirstOrDefaultAsync(s => s.ShortListId == shortlistId);
        }

        public async Task UpdateAsync(ShortList shortlist)
        {
            _context.ShortLists.Update(shortlist);
        }



    }
}
