using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.LogInDTO;
using Domain.Enums;
using Domain.Interface.AuthUser;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Domain.Service.AuthUser
{
    public class AuthUserService:IAuthUserService
    {
        private readonly IAuthUserRepository _authRepo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public AuthUserService(IAuthUserRepository authRepo, IMapper mapper,IConfiguration config)
        {
            _authRepo = authRepo;
            _mapper = mapper;
            _config = config;
        }
        //public async Task<LoginDto?> LoginAsync(string email, string password,Roles role)
        //{
        //    var user = await _authRepo.GetAuthUserByEmailAndRoleAsync(email,role);
        //    if (user == null || user.Password != password) return null;

        //    var dto = _mapper.Map<LoginDto>(user);
        //    dto.Token = GenerateJwtToken(user);
        //    return dto;
        //}
        public async Task<LoginDto?> LoginAsync(string email, string password)
        {
            var user = await _authRepo.GetAuthUserByEmail(email);
            if (user == null || user.Password != password) return null;

            var dto = _mapper.Map<LoginDto>(user);
            dto.Token = GenerateJwtToken(user);
            return dto;
        }

        // JWT Token Generation
        public string GenerateJwtToken(Domain.Models.AuthUser user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            var tokenSecret = _config["AuthSettings:Token"];
            if (string.IsNullOrEmpty(tokenSecret))
                throw new InvalidOperationException("Token secret is missing in configuration.");

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.FirstName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Sid, user.SystemUserId.ToString()),
            new Claim(ClaimTypes.Role, user.Role.ToString())
            
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSecret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
