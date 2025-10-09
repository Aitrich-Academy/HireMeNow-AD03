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
    public class InterviewRepository:IInterviewRepository
    {
        private readonly AppDbContext _context;
        public InterviewRepository(AppDbContext context)
        {
            _context = context;
        }
        //public async Task<List<Interview>> GetInterviewsByJobProviderIdAsync(Guid jobProviderId)
        //{
        //    return await _context.Interviews
        //        .Include(i => i.JobApplication)
        //            .ThenInclude(ja => ja.JobSeeker)
        //        .Include(i => i.JobApplication)
        //            .ThenInclude(ja => ja.JobPost)
        //        .Where(i => i.JobApplication.JobPost.JobProviderId == jobProviderId)
        //        .ToListAsync();
        //}
        public async Task<List<Interview>> GetInterviewsByJobProviderIdAsync(Guid jobProviderId)
        {
            return await _context.Interviews
                .Include(i => i.JobApplication)
                    .ThenInclude(ja => ja.JobSeeker)
                .Include(i => i.JobApplication)
                    .ThenInclude(ja => ja.JobPost)
                        .ThenInclude(jp => jp.JobProviderCompany) // Include company for name
                .Where(i => i.JobApplication.JobPost.JobProviderId == jobProviderId)
                .AsSplitQuery() // Prevents Cartesian explosion
                .ToListAsync();
        }
        public async Task<Interview?> GetByIdAsync(Guid id)
        {
            return await _context.Set<Interview>().FirstOrDefaultAsync(i => i.InterviewId == id);
        }

        public async Task UpdateAsync(Interview interview)
        {
            _context.Set<Interview>().Update(interview);
            await _context.SaveChangesAsync();
            
        }
        public async Task<Interview?> GetByInterviewIdAsync(Guid id)
        {
            return await _context.Interviews
                .Include(i => i.JobApplication) // if you want related data
                .FirstOrDefaultAsync(i => i.InterviewId == id);
        }
        public async Task<List<Interview>> GetByJobSeekerIdAsync(Guid jobSeekerId)
        {
            return await _context.Interviews
                .Include(i => i.JobApplication)   // Include related application if needed
                .ThenInclude(ja => ja.JobPost)    // Include job details
                .Where(i => i.JobSeekerId == jobSeekerId)
                .ToListAsync();
        }
        public async Task<List<Interview>> GetByJobPostIdAsync(Guid jobPostId)
        {
            return await _context.Interviews
                .Include(i => i.JobApplication)
                .ThenInclude(ja => ja.JobPost)
                .Where(i => i.JobApplication.JobPostId == jobPostId)
                .ToListAsync();
        }
        public async Task AddAsync(Interview interview)
        {
            await _context.Interviews.AddAsync(interview);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Interview interview)
        {
            _context.Interviews.Remove(interview);
            await _context.SaveChangesAsync();
        }
        public async Task<int> CountByJobProviderAsync(Guid jobProviderId)
        {
            //return await _context.Interviews
            //    .Include(i => i.ShortList) // navigation property
            //     .Where(i => i.ShortList.JobProviderId == jobProviderId)
            //     .CountAsync();
            var count = await (from interview in _context.Interviews
                               join shortlist in _context.ShortLists
                               on interview.ShortListId equals shortlist.ShortListId
                               where shortlist.JobProviderId == jobProviderId
                               select interview)
                  .CountAsync();
            return count;
        }





    }
}
