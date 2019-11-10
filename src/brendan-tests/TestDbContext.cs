using Microsoft.EntityFrameworkCore;

namespace brendan_tests
{
    public class TestDbContext: DbContext
    {
        public TestDbContext() : base()
        {
        }

        public DbSet<TestEntity> TestEntities { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Server=localhost;database=jsontest;Username=northwind;password=northwind",
                opt => opt.UseNodaTime());
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestEntity>().Property(t => t.Data).HasColumnType("jsonb");
            base.OnModelCreating(modelBuilder);
        }
    }
}
