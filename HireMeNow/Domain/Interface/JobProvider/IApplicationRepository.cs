using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interface.JobProvider
{
    public interface IApplicationRepository
    {
        Task<JobApplication> GetApplicationByIdAsync(Guid applicationId);
        Task<List<JobApplication>> GetApplicationsByJobPostIdAsync(Guid jobPostId);
        Task<int> CountByJobPostIdAsync(Guid jobPostId);
        Task UpdateAsync(JobApplication application);
        Task<ShortList> AddAsync(ShortList shortlist);
        Task SaveChangesAsync();
        Task<IEnumerable<ShortList>> GetShortlistsByProviderAsync(Guid jobProviderId);
        Task UpdateAsync(ShortList shortlist);
        Task<ShortList?> GetShortlistByIdAsync(Guid shortlistId);
    }
}
