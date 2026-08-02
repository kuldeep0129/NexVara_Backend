using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nexvara_ERP.Domain.Entity;
using Nexvara_ERP.Domain.Identiy;

namespace Nexvara_ERP.Domain.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<LeadSources> LeadSources { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

       
    }
}