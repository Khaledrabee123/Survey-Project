using System.ComponentModel.DataAnnotations;
using WebApplication3.Models.WebApplication3.Models;

namespace Survay.Models.database
{
    public class Response
    {
        [Required]
        [Key]
        public int ResponseID { get; set; }
        public DateTime SubmittedAt { get; set; }

        public int SurveyID { get; set; }
        public Servay Survey { get; set; }

        public string UserID { get; set; }
        [Required]
        public User User { get; set; }

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }
}
