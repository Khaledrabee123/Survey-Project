using System.ComponentModel.DataAnnotations;

namespace Survay.Models.DTO
{
    public class QuestionDTO
    {
        [Key]
        [Required]
        
        public int QuestionID { get; set; }
        public int QuestionNumber { get; set; }
        public string? QuestionText { get; set; }
        public string? QuestionType { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<ChoiceDTO> choseDTOs { get; set; } = new List<ChoiceDTO>(); // ✅ Ensure it's initialized
    }
}
