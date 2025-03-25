using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Survay.Models.DTO
{
    public class serveyDTO
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
        public List<ResponceDTO>? Responses { get; set; }
    }
}
