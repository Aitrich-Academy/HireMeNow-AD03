using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.JobProviderDTO;
using Domain.DTOs.JobSeekerDTO;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Interface.JobProvider
{
    public interface IApplicationService
    {
        Task<JobApplicationDetailsDto> GetApplicationByIdAsync(Guid applicationId);
        Task<List<JobApplicationDetailsDto>> GetApplicationsByJobPostIdAsync(Guid jobPostId);
        Task<int> CountApplicationsAsync(Guid jobPostId);

        Task<ApplicationDto?> UpdateStatusAsync(Guid applicationId, ApplicationStatus status);
        Task<ShortListDto?> ShortlistApplicationAsync(Guid applicationId, Guid jobProviderId);
        Task<IEnumerable<ShortListDto>> GetShortlistsByProviderAsync(Guid jobProviderId);
        Task<ShortListDto?> RejectApplicationAsync(Guid shortlistId);

    }
}
