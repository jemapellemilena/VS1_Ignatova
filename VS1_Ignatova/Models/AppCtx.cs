using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VS1_Ignatova.Models;

namespace VS1_Ignatova.Models
{
    public class AppCtx : IdentityDbContext<User>
    {
        public AppCtx(DbContextOptions<AppCtx> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<VS1_Ignatova.Models.Category> Category { get; set; } = default!;
        public DbSet<VS1_Ignatova.Models.Developer> Developer { get; set; } = default!;
        public DbSet<VS1_Ignatova.Models.Game> Game { get; set; } = default!;
        public DbSet<VS1_Ignatova.Models.Role> Role { get; set; } = default!;
        public DbSet<VS1_Ignatova.Models.Story> Story { get; set; } = default!;

        /*public DbSet<FormOfStudy> FormsOfStudy { get; set; }
        public DbSet<Specialty> Specialties { get; set; }

        public DbSet<Group> Groups { get; set; }*/
    }
}
