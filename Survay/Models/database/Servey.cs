using System.ComponentModel.DataAnnotations;
using Survay.Models.database;

namespace WebApplication3.Models
{
    namespace WebApplication3.Models
    {
        public class Servey
		{
			[Required]	
			[Key]
			public int SurveyID { get; set; }
			public string? Title { get; set; }
			public string? Description { get; set; }
			public bool IsActive { get; set; } 
			public DateTime CreatedAt { get; set; }

			public string UserID { get; set; }
			public User Creator { get; set; } 

			public ICollection<Question> Questions { get; set; } = new List<Question>();
			public ICollection<Response> Responses { get; set; } = new List<Response>();

			
		}
	}

}
