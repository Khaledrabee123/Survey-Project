using System.ComponentModel.DataAnnotations;
using WebApplication3.Models.WebApplication3.Models;

namespace Survay.Models.database
{
    public class Question
    {
        [Key]
        [Required]
        public int QuestionID { get; set; }
        public int QuestionNumber { get; set; }
        public string? QuestionText { get; set; }
        public string? QuestionType { get; set; }
        public DateTime CreatedAt { get; set; }

        public int? SurveyID { get; set; }
        public Survey? Survey { get; set; }

        public ICollection<Choice>? Choices { get; set; }
    }
}
