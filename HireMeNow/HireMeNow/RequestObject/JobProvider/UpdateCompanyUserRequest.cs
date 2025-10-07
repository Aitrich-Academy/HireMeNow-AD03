using System.ComponentModel.DataAnnotations;

namespace HireMeNowAD03.RequestObject.JobProvider
{
    public class UpdateCompanyUserRequest
    {
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }

        public string? CompanyUserRole { get; set; }
        public string? CompanyName { get; set; }

        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
    }
}
