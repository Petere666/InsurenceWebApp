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
        public DbSet<InsurenceWebApp.Models.MyUser>? MyUser { get; set; }
        public DbSet<InsurenceWebApp.Models.Insurance>? Insurance { get; set; }
        public DbSet<InsurenceWebApp.Models.InsurancesEvents>? InsurancesEvents { get; set; }
    }
}