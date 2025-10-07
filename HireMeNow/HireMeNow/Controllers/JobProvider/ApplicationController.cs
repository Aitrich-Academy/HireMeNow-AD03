using AutoMapper;
using Domain.Interface.JobProvider;
using Domain.Service.JobProvider;
using HireMeNowAD03.RequestObject.JobProvider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNowAD03.Controllers.JobProvider
{
    [Route("api/jobprovider")]
    [ApiController]
   [Authorize(Roles = "JobProvider")]
    public class ApplicationController : BaseAPIController<ApplicationController>
    {
        private readonly IApplicationService _applicationService;
        private readonly IMapper _mapper;
        public ApplicationController(IApplicationService applicationService, IMapper mapper)
        {
            _applicationService = applicationService;
            _mapper = mapper;
        }

        [HttpGet("applications/{applicationId:guid}")]
        public async Task<IActionResult> GetApplicationById(Guid applicationId)
        {
            var application = await _applicationService.GetApplicationByIdAsync(applicationId);
            if (application == null)
                return NotFound(new { Message = "Application not found" });

            return Ok(application);
        }
        [HttpGet("jobpost/{jobPostId:guid}/applications")]
        public async Task<IActionResult> GetApplicationsByJobPostId(Guid jobPostId)
        {
            var applications = await _applicationService.GetApplicationsByJobPostIdAsync(jobPostId);

            if (!applications.Any())
                return NotFound(new { Message = "No applications found for this job." });

            return Ok(applications);
        }
        // Count applications for a job post
        [HttpGet("jobposts/{jobPostId:guid}/applications/count")]
        public async Task<IActionResult> CountApplications(Guid jobPostId)
        {
            var count = await _applicationService.CountApplicationsAsync(jobPostId);
            return Ok(new { JobPostId = jobPostId, TotalApplications = count });
        }

        [HttpPut("applications/{applicationId:guid}/status")]
        public async Task<IActionResult> UpdateApplicationStatus(Guid applicationId, [FromBody] UpdateApplicationStatusRequest request)
        {
            var updated = await _applicationService.UpdateStatusAsync(applicationId, request.Status);

            if (updated == null)
                return NotFound($"No application found with ID {applicationId}");

            return Ok(updated);
        }
        // Shortlist application
        [HttpPost("applications/{applicationId:guid}/shortlist")]
        public async Task<IActionResult> ShortlistApplication(Guid applicationId, [FromBody] ShortlistApplicationRequest request)
        {
            try
            {
                var shortlist = await _applicationService.ShortlistApplicationAsync(applicationId, request.JobProviderId);
                return Ok(shortlist);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpGet("providers/{jobProviderId:guid}/shortlists")]
        public async Task<IActionResult> GetShortlistsByProvider(Guid jobProviderId)
        {
            var shortlists = await _applicationService.GetShortlistsByProviderAsync(jobProviderId);
            if (!shortlists.Any())
                return NotFound(new { Message = "No shortlists found for this provider" });

            return Ok(shortlists);
        }

        [HttpPut("shortlists/{shortlistId:guid}/reject")]
        public async Task<IActionResult> RejectApplication(Guid shortlistId)
        {
            var result = await _applicationService.RejectApplicationAsync(shortlistId);
            if (result == null)
                return NotFound(new { Message = "Shortlist not found" });

            return Ok(result);
        }




    }
}
