using DoctorWhoDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DoctorWho.Db
{
    public class DoctorWhoCoreDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; } 
        public DbSet<Enemy> Enemies { get; set; }  
        public DbSet<Companion> Companions { get; set; }
        public DbSet<Episode> Episodes { get; set; }    
        public DbSet<Author> Authors { get; set; }
        public DbSet<EnemyEpisode> EnemyEpisodes { get; set; }

        public DbSet<CompanionEpisode> CompanionEpisodes { get; set; }

        public DbSet<ViewEpisodes> ViewEpisodes { get; set; }
        public string FnCompanionsResult(int EpisodeId) => throw new NotSupportedException();
        public string FnEnemiesResult(int EpisodeId) => throw new NotSupportedException();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = DoctorWhoCore")
                .LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name},LogLevel.Information)
                .EnableSensitiveDataLogging();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelManager = new ModelManager(modelBuilder);
            modelManager.SetShadowProperties();
            modelManager.SetupManytoManyRelationships();
            modelManager.SeedData();
            modelManager.MapViews();
            modelBuilder.HasDbFunction(typeof(DoctorWhoCoreDbContext).GetMethod(nameof(FnCompanionsResult), new[] { typeof(int) })).HasName("fnCompanions");
            modelBuilder.HasDbFunction(typeof(DoctorWhoCoreDbContext).GetMethod(nameof(FnEnemiesResult), new[] { typeof(int) })).HasName("fnEnemies");
        }
        
    }
}