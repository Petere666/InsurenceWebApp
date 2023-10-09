using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using InsurenceWebApp.Models;

namespace InsurenceWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<InsurenceWebApp.Models.Users>? Users { get; set; }
        public DbSet<InsurenceWebApp.Models.Insurances>? Insurances { get; set; }
        public DbSet<InsurenceWebApp.Models.InsurancesEvents>? InsurancesEvents { get; set; }
    }
}