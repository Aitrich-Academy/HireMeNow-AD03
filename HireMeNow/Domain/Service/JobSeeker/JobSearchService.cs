using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Data;
using Domain.DTOs.JobSeekerDTO;
using Domain.Enums;
using Domain.Interface.JobSeeker;
using Domain.Models;
using Domain.Repository.JobSeeker;

namespace Domain.Service.JobSeeker
{
    public class JobSearchService:IJobSearchService
    {
        private readonly IJobSearchRepository _jobSearchRepository;  
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public JobSearchService(IJobSearchRepository repo, IMapper mapper, AppDbContext context)
        {
             _jobSearchRepository= repo;
            _mapper = mapper;
            _context = context;
        }
        public async Task<IEnumerable<JobSearchResultDto>> SearchJobsAsync(Guid? locationId, string? jobTitle, JobType? jobType)
        {
            var jobs = await _jobSearchRepository.SearchJobsAsync(locationId, jobTitle, jobType);
            return _mapper.Map<IEnumerable<JobSearchResultDto>>(jobs);
        }
        public async Task<JobPostDto?> GetJobByIdAsync(Guid id)
        {
            var job = await _jobSearchRepository.GetJobByIdAsync(id);
            return _mapper.Map<JobPostDto>(job);
        }
        public async Task<JobApplicationDto> ApplyJobAsync(JobApplicationDto dto)
        {
            // Map DTO → Entity
            var entity = _mapper.Map<JobApplication>(dto);

            // Save to DB
            var created = await _jobSearchRepository.ApplyJobAsync(entity);

            // Map Entity → DTO
            return _mapper.Map<JobApplicationDto>(created);
        }
        public async Task<JobApplicationDto?> GetApplicationByIdAsync(Guid applicationId)
        {
            var application = await _jobSearchRepository.GetApplicationByIdAsync(applicationId);
            return application == null ? null : _mapper.Map<JobApplicationDto>(application);
        }
        public async Task<IEnumerable<JobApplicationDto>> GetAppliedJobsAsync(Guid jobSeekerId)
        {
            var applications = await _jobSearchRepository.GetAppliedJobsAsync(jobSeekerId);
            return _mapper.Map<IEnumerable<JobApplicationDto>>(applications);
        }

        //
        public async Task<JobApplicationDto?> GetAppliedJobByIdAsync(Guid applicationId)
        {
            var application = await _jobSearchRepository.GetByIdAsync(applicationId);
            return _mapper.Map<JobApplicationDto?>(application);
        }






    }
}
