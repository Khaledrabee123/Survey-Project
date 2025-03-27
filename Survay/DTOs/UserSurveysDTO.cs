namespace Survay.DTOs
{
    public class UserSurveysDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int ResponsesCount { get; set; }
        public int TotalResponses { get; set; }
        public string Status { get; set; }
    }
}
