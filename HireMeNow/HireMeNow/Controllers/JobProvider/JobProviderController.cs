using AutoMapper;
using Domain.DTOs.JobProviderDTO;
using Domain.Interface.JobProvider;
using HireMeNowAD03.RequestObject.JobProvider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace HireMeNowAD03.Controllers.JobProvider
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class JobProviderController : BaseAPIController<JobProviderController>
    {
        private readonly IJobProviderService _service;
        private readonly IMapper _mapper;

        public JobProviderController(IJobProviderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        //1.Get Company User By ID
        [HttpGet("CompanyUser/{CompanyUserID}")]

        public async Task<IActionResult> GetCompanyUserByID(Guid CompanyUserID)
        {
            var CompanyUserFromDB = await _service.GetCompanyUserByID(CompanyUserID);
            if (CompanyUserFromDB == null)
            {
                return NotFound("Invalid CompanyUserId or CompanyUser Does Not Exist");
            }
            else
            {
                var CompanyUserDTO = _mapper.Map<CreateCompanyUserDTO>(CompanyUserFromDB);
                return Ok(CompanyUserDTO);
            }
        }


        //2. Get CompanyUser By JobProvider
        [HttpGet("CompanyUser/{CompanyUserID}/JobPrviderCompany/{JobProviderID}")]
        public async Task<IActionResult> GetCompanyUser(Guid CompanyUserID, Guid JobProviderID)
        {
            var CompanyUserFromDB = await _service.GetCompanyUserAsync(CompanyUserID, JobProviderID);
            if (CompanyUserFromDB == null)
            {

                return NotFound("Invalid CompanyUserId or JobProviderId");
            }
            else
            {
                var CompanyUserDTO = _mapper.Map<CreateCompanyUserDTO>(CompanyUserFromDB);
                return Ok(CompanyUserDTO);
            }
        }

        //3.Get CompanyUsersList By JobProvider
        [HttpGet("CompanyUserList/{JobProviderID}")]
        public async Task<IActionResult> GetCompanyUserListByJobProvider(Guid JobProviderID)
        {
            var CompanyUserList = await _service.GetCompanyUserListAsync(JobProviderID);
            if (CompanyUserList == null)
            {
                return NotFound("No Company Users found for this JobProvider.");
            }
            else
            {
                return Ok(CompanyUserList);
            }
        }

        //4.Add New CompanyUser
        [HttpPost("CompanyUser/AddNewCompanyUser")]
        public async Task<IActionResult> AddNewCompanyUserAsync(CreateCompanyUserRequest Request)
        {
            var CompanyUserDTO = _mapper.Map<CreateCompanyUserDTO>(Request);
            var NewCompanyUser = _mapper.Map<CompanyUser>(CompanyUserDTO);
            var AddedNewUser = await _service.AddNewCompanyUserAsync(NewCompanyUser);
            if (AddedNewUser != null)
            {
                return Ok(AddedNewUser);
            }
            else
            {
                return NotFound("A company user with the same Email under this JobProvider already exists.");
            }
        }


        //5.Update CompanyUser
        [HttpPut("CompanyUser/UpdateCompanyUser/{companyUserId}")]
        public async Task<IActionResult> UpdateCompanyUserAsync([FromRoute] Guid companyUserId, [FromBody] UpdateCompanyUserRequest request)
        {
            var ExistingUser = await _service.GetCompanyUserByID(companyUserId);
            if (ExistingUser == null)
            {
                return NotFound($"CompanyUser with ID {companyUserId} was not found.");
            }
            var updateCompanyUserDto = _mapper.Map<UpdateCompanyUserDTO>(request);
            var updatedCompanyUser = _mapper.Map<CompanyUser>(updateCompanyUserDto);

            ExistingUser = await _service.UpdateCompanyUserAsync(companyUserId, updatedCompanyUser);

            if (ExistingUser == null)
            {
                return NotFound($"CompanyUser with ID {companyUserId} was not found.");
            }

            return Ok(ExistingUser);
        }

        //6. Delete CompanyUser By ID
        [HttpDelete("CompanyUser/DeleteCompanyUser/{companyUserId}")]
        public async Task<IActionResult> DeleteCompanyUserAsync([FromRoute] Guid companyUserId)
        {
            var UserToDelete = await _service.DeleteCompanyUserAsync(companyUserId);

            if (UserToDelete != null)
            {
                return Ok($"The Company User {companyUserId} was deleted");
            }
            else
            {
                return NotFound($"Company User {companyUserId} was not found");
            }
        }

        //7. CompanyUser Count
        [HttpGet("CompanyUser/Count")]
        public async Task<IActionResult> GetCompanyUserCountAsync()
        {
            var count = await _service.GetCompanyUserCountAsync();
            return Ok(new { Count = count });
        }

        //8.Get JobProvider Company
        [HttpGet("JobProviderCompany/GetJobProviderCompanyByID/{jobProviderID}")]
        public async Task<IActionResult> GetJobProviderCompanyByID(Guid jobProviderID)
        {
            var CompanyFromDB = await _service.GetJobProviderCompanyByIDAsync(jobProviderID);
            if (CompanyFromDB != null)
            {
                return Ok(CompanyFromDB);
            }
            else
            {
                return NotFound($"The Job Provider Company With {jobProviderID} Was Not Found!");
            }
        }

        //9.Get All JobProviderList
        [HttpGet("JobProviderCompany/JobProviderCompaniesList")]
        public async Task<IActionResult> GetJobProviderCompaniesListAsync()
        {
            var CompanyList = await _service.GetJobProviderCompaniesList();
            if (CompanyList != null)
            {
                return Ok(CompanyList);
            }
            else
            {
                return NotFound("There Is No Companies Found! Please Try Again");
            }
        }

        //10.Get JobProvider Company By Location
        [HttpGet("JobProviderCompany/GetJobProviderCompaniesByLocation/{locationID}")]
        public async Task<IActionResult> GetJobProviderCompaniesByLocationAsync(Guid locationID)
        {
            var CompaniesByLocation = await _service.GetJobProviderCompaniesByLocationID(locationID);
            if (CompaniesByLocation != null)
            {
                return Ok(CompaniesByLocation);
            }
            else
            {
                return NotFound("There Is No Companies Found In This Location!");
            }

        }

        //11.Get JobProvider Company By Industry
        [HttpGet("JobProviderCompany/GetJobProviderCompaniesByIndustry/{industryID}")]
        public async Task<IActionResult> GetJobProviderCompaniesByIndustryAsync(Guid industryID)
        {
            var CompaniesByIndustry = await _service.GetJobProviderCompaniesByIndustryIDAsync(industryID);
            if (CompaniesByIndustry != null)
            {
                return Ok(CompaniesByIndustry);
            }
            else
            {
                return NotFound("There Is No Companies Found In This Location!");
            }

        }

        //12. Create New JobProvider Company
        [HttpPost("JobProviderCompany/CreateNewJobProviderCompany/{systemUserID}")]
        public async Task<IActionResult> CreateNewJobProviderCompanyAsync([FromRoute] Guid systemUserID, CreateJobProviderCompanyRequest request)
        {
            var CreateJobProviderCompanyDTO = _mapper.Map<CreateJobProviderCompanyDTO>(request);
            var NewCompany = _mapper.Map<JobProviderCompany>(CreateJobProviderCompanyDTO);
            var AddedCompany = await _service.CreateNewJobProviderCompanyAsync(systemUserID, NewCompany);
            if (AddedCompany != null)
            {

                return Ok(AddedCompany);

            }
            else
            {
                return NotFound("Failed to add the JobProvider Company");
            }
        }
        //13.Update JobProvider Company
        [HttpPut("JobProviderCompany/UpdateJobProviderCompany/{jobProviderID}")]
        public async Task<IActionResult> UpdateJobProviderCompanyAsync([FromRoute] Guid jobProviderID, UpdateJobProviderCompanyRequest request)
        {
            var UpdateJobProviderCompanyDTO = _mapper.Map<UpdateJobProviderCompanyDTO>(request);
            var UpdatedJobProviderCompany = _mapper.Map<JobProviderCompany>(UpdateJobProviderCompanyDTO);
            var UpdatedCompany = await _service.UpdateJobProviderCompanyAsync(jobProviderID, UpdatedJobProviderCompany);
            if (UpdatedCompany != null)
            {
                return Ok(UpdatedCompany);
            }
            else
            {
                return NotFound($"The Job Provider Company With {jobProviderID} Was Not Found!");
            }
        }


        //14. Delete JobProvider Company
        [HttpDelete("JobProviderCompany/DeleteJobProviderCompany/{jobProviderID}")]
        public async Task<IActionResult> DeleteJobProviderCompanyAsync(Guid jobProviderID)
        {
            var DeletedCompany = await _service.DeleteJobProviderCompanyAsync(jobProviderID);

            if (DeletedCompany != null)
            {
                return Ok($"JobProviderCompany and SystemUser with ID {jobProviderID} deleted successfully.");
            }
            else
            {
                return NotFound($"No JobProviderCompany or SystemUser found with ID {jobProviderID}");
            }
        }

        //15. JobProvider Company Count 
        [HttpGet("JobProviderCompany/GetCount")]
        public async Task<IActionResult> GetJobProviderCompanyCountAsync()
        {
            var Count = await _service.GetJobProviderCompanyCountAsync();
            return Ok($"Total Number Of JobProviderCompanies :{Count}");
        }

    }
}

        
               
               
            
               

                

                
      
 
