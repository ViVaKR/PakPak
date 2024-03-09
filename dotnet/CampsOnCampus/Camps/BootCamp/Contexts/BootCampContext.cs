using BootCamp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BootCamp.Contexts
{
    public class BootCampContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<AsciiCode> AsciiCodes { get; set; }

        public BootCampContext() { }

        public BootCampContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("BootCampConnection"));
            
            /*
             * [ 데이터베이스 공급자 ]
             * .SQL Server      - .UseSqlServer(connectionString)
             * .SQLite          - .UseSqlite(connectionString)
             * .Memory          - .UseInMemoryDatabase(databaseName)
             * .PostgresSQL     - .UseNgpsql(connectionString)
             * .MySQL/MariaDB   - .UseMySql(connectionString)
             * .Oracle          - .UseOracle(connectionString)
             */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasOne<Grade>(x => x.Grade)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.GradeId);
        }
    }
}