using Microsoft.AspNetCore.Identity;

namespace TaskAuthApi.Models
{
    public class AppUser : IdentityUser
    {
        public ICollection<TaskItem>? Tasks { get; set; }
    }
}
