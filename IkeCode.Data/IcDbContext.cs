using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkeCode.Data
{
    public class IcDbContext : IdentityDbContext<IcUser, IdentityRole<int>, int>
    {
        public IcDbContext(DbContextOptions<IcDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //TODO: reflection pra pegar os IcModel e configurar automatico
            builder.Entity<IcModel>().ConfigureIcModel((_) => { });
        }
    }
}
