using System.ComponentModel.DataAnnotations;

namespace Survay.Models.DTO
{
    public class servayQDTO
    {
        [Key]
        [Required]
        public int SurveyID { get; set; }
        public string Userid { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<QuestionDTO> questions { get; set; }
    }
}
