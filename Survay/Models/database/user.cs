using Microsoft.AspNetCore.Identity;
using WebApplication3.Models.WebApplication3.Models;

namespace Survay.Models.database
{
    public class User : IdentityUser
    {

        public ICollection<Servey> CreatedSurveys { get; set; }
        public ICollection<Response> Responses { get; set; }
    }
}
