using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.JobProviderDTO;
using Domain.DTOs.JobSeekerDTO;
using Domain.Enums;
using Domain.Interface.JobProvider;
using Domain.Models;
using Domain.Repository.JobProvider;
using Microsoft.EntityFrameworkCore;

namespace Domain.Service.JobProvider
{
    public class ApplicationService:IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;
        public ApplicationService(IApplicationRepository applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }
        public async Task<JobApplicationDetailsDto> GetApplicationByIdAsync(Guid applicationId)
        {
            var entity = await _applicationRepository.GetApplicationByIdAsync(applicationId);
            if (entity == null) return null;

            // AutoMapper will map JobPost and JobSeeker automatically
            return _mapper.Map<JobApplicationDetailsDto>(entity);
        }
        public async Task<List<JobApplicationDetailsDto>> GetApplicationsByJobPostIdAsync(Guid jobPostId)
        {
            var entities = await _applicationRepository.GetApplicationsByJobPostIdAsync(jobPostId);
            return _mapper.Map<List<JobApplicationDetailsDto>>(entities);
        }
        public async Task<int> CountApplicationsAsync(Guid jobPostId)
        => await _applicationRepository.CountByJobPostIdAsync(jobPostId);

        public async Task<ApplicationDto?> UpdateStatusAsync(Guid applicationId, ApplicationStatus status)
        {
            var application = await _applicationRepository.GetApplicationByIdAsync(applicationId);
            if (application == null) return null;

            application.ApplicationStatus = status;
            await _applicationRepository.UpdateAsync(application);

            return _mapper.Map<ApplicationDto>(application);
        }

        public async Task<ShortListDto> ShortlistApplicationAsync(Guid applicationId, Guid jobProviderId)
        {
            var application = await _applicationRepository.GetApplicationByIdAsync(applicationId);
            if (application == null)
                throw new Exception("Application not found.");

            if (application.JobPost.JobProviderId != jobProviderId)
                throw new UnauthorizedAccessException("Not allowed to shortlist this application.");

            var shortlist = new ShortList
            {
                ShortListId = Guid.NewGuid(),
                ApplicationId = application.JobApplicationId,
                JobSeekerId = application.JobSeekerId,
                JobProviderId = jobProviderId,
                CompanyUserId = application.JobPost.PostedById,// if applicable
                ShortListStatus = ShortListStatus.ShortListed,
            };

            await _applicationRepository.AddAsync(shortlist);
            await _applicationRepository.SaveChangesAsync();

            return _mapper.Map<ShortListDto>(shortlist);
        }
        public async Task<IEnumerable<ShortListDto>> GetShortlistsByProviderAsync(Guid jobProviderId)
        {
            var shortlists = await _applicationRepository
                .GetShortlistsByProviderAsync(jobProviderId);

            return _mapper.Map<IEnumerable<ShortListDto>>(shortlists);
        }
        public async Task<ShortListDto?> RejectApplicationAsync(Guid shortlistId)
        {
            var shortlist = await _applicationRepository.GetShortlistByIdAsync(shortlistId);
            if (shortlist == null) return null;

            shortlist.ShortListStatus = ShortListStatus.Rejected;

            await _applicationRepository.UpdateAsync(shortlist);
            await _applicationRepository.SaveChangesAsync();

            return _mapper.Map<ShortListDto>(shortlist);
        }





    }
}
