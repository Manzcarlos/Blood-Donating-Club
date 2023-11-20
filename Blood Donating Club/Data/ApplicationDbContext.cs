using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Blood_Donating_Club.Models;

namespace Blood_Donating_Club.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Blood_Donating_Club.Models.BloodType>? BloodType { get; set; }
        public DbSet<Blood_Donating_Club.Models.Country>? Country { get; set; }
        public DbSet<Blood_Donating_Club.Models.State>? State { get; set; }
        public DbSet<Blood_Donating_Club.Models.City>? City { get; set; }
        public DbSet<Blood_Donating_Club.Models.DonatingCenter>? DonatingCenter { get; set; }
        public DbSet<Blood_Donating_Club.Models.Donor>? Donor { get; set; }
        public DbSet<Blood_Donating_Club.Models.CampaignStatus>? CampaignStatus { get; set; }
    }
}