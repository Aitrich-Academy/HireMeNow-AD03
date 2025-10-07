using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Data;
using Domain.DTOs.JobSeekerDTO;
using Domain.Interface.JobSeeker;
using Domain.Models;
using Domain.Repository.JobSeeker;
using Microsoft.EntityFrameworkCore;

namespace Domain.Service.JobSeeker
{
    public class SaveJobService:ISaveJobService
    {
        private readonly ISaveJobRepository _saveJobRepository;
        private readonly IMapper _mapper;
        public SaveJobService(ISaveJobRepository repo, IMapper mapper)
        {
            _saveJobRepository = repo;
            _mapper = mapper;
            
        }
       
        public async Task<SavedJobDto> SaveJobAsync(SavedJobDto requestdto)
        {

            // Prevent duplicate saves
            var existing = await _saveJobRepository.GetByJobSeekerAndPostAsync(requestdto.JobSeekerId, requestdto.JobPostId);
            if (existing != null)
                throw new Exception("You have already saved this job.");


            var entity = new SavedJob
            {
                SavedJobId = Guid.NewGuid(),
                JobSeekerId = requestdto.JobSeekerId,
                JobPostId = requestdto.JobPostId,
                SavedDate = DateTime.UtcNow
            };

            await _saveJobRepository.AddAsync(entity);

            return _mapper.Map<SavedJobDto>(entity);
        }
       
        //public async Task<IEnumerable<SavedJobDto>> GetSavedJobsAsync(Guid jobSeekerId)
        //{
        //    var savedJobs = await _saveJobRepository.GetByJobSeekerAsync(jobSeekerId);
        //                          return _mapper.Map<IEnumerable<SavedJobDto>>(savedJobs);
           
        //}
        public async Task<IEnumerable<SavedJobDto>> GetSavedJobsAsync(Guid jobSeekerId)
        {
            var savedJobs = await _saveJobRepository.GetByJobSeekerAsync(jobSeekerId);

            return savedJobs.Select(s => new SavedJobDto
            {
                SavedJobId = s.SavedJobId,
                JobSeekerId = s.JobSeekerId,
                JobPostId = s.JobPostId,
                SavedDate = s.SavedDate,
               // JobTitle = s.JobPost.JobTitle,
              //  CompanyName = s.JobPost.PostedByUser.CompanyName
            });
        }


        //public async Task<SavedJobDto?> GetSavedJobByIdAsync(Guid jobSeekerId, Guid savedJobId)
        //{
        //    var savedJob = await _saveJobRepository.GetByIdAsync(jobSeekerId, savedJobId);
        //    return _mapper.Map<SavedJobDto?>(savedJob);
        //}
        public async Task<SavedJobDto?> GetSavedJobByIdAsync(Guid jobSeekerId, Guid savedJobId)
        {
            var savedJob = await _saveJobRepository.GetByIdAsync(jobSeekerId, savedJobId);

            if (savedJob == null) return null;

            return new SavedJobDto
            {
                SavedJobId = savedJob.SavedJobId,
                JobSeekerId = savedJob.JobSeekerId,
                JobPostId = savedJob.JobPostId,
                SavedDate = savedJob.SavedDate,
                //JobTitle = savedJob.JobPost.JobTitle,
               // CompanyName = savedJob.JobPost.PostedByUser.CompanyName
            };
        }
        public async Task<bool> RemoveSavedJobAsync(Guid jobSeekerId, Guid savedJobId)
        {
            var savedJob = await _saveJobRepository.GetByIdAsync(jobSeekerId, savedJobId);
            if (savedJob == null)
                return false;

            await _saveJobRepository.DeleteAsync(savedJob);
            return true;
        }






       
    }
}
