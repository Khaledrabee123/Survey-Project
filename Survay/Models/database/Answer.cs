using System.ComponentModel.DataAnnotations;

namespace Survay.Models.database
{
    public class Answer
    {
        [Required]
        [Key]
        public int AnswerID { get; set; }
        public string? AnswerText { get; set; }

        public int ResponseID { get; set; }
        [Required]
        public Response Response { get; set; }

        public int QuestionID { get; set; }
        [Required]
        public Question Question { get; set; }

        public int? OptionID { get; set; }
        public Choice? Option { get; set; }
    }
}

