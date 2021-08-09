using Microsoft.AspNetCore.Identity;

namespace DAL
{
    public class Role : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}
