namespace HireMeNowAD03.RequestObject.JobProvider
{
    public class SignupRequest
    {
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
