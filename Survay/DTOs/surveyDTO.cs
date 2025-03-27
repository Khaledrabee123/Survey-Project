using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Survay.DTOs
{
    public class surveyDTO
    {
        [Key]
        [Required]
        public int SurveyID { get; set; }
        public string? UserID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<QuestionDTO>? Questions { get; set; }
        [NotMapped]
        public List<ResponseDTO>? Responses { get; set; }
    }
}
