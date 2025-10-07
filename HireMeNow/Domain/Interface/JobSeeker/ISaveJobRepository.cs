using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interface.JobSeeker
{
    public interface ISaveJobRepository
    {
        Task<SavedJob> SaveJobAsync(SavedJob savedJob);
        Task<IEnumerable<SavedJob>> GetSavedJobsAsync(Guid jobSeekerId);
       // Task<SavedJob?> GetSavedJobByIdAsync(Guid savedJobId);
      //  Task<bool> RemoveSavedJobAsync(Guid savedJobId);
        Task<SavedJob?> GetByJobSeekerAndPostAsync(Guid jobSeekerId, Guid jobPostId);
       
        Task AddAsync(SavedJob entity);

        Task<IEnumerable<SavedJob>> GetByJobSeekerAsync(Guid jobSeekerId);
        Task<SavedJob?> GetByIdAsync(Guid jobSeekerId, Guid savedJobId);
        //Remove
        Task DeleteAsync(SavedJob entity);

    }
}
