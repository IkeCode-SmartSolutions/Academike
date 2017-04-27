using IkeCode.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academike.Data
{
    public class AcademikeContext : IcDbContext<AcademikeUser>
    {
        public AcademikeContext(DbContextOptions<AcademikeContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //builder.Entity<IcModel>().ConfigureIcModel((_) => { });
        }
    }
}
