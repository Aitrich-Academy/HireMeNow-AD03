using AutoMapper;
using Domain.DTOs.JobProviderDTO;
using Domain.Interface.JobProvider;
using HireMeNowAD03.RequestObject.JobProvider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNowAD03.Controllers.JobProvider
{
    [Route("api/jobprovider")]
    [ApiController]
    [Authorize(Roles = "JobProvider")]
    public class InterviewController : BaseAPIController<InterviewController>
    {
        
        private readonly IInterviewService _interviewService;
        private readonly IMapper _mapper;
        public InterviewController(IInterviewService interviewService, IMapper mapper)
        {
            _interviewService = interviewService;
            _mapper = mapper;
        }
        [HttpPost("interviews")]
        public async Task<IActionResult> CreateInterview([FromBody] CreateInterviewRequest request)
        {
            var interviewDto = _mapper.Map<Domain.DTOs.JobProviderDTO.CreateInterviewDto>(request);

            var createdInterview = await _interviewService.CreateInterviewAsync(interviewDto);

            return CreatedAtAction(nameof(GetInterviewById), new { interviewId = createdInterview.InterviewId }, createdInterview);
        }

        [HttpPut("update-interview/{id:guid}")]
        public async Task<IActionResult> UpdateInterview(Guid id, [FromBody] UpdateInterviewRequest request)
        {
            try
            {
                var dto = _mapper.Map<UpdateInterviewDto>(request);
                dto.InterviewId = id;

                var updatedInterview = await _interviewService.UpdateInterviewAsync(dto);
                if (updatedInterview == null)
                    return NotFound("Interview not found");

                return Ok(updatedInterview);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("interviews/count/jobprovider/{jobProviderId:guid}")]
        public async Task<IActionResult> GetInterviewCountByJobProvider(Guid jobProviderId)
        {
            try
            {
                var count = await _interviewService.GetInterviewCountByJobProviderAsync(jobProviderId);
                return Ok(new { JobProviderId = jobProviderId, TotalInterviews = count });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("interviews/jobprovider/{jobProviderId:guid}")]
        public async Task<IActionResult> GetInterviewsByJobProvider(Guid jobProviderId)
        {
            var interviews = await _interviewService.GetInterviewsByJobProviderAsync(jobProviderId);

            if (!interviews.Any())
                return NotFound(new { Message = "No interviews found for this JobProvider" });

            return Ok(interviews);
        }

        [HttpGet("interviews/{interviewId:guid}")]
        public async Task<IActionResult> GetInterviewById(Guid interviewId)
        {
            var result = await _interviewService.GetByIdAsync(interviewId);
            if (result == null)
                return NotFound(new { Message = "Interview not found" });

            return Ok(result);
        }

        //[HttpGet("interviews/jobseeker/{jobSeekerId:guid}")]
        //public async Task<IActionResult> GetInterviewsByJobSeeker(Guid jobSeekerId)
        //{
        //    var interviews = await _interviewService.GetInterviewsByJobSeekerAsync(jobSeekerId);

        //    if (interviews == null || !interviews.Any())
        //        return NotFound("No interviews found for this Job Seeker.");

        //    return Ok(interviews);
        //}

        [HttpGet("interviews/jobpost/{jobPostId:guid}")]
        public async Task<IActionResult> GetInterviewsByJobPost(Guid jobPostId)
        {
            var interviews = await _interviewService.GetInterviewsByJobPostAsync(jobPostId);

            if (interviews == null || !interviews.Any())
                return NotFound("No interviews found for this Job Post.");

            return Ok(interviews);
        }

        [HttpDelete("interviews/{interviewId:guid}")]
        public async Task<IActionResult> DeleteInterview(Guid interviewId)
        {
            try
            {
                var deleted = await _interviewService.DeleteInterviewAsync(interviewId);
                if (!deleted)
                    return NotFound(new { Message = "Interview not found." });

                return NoContent(); // 204 No Content for successful deletion
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

    }
}
