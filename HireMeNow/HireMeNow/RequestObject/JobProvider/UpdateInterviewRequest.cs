using Domain.Enums;

namespace HireMeNowAD03.RequestObject.JobProvider
{
    public class UpdateInterviewRequest
    {
       // public Guid InterviewId { get; set; }
        public DateTime InterviewDate { get; set; }
        public string InterviewTime { get; set; } = null!;
        public InterviewMode InterviewMode { get; set; }
        public InterviewStatus InterviewStatus { get; set; }
    }
}
