using System.ComponentModel.DataAnnotations;

namespace Survay.Models.DTO
{
    public class answerDTO
    {
        [Key]
        [Required]
        public int AnswerID { get; set; }
        public string? AnswerText { get; set; }
        public int ResponseID { get; set; }

        public int QuestionID { get; set; }

        public int? OptionID { get; set; }
    }
}
