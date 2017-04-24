using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IkeCode.Data
{
    public class IcUser : IdentityUser<int>
    {
        public string FullName { get; set; }
    }
}
