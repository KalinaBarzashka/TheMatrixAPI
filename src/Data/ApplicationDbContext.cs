using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheMatrixAPI.Models.DbModels;

namespace TheMatrixAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<RequestFromIP> RequestsFromIP { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Actor>().Ignore(x => x.FullName);

            builder.Entity<Actor>()
                .HasOne(c => c.Character)
                .WithOne(a => a.Actor)
                .HasForeignKey<Character>(x => x.ActorId);
        }
    }
}
