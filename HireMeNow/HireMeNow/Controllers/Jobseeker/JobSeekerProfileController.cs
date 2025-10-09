using AutoMapper;
using Domain.DTOs.AuthUserDTO;
using Domain.DTOs.JobSeekerDTOs;
using Domain.Helpers;
using Domain.Interface.JobSeeker;
using Domain.Models;
using HireMeNowAD03.RequestObject.JobSeeker;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HireMeNowAD03.Controllers.Jobseeker
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "JobSeeker")]
    public class JobSeekerProfileController : BaseAPIController<JobSeekerProfileController>
    {
        private readonly IJobSeekerProfileService _profileService;
        private readonly IMapper _mapper;
        public JobSeekerProfileController(IJobSeekerProfileService profileService, IMapper mapper)
        {
            _profileService = profileService;
            _mapper = mapper;
        }

        //JobSeeker
        [HttpGet("jobseekers/{jobseekerId}")]
        public async Task<IActionResult> ViewJobSeekerDetails(Guid jobseekerId)
        {
            var Profile = await _profileService.GetJobSeekerDetailsAsync(jobseekerId);
            if (Profile == null)
                return NotFound();
            return Ok(Profile);
        }

        [HttpPut("jobseekers")]
        public async Task<IActionResult> EditJobSeekerDetails([FromForm] AuthUserDTO updatedProfile)
        {
            try
            {
                var result = await _profileService.UpdateJobSeekerDetailsAsync(updatedProfile);
                if (result != null)
                    return Ok(result);
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }               

        //Profile
        [HttpPost("jobseekers/profiles")]
        public async Task<IActionResult> CreateProfile(JobSeekerProfileRequestDTO profileRequestDTO)
        {
            var profileDTO = _mapper.Map<JobSeekerProfileDTO>(profileRequestDTO);
            var result = await _profileService.AddProfileAsync(profileDTO);
            if (result)
                return Ok("Profile Created Successfully");
            return BadRequest("Failed to Create Profile");
        }

        [HttpGet("jobseekers/{jobseekerId}/profiles")]
        public async Task<IActionResult> GetAllProfilesById(Guid jobseekerId)
        {
            var profiles = await _profileService.GetAllProfilesByIdAsync(jobseekerId);
            return Ok(_mapper.Map<List<JobSeekerProfileDTO>>(profiles));
        }

        [HttpGet("jobseekers/{jobseekerId}/profiles/{profileId}")]
        public async Task<IActionResult> ViewProfile(Guid jobseekerId,Guid profileId)
        {
            var Profile = await _profileService.GetProfile(jobseekerId, profileId);
            if (Profile == null)
                return NotFound();
            return Ok(Profile);
        }

        [HttpPut("jobseekers/profiles")]
        public async Task<IActionResult> UpdateProfile(JobSeekerProfileRequestDTO profileRequestDTO)
        {
            var profileDTO = _mapper.Map<JobSeekerProfileDTO>(profileRequestDTO);
            var result = await _profileService.UpdateProfileAsync(profileDTO);
            if (result)
                return Ok("Profile Updated Successfully");
            return BadRequest("Failed to Update Profile");
        }

        [HttpDelete("jobseekers/{jobseekerId}/profiles/{profileId}")]
        public async Task<IActionResult> DeleteProfile(Guid jobseekerId, Guid profileId)
        {
            var result = await _profileService.DeleteProfileAsync(jobseekerId, profileId);
            if (result)
                return Ok("Profile Deleted Successfully");
            return BadRequest("Failed to Delete Profile");
        }

        //Qualification
        [HttpPost("jobseekers/{jobseekerId}/profiles/{profileId}/qualifications")]
        public async Task<IActionResult> AddQualification(Guid jobseekerId, Guid profileId, QualificationRequestDTO data)
        {
            var JobseekerQualificationDTO = _mapper.Map<QualificationDTO>(data);
            var result = await _profileService.AddQualificationAsync(jobseekerId, profileId, JobseekerQualificationDTO);
            if (result)
                return Ok("Qualification Added Successfully");
            return BadRequest("Failed to Add Qualification");
        }

        [HttpGet("jobseekers/profiles/{profileId}/qualifications")]
        public ActionResult<List<QualificationDTO>> ViewQualifications(Guid profileId)
        {
            var Qualification = _profileService.GetQualifications(profileId);
            if (Qualification == null || !Qualification.Any())
                return NotFound();
            return Ok(Qualification);
        }

        [HttpPut("jobseekers/{jobseekerId}/profiles/{profileId}/qualifications/{qualificationId}")]        
        public async Task<IActionResult> UpdateQualificationAsync(Guid jobseekerId, Guid profileId, Guid qualificationId, QualificationRequestDTO data)
        {
            var qualificationDTO = _mapper.Map<QualificationDTO>(data);
            var result = await _profileService.UpdateQualificationAsync(jobseekerId, profileId, qualificationId, qualificationDTO);
            if (result)
                return Ok("Qualification Updated Successfully");
            return BadRequest("Failed to Update Qualification");             
        }

        [HttpDelete("jobseekers/{jobseekerId}/profiles/{profileId}/qualifications/{qualificationId}")]        
        public async Task<IActionResult> DeleteQualificationAsync(Guid jobseekerId, Guid profileId, Guid qualificationId)
        {
            var result = await _profileService.DeleteQualificationAsync(jobseekerId, profileId, qualificationId);
            if (result)
                return Ok("Qualification Deleted Successfully");
            return BadRequest("Failed to Delete Qualification");
        }

        //Skill
        [HttpPost("jobseekers/{jobseekerId}/profiles/{profileId}/skills")]        
        public async Task<IActionResult> AddSkill(Guid jobseekerId, Guid profileId, ProfileSkillRequestDTO data)
        {
            try
            {
                var skillDTO = new JobSeekerProfileSkillDTO
                {
                    JobSeekerProfileId = profileId,
                    SkillId = data.SkillId
                };
                var result = await _profileService.AddSkillAsync(jobseekerId, profileId, skillDTO);
                if (result)
                    return Ok("Skill Added Successfully");
                return NotFound("Profile not found.");
            }
           catch(SkillAlreadyExistsException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest("Failed to Add skill.");
            }
        }

        [HttpGet("jobseekers/profiles/{profileId}/skills")]        
        public async Task<IActionResult> ViewSkills(Guid profileId)
        {
            var skills = await _profileService.GetSkillsAsync(profileId);
            if (skills == null)
                return NotFound();
            return Ok(_mapper.Map<List<JobSeekerProfileSkillDTO>>(skills));
        }

        [HttpGet("jobseekers/profiles/{profileId}/skills/{skillId}")]
        public async Task<IActionResult> GetSkillById(Guid profileId, Guid skillId)
        {
            var skill = await _profileService.GetSkillByIdAsync(profileId, skillId);
            if (skill == null) return NotFound();
            return Ok(_mapper.Map <JobSeekerProfileSkillDTO>(skill));
        }
        
        [HttpPut("jobseekers/{jobseekerId}/profiles/{profileId}/skills/{skillId}")]
        public async Task<IActionResult> UpdateSkill(Guid jobseekerId, Guid profileId, Guid skillId, ProfileSkillRequestDTO data)
        {
            try
            {
                //Delete the old skill
                var deleteResult = await _profileService.DeleteSkillAsync(profileId, skillId);
                if (!deleteResult)
                    return NotFound("Skill not found");
                //Add the new skill
                var skillDTO = new JobSeekerProfileSkillDTO
                {
                    JobSeekerProfileId = profileId,
                    SkillId = data.SkillId
                };
                var result = await _profileService.AddSkillAsync(jobseekerId, profileId, skillDTO);
                if (result)
                    return Ok("Skill Spdated Successfully.");
                return BadRequest("Failed to Update Skill.");
            }
            catch (SkillAlreadyExistsException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to Update skill.");
            }
        }

        [HttpDelete("jobseekers/profiles/{profileId}/skills/{skillId}")]
        public async Task<IActionResult> DeleteSkill(Guid profileId, Guid skillId)
        {
            var result = await _profileService.DeleteSkillAsync(profileId, skillId);
            if (result)
                return Ok("Skill Deleted Successfully");
            return BadRequest("Failed to Delete Skill");
        }

        //Resume
        [HttpPost("jobseekers/{jobseekerId}/profiles/{profileId}/resumes")]        
        public async Task<IActionResult> AddResume(Guid jobseekerId, Guid profileId, [FromForm] ResumeRequestDTO data)
        {
            try
            {
                //var resumeDTO = _mapper.Map<ResumeDTO>(data);
                if (data.File == null || data.File.Length == 0)
                    return BadRequest("File is required.");

                using var memoryStream = new MemoryStream();
                await data.File.CopyToAsync(memoryStream);

                var resumeDTO = new ResumeDTO
                {
                    ResumeId = Guid.NewGuid(),
                    ResumeTitle = data.ResumeTitle,
                    File = memoryStream.ToArray()
                };
                var result = await _profileService.AddResumeAsync(jobseekerId, profileId, resumeDTO);
                if (result)
                    return Ok("Resume Added Successfully");
                return BadRequest("Failed to Add Resume");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [HttpGet("jobseekers/{jobseekerId}/resumes")]
        public async Task<IActionResult> GetAllResumesById(Guid jobseekerId)
        {
            var resumes = await _profileService.GetAllResumesByJobSeekerIdAsync(jobseekerId);
            if (resumes == null || !resumes.Any())
                return NotFound();
            return Ok(_mapper.Map<List<ResumeDTO>>(resumes));
        }

        [HttpGet("jobseekers/profiles/{profileId}/resume")]        
        public async Task<IActionResult> ViewResume(Guid profileId)
        {
            var resume = await _profileService.GetResumeAsync(profileId);
            if (resume == null )
                return NotFound();
            return Ok(resume);
        }        

        [HttpGet("jobseekers/profiles/resumes/{resumeId}")]
        public async Task<IActionResult> GetResumeById(Guid resumeId)
        {
            var resume = await _profileService.GetResumeByIdAsync(resumeId);
            if (resume == null) return NotFound();
            return Ok(resume);
        }

        [HttpPut("profiles/{profileId}/resumes")] 
        public async Task<IActionResult> UpdateResume(Guid profileId, [FromForm] ResumeRequestDTO data)
        {
            //var resumeDTO = _mapper.Map<ResumeDTO>(data);
            //await _profileService.UpdateResumeAsync(profileId, resumeDTO);
            //return Ok(data);
            if (data.File == null || data.File.Length == 0)
                return BadRequest("File is required.");

            using var memoryStream = new MemoryStream();
            await data.File.CopyToAsync(memoryStream);

            var resumeDTO = new ResumeDTO
            {
                ResumeId = Guid.NewGuid(),
                ResumeTitle = data.ResumeTitle,
                File = memoryStream.ToArray()
            };
            var result = await _profileService.UpdateResumeAsync(profileId, resumeDTO);
            if (result)
                return Ok("Resume Updated Successfully");
            return BadRequest("Failed to Update Resume");
        }

        [HttpDelete("resumes/{resumeId}")]        
        public async Task<IActionResult> DeleteResume(Guid resumeId)
        {
            var result = await _profileService.DeleteResumeAsync(resumeId);
            if (result)
                return Ok("Resume Deleted Successfully");
            return BadRequest("Failed to Delete Resume");
        }

        //Experience
        [HttpPost("jobseekers/{jobseekerId}/profiles/{profileId}/experiences")] 
        public async Task<IActionResult> AddExperience(Guid jobseekerId, Guid profileId, WorkExperienceRequestDTO data)
        {
            var experienceDTO = _mapper.Map<WorkExperienceDTO>(data);
            var result = await _profileService.AddExperienceAsync(jobseekerId, profileId, experienceDTO);
            if (result)
                return Ok("Work Experience Added Successfully");
            return BadRequest("Failed to Add Work Experience");
        }

        [HttpGet("jobseekers/profiles/{profileId}/experiences")]        
        public async Task<IActionResult> ViewExperience(Guid profileId)
        {
            var experience = await _profileService.GetExperience(profileId);
            if (experience == null || !experience.Any())
                return NotFound();
            return Ok(experience);
        }

        [HttpPut("jobseekers/{jobseekerId}/profiles/{profileId}/experiences/{experienceId}")]        
        public async Task<IActionResult> UpdateExperienceAsync(Guid jobseekerId, Guid profileId,Guid experienceId, WorkExperienceRequestDTO data)
        {
            var experienceDTO = _mapper.Map<WorkExperienceDTO>(data);
            var result = await _profileService.UpdateExperienceAsync(jobseekerId, profileId, experienceId, experienceDTO);
            if (result)
                return Ok("Work Experience Updated Successfully");
            return BadRequest("Failed to Update Work Experience");
        }

        [HttpDelete("jobseekers/{jobseekerId}/profiles/{profileId}/experiences/{experienceId}")]        
        public async Task<IActionResult> DeleteExperienceAsync(Guid jobseekerId, Guid profileId, Guid experienceId)
        {
            var result = await _profileService.DeleteExperienceAsync(jobseekerId, profileId, experienceId);
            if (result)
                return Ok("Work Experience Deleted Successfully");
            return BadRequest("Failed to Delete Work Experience");
        }
    }
}
