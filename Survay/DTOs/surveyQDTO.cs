namespace Survay.DTOs
{
    public class surveyQDTO
    {

        public string Userid { get; set; } = string.Empty;
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<QuestionDTO> Questions { get; set; } = new List<QuestionDTO>();

    }
}
