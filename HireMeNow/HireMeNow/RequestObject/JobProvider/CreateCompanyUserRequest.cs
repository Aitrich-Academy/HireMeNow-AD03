using Domain.Enums;
using Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HireMeNowAD03.RequestObject.JobProvider
{
    public class CreateCompanyUserRequest
    {

        [StringLength(100)]
        public string FirstName { get; set; } = null!;

        [StringLength(100)]
        public string? LastName { get; set; }

        [StringLength(50)]
        public string? CompanyUserRole { get; set; }

        [StringLength(200)]
        public string? CompanyName { get; set; }

        [StringLength(200)]
        public string Email { get; set; } = null!;

        [StringLength(20)]
        public string? Phone { get; set; }


        public Guid JobProviderId { get; set; }
        public Guid SystemUserId { get; set; }



    }
}
