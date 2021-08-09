using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DAL
{
    public class DatabaseContext:IdentityDbContext<User,Role,int> //DbContext
    {
        public DatabaseContext()
        {

        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<Country> Country { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=DESKTOP-LLEDI1J\\MSSQLSERVER2019; initial catalog=ContactMgnt;persist security info=True;user id=sa;password=Subhra123;");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
