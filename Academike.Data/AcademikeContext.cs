using Academike.Model;
using IkeCode.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Academike.Data
{
    public class AcademikeContext : IcDbContext<AcademikeUser>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Note> Notes { get; set; }

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
