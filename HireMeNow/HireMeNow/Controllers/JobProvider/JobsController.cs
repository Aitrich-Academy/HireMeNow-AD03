using AutoMapper;
using Domain.DTOs.JobProviderDTO;
using Domain.Interface.JobProvider;
using Domain.Models;
using Domain.Service.JobProvider;
using HireMeNowAD03.RequestObject.JobProvider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNowAD03.Controllers.JobProvider
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class JobsController : BaseAPIController<JobsController>
    {
        private readonly IJobService _service;
        private readonly IMapper _mapper;

        public JobsController(IJobService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //1. Post New Job
        [HttpPost("PostNewJob/{companyUserID}")]
        public async Task<IActionResult> PostNewJobAsync([FromRoute] Guid companyUserID, CreateNewJobPostRequest request)
        {
            var CreateNewJobPostDTO = _mapper.Map<CreateNewJobPostDTO>(request);
            var NewJobPost = _mapper.Map<JobPost>(CreateNewJobPostDTO);
            var PostToAdd = await _service.CreateNewJobPostByCompanyUserAsync(companyUserID, NewJobPost);
            if (PostToAdd != null)
            {
                return Ok($"New Post Added Successfully By The CompanyUser {companyUserID}");
            }
            else
            {
                return BadRequest("Unable to create the job post. Please check the data and try again.");
            }
        }

        //2.Update Job Post
        [HttpPut("UpdateJobPost/{jobPostID}")]
        public async Task<IActionResult> UpdateJobPostAsync([FromRoute] Guid jobPostID, UpdateJobPostRequest request)
        {
            var UpdateJobPostDTO = _mapper.Map<UpdateJobPostDTO>(request);
            var UpdatedPost = _mapper.Map<JobPost>(UpdateJobPostDTO);
            var PostToUpdate = await _service.UpdateJobPostAsync(jobPostID, UpdatedPost);
            if (PostToUpdate != null)
            {
                return Ok($"The JobPost With ID{jobPostID} Updated Successfully");
            }
            else
            {
                return BadRequest("Unable to Update the job post. Please check the data and try again.");
            }
        }

        //3. Get All Jobs Published By A CompanyUser
        [HttpGet("GetAllJobListByCompanyUser/{companyUserID}")]
        public async Task<IActionResult> GetAllJobListByCompanyUserAsync([FromRoute] Guid companyUserID)
        {
            var jobList = await _service.GetAllJobListsByCompanyUserIDAsync(companyUserID);

            if (jobList == null)
            {
                return NotFound($"No CompanyUser found with ID {companyUserID}");
            }

            if (!jobList.Any())
            {
                return NotFound($"There are no jobs published under this CompanyUser with ID {companyUserID}");
            }

            return Ok(jobList);
        }

        //4. Get All Jobs Published By A JobProviderCompany
        [HttpGet("GetAllJobListByJobProviderCompanyAsync/{jobProviderID}")]
        public async Task<IActionResult> GetAllJobListByJobProviderCompanyAsync([FromRoute] Guid jobProviderID)
        {
            var jobList = await _service.GetAllJobListByJobProviderCompanyAsync(jobProviderID);

            if (jobList == null)
            {
                return NotFound($"No JobProvider Company found with ID {jobProviderID}");
            }

            if (!jobList.Any())
            {
                return NotFound($"There are no jobs published under this JobProviderCompany with ID {jobProviderID}");
            }

            return Ok(jobList);
        }

        //5. Get JobDetails Using JobPostID
        [HttpGet("GetDetailedJobPostByJobPostIDAsync/{jobPostID}")]
        public async Task<IActionResult> GetDetailedJobPostByJobPostIDAsync([FromRoute] Guid jobPostID)
        {
            var JobDetails = await _service.GetDetailedJobPostAsync(jobPostID);
            if (JobDetails == null)
            {
                return NotFound($"No JobPost With ID {jobPostID} Exists in The Database");
            }
            else
            {
                return Ok(JobDetails);
            }
        }

        //6.Get All JobPosts Under a Specific Location
        [HttpGet("GetJobsByLocationAsync/{locID}")]
        public async Task<IActionResult> GetJobsByLocationAsync([FromRoute] Guid locID)
        {
            var JobsByLocation = await _service.GetJobsByLocationAsync(locID);
            if (JobsByLocation == null)
            {
                return NotFound($"No JobPosts Exists in this particular Location With ID {locID} ");
            }
            else
            {
                return Ok(JobsByLocation);
            }
        }

        //7.Get All JobPosts Under a Specific Industry
        [HttpGet("GetJobsByIndustryAsync/{indID}")]
        public async Task<IActionResult> GetJobsByIndustryAsync([FromRoute] Guid indID)
        {
            var JobListByIndustry = await _service.GetJobsByIndustryAsync(indID);
            if (JobListByIndustry == null)
            {
                return NotFound($"No JobPosts Exists in this particular Industry With ID {indID} ");
            }
            else
            {
                return Ok(JobListByIndustry);
            }
        }

        //8. Get All JobPost List
        [HttpGet("JobPost/GetAllJobPostList")]
        public async Task<IActionResult> GetAllJobPostListsAsync()
        {
            var JobPostList = await _service.GetAllJobPostListAsync();
            if(JobPostList == null)
            {
                return NotFound("No JobPosts are Available At the Moment");
            }
            else
            {
                return Ok(JobPostList);
            }
        }

        //9. Delete Job By JobID
        [HttpDelete("JobPost/DeleteJobByID/{jobID}")]
        public async Task<IActionResult> DeleteJobByIDAsync(Guid jobID)
        {
            var deletedJob = await _service.DeleteJobByIDAsync(jobID);

            if (deletedJob != null)
            {
                return Ok($"The Job with ID {jobID} has been deleted from your account.");
            }
            else
            {
                return NotFound($"No JobPost exists with ID {jobID} in this industry.");
            }
        }

        //10.JobPost Count 
        [HttpGet("JobPost/Count")]
        public async Task<IActionResult> GetJobPostCountAsync()
        {
            var count = await _service.GetJobPostCountAsync();
            return Ok($"Total number of Job Posts: {count}");
        }

    }
}

