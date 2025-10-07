using AutoMapper;
using Domain.DTOs.JobSeekerDTO;
using Domain.Interface.JobSeeker;
using Domain.Service.JobSeeker;
using HireMeNowAD03.Controllers.JobProvider;
using HireMeNowAD03.RequestObject.JobSeeker;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNowAD03.Controllers.Jobseeker
{
    [Route("api/jobsearch")]
    [ApiController]
   
    public class JobSearchController : BaseAPIController<JobSearchController>
    {
        private readonly IJobSearchService _jobSearchService;
        private readonly ISaveJobService _saveJobService;
        private readonly IMapper _mapper;


        public JobSearchController(IJobSearchService service, IMapper mapper, ISaveJobService saveJobService)
        {
            _jobSearchService = service;
            _mapper = mapper;
            _saveJobService = saveJobService;

        }
        [HttpPost("search")]
        public async Task<IActionResult> SearchJobs([FromBody] JobSearchRequest request)
        {
            var results = await _jobSearchService.SearchJobsAsync(
                request.LocationId,
                request.JobTitle,
                request.JobType
            );

            if (!results.Any()) return NotFound(new { Message = "No jobs found" });
            return Ok(results);
        }
        // GetJobById
        [HttpGet("job/{jobId:guid}")]
        public async Task<IActionResult> GetJobById(Guid jobId)
        {
            var job = await _jobSearchService.GetJobByIdAsync(jobId);
            if (job == null) return NotFound("Job not found");
            return Ok(job);
        }

        //[HttpPost("{jobSeekerId:guid}/apply")]
        //public async Task<IActionResult> ApplyForJob(Guid jobSeekerId, [FromBody] ApplyJobRequest request)
        //{
        //    var dto = _mapper.Map<JobApplicationDto>(request);
        //    dto.JobSeekerId = jobSeekerId;

        //    var application = await _jobSearchService.ApplyJobAsync(dto);

        //    return CreatedAtAction(
        //        nameof(GetApplicationById),
        //        new { applicationId = application.JobApplicationId },
        //        application
        //    );
        //}

        //[HttpGet("application/{applicationId:guid}")]
        //public async Task<IActionResult> GetApplicationById(Guid applicationId)
        //{
        //    var app = await _jobSearchService.GetApplicationByIdAsync(applicationId);
        //    if (app == null) return NotFound();
        //    return Ok(app);
        //}

        //[HttpGet("job/applied-jobs/{jobSeekerId}")]
        //public async Task<IActionResult> GetAppliedJobs(Guid jobSeekerId)
        //{
        //    var jobs = await _jobSearchService.GetAppliedJobsAsync(jobSeekerId);
        //    return Ok(jobs);
        //}


        //[HttpPost("job/save/{jobSeekerId:guid}")]
        //public async Task<IActionResult> SaveJob(Guid jobSeekerId, [FromBody] SaveJobRequest request)
        //{
        //    try
        //    {
        //        var dto = _mapper.Map<SavedJobDto>(request);
        //        dto.JobSeekerId = jobSeekerId; 

        //        var savedJob = await _saveJobService.SaveJobAsync(dto);
        //        return Ok(new { Message = "Job saved successfully", SavedJob = savedJob });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { Error = ex.Message });
        //    }
        //}

        //[HttpGet("job/{jobSeekerId:guid}/saved-jobs")]
        //public async Task<IActionResult> GetSavedJobs(Guid jobSeekerId)
        //{
        //    try
        //    {
        //        var savedJobs = await _saveJobService.GetSavedJobsAsync(jobSeekerId);
        //        return Ok(savedJobs);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { Error = ex.Message });
        //    }
        //}

        //[HttpGet("job/{jobSeekerId}/saved-job/{savedJobId:guid}")]
        //public async Task<IActionResult> GetSavedJobById(Guid jobSeekerId, Guid savedJobId)
        //{
        //    var job = await _saveJobService.GetSavedJobByIdAsync(jobSeekerId, savedJobId);
        //    if (job == null)
        //        return NotFound(new { Message = "Saved job not found" });

        //    return Ok(job);
        //}
               

        //[HttpDelete("saved-jobs/{savedJobId:guid}")]
        //public async Task<IActionResult> RemoveSavedJob(Guid savedJobId, [FromQuery] Guid jobSeekerId)
        //{
        //    try
        //    {
        //        var success = await _saveJobService.RemoveSavedJobAsync(jobSeekerId, savedJobId);
        //        if (!success)
        //            return NotFound(new { Message = "Saved job not found or you don’t have access to delete it" });

        //        return Ok(new { Message = "Saved job removed successfully" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { Error = ex.Message });
        //    }
        //}



    }
}
