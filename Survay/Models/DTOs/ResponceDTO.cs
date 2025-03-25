using System.ComponentModel.DataAnnotations;
using WebApplication3.Models.WebApplication3.Models;

namespace Survay.Models.DTO
{
    public class ResponceDTO
    {
        [Key]
        [Required]
        public int ResponseID { get; set; }
        public DateTime SubmittedAt { get; set; }

        public int SurveyID { get; set; }

        public string? UserID { get; set; }

        public ICollection<answerDTO> Answers { get; set; } = new List<answerDTO>();
    }
}
