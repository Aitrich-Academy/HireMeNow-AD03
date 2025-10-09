using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Interface.JobSeeker;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository.JobSeeker
{
    public class SaveJobRepository:ISaveJobRepository
    {
        private readonly AppDbContext _context;
        public SaveJobRepository(AppDbContext context) => _context = context;
        //Save
        public async Task<SavedJob> SaveJobAsync(SavedJob savedJob)
        {

            await _context.SavedJobs.AddAsync(savedJob);
            await _context.SaveChangesAsync();
            return savedJob;
        }
        public async Task<SavedJob?> GetByJobSeekerAndPostAsync(Guid jobSeekerId, Guid jobPostId)
        {
            return await _context.SavedJobs
                .FirstOrDefaultAsync(sj => sj.JobSeekerId == jobSeekerId && sj.JobPostId == jobPostId);
        }

        public async Task AddAsync(SavedJob entity)
        {
            _context.SavedJobs.Add(entity);
            await _context.SaveChangesAsync();
        }
        //public async Task<IEnumerable<SavedJob>> GetByJobSeekerAsync(Guid jobSeekerId)
        //{
        //    return await _context.SavedJobs
        //        .Include(s => s.JobPost) // if you want job details
        //        .Where(s => s.JobSeekerId == jobSeekerId)
        //        .ToListAsync();
        //}
        //public async Task<IEnumerable<SavedJob>> GetByJobSeekerAsync(Guid jobSeekerId)
        //{
        //    return await _context.SavedJobs
        //        .Include(s => s.JobPost)
        //            .ThenInclude(j => j.JobProviderCompany) // assuming JobPost → CompanyUser → Company
        //        .Where(s => s.JobSeekerId == jobSeekerId)
        //        .ToListAsync();
        //}

        public async Task<IEnumerable<SavedJob>> GetSavedJobsAsync(Guid jobSeekerId) =>
            await _context.SavedJobs.Include(s => s.JobPost)
                                     .Where(s => s.JobSeekerId == jobSeekerId)
                                     .ToListAsync();

        //public async Task<SavedJob?> GetSavedJobByIdAsync(Guid savedJobId) =>
        //    await _context.SavedJobs.Include(s => s.JobPost)
        //                             .FirstOrDefaultAsync(s => s.SavedJobId == savedJobId);

        public async Task<IEnumerable<SavedJob>> GetByJobSeekerAsync(Guid jobSeekerId)
        {
            return await _context.SavedJobs
                .Include(s => s.JobPost)
                    .ThenInclude(j => j.PostedByUser)
                .Where(s => s.JobSeekerId == jobSeekerId)
                .ToListAsync();
        }

        public async Task<SavedJob?> GetByIdAsync(Guid jobSeekerId, Guid savedJobId)
        {
            return await _context.SavedJobs
                .Include(s => s.JobPost)
                    .ThenInclude(j => j.PostedByUser)
                .FirstOrDefaultAsync(s => s.JobSeekerId == jobSeekerId && s.SavedJobId == savedJobId);
        }

        //public async Task<bool> RemoveSavedJobAsync(Guid savedJobId)
        //{
        //    var job = await _context.SavedJobs.FindAsync(savedJobId);
        //    if (job == null) return false;
        //    _context.SavedJobs.Remove(job);
        //    await _context.SaveChangesAsync();
        //    return true;
        //}
        public async Task DeleteAsync(SavedJob entity)
        {
            _context.SavedJobs.Remove(entity);
            await _context.SaveChangesAsync();
        }

    }
}
