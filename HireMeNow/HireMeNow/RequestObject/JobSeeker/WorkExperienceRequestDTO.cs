namespace HireMeNowAD03.RequestObject.JobSeeker
{
    public class WorkExperienceRequestDTO
    {
        public string JobTitle { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public DateTime ServiceStart { get; set; }
        public DateTime ServiceEnd { get; set; }

    }
}
