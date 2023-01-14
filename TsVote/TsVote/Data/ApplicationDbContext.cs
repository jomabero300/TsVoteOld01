using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TsVote.Data.Entities.Gene;

namespace TsVote.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("Admi");

            builder.Entity<City>()
                .HasIndex("StateId", "Name")
                .IsUnique()
                .HasDatabaseName("IX_City_State_Name");

            builder.Entity<CommuneTownship>()
                .HasIndex("CityId", "ZoneId", "Name")
                .IsUnique()
                .HasDatabaseName("IX_CommuneTownship_City_Zone_Name");

            builder.Entity<Country>()
                .HasIndex(x=>x.Name)
                .IsUnique()
                .HasDatabaseName("IX_Country_Name");

            builder.Entity<Gender>()
                .HasIndex(x => x.Name)
                .IsUnique()
                .HasDatabaseName("IX_Gender_Name");

            builder.Entity<NeighborhoodSidewalk>()
                 .HasIndex("CommuneTownshipId", "Name")
                 .IsUnique()
                 .HasDatabaseName("IX_NeighborhoodSidewalk_CommuneTownship_Name");

            builder.Entity<State>()
                .HasIndex("CountryId", "Name")
                .IsUnique()
                .HasDatabaseName("IX_State_Country_Name");

            builder.Entity<Zone>()
                .HasIndex(x => x.Name)
                .IsUnique()
                .HasDatabaseName("IX_Zone_Name");

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<CommuneTownship> communeTownships { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<NeighborhoodSidewalk> neighborhoodSidewalks { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Zone> Zones { get; set; }
    }
}