using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IkeCode.Data
{
    public class IcDbContext<TUser> : IdentityDbContext<TUser, IdentityRole<int>, int>
        where TUser : IdentityUser<int>
    {
        public IcDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //TODO: reflection pra pegar os IcModel e configurar automatico
            //builder.Entity<IcModel>().ConfigureIcModel((_) => { });
        }
    }
}
