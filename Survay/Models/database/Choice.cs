using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.SqlServer.Server;
namespace Survay.Models.database
{
    public class Choice
    {
        [Key]
        public int OptionID { get; set; }

        public string? OptionText { get; set; }

        public int QuestionID { get; set; }
        [Required]
        public Question Question { get; set; }
    }
}






public class ChoiceDTO
{
    public int Id { get; set; }
    public string Text { get; set; }
}




