using AutoMapper;
using Domain.DTOs.LogInDTO;
using Domain.DTOs.SignUpDTO;
using Domain.Enums;
using Domain.Interface.AuthUser;
using Domain.Interface.SignUp;
using Domain.Models;
using HireMeNowAD03.RequestObject.Admin;
using HireMeNowAD03.RequestObject.JobProvider;
using HireMeNowAD03.RequestObject.JobProvider.HireMeNow_WebApi.API.JobProvider.RequestObjects;
using HireMeNowAD03.RequestObject.JobSeeker;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNowAD03.Controllers.Auth
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : BaseAPIController<AuthController>
    {
        private readonly ISignUpRequestService _signUpService;
        private readonly IAuthUserService _authService;
        private readonly IMapper _mapper;
        public AuthController(ISignUpRequestService signUpService,IAuthUserService authUserService,IMapper mapper)
        {
            _signUpService = signUpService;
            _authService = authUserService;
            _mapper = mapper;
        }
        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<IActionResult> Signup([FromQuery] Roles role, [FromBody] SignupRequest request)
        {
            if (!Enum.IsDefined(typeof(Roles), role) || (role != Roles.JobSeeker && role != Roles.JobProvider))
                return BadRequest("Invalid role. Must be JobSeeker or JobProvider.");

            var dto = _mapper.Map<SignUpRequestDto>(request);
            var signupId = await _signUpService.CreateSignupRequestAsync(dto, role);

            return Ok(new { SignupId = signupId, Message = "Verification email sent" });
        }


        [HttpGet("verify-email/{signupId}")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyEmail(Guid signupId)
        {
            var result = await _signUpService.VerifyEmailAsync(signupId);
            if (!result) return BadRequest("Invalid or already verified.");
            return Ok("Email verified Successfully");
        }

        [HttpPost("set-password")]
        [AllowAnonymous]
        public async Task<IActionResult> SetPassword([FromQuery] Guid signupId,[FromQuery] Roles role,[FromBody] SetPasswordRequest request)
        {
            try
            {
                var user = await _signUpService.CreateUserAsync(signupId,request.Password, role);

                if (user == null)
                    return BadRequest("Failed to create user. Please try again.");
                return Ok(new
                {
                    user.SystemUserId, 
                    user.Email,
                    user.Role,
                    Message = "Password set successfully. You can now login."
                });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong while setting the password.");
            }
        }



        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _authService.LoginAsync(request.Email?.Trim(),request.Password);
            if (result == null) return BadRequest("Invalid credentials");

            return Ok(result);
        }
    }
}
