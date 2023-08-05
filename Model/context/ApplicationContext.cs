using ASPPractice.Model.models;
using Microsoft.EntityFrameworkCore;

namespace ASPPractice.Model.context;


public sealed class ApplicationContext : DbContext
{
    public DbSet<Animal> Animals => Set<Animal>();
    public DbSet<Cell> Cells => Set<Cell>();
    public DbSet<Meal> Meals => Set<Meal>();
    public DbSet<Zookeeper> Zookeepers => Set<Zookeeper>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("User Id=postgres;Password=b1cJBQZ0e6BjaI06;Server=db.njuuzelhimoeiztijwvd.supabase.co;Port=5432;Database=postgres");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        #region Animals

        modelBuilder.Entity<Animal>(ea =>
        {
            ea.Property(b => b.AnimalName).IsRequired();
            ea.HasKey(b => b.Id);

            ea.HasOne(a => a.Cell)
                .WithMany(c => c.Animals)
                .HasForeignKey(a => a.CellId);

            ea.HasOne(a => a.MainMeal)
                .WithMany(m => m.Animals)
                .HasForeignKey(a => a.MainMealId);

            ea.HasMany(a => a.Zookeepers).WithMany(z => z.Animals);
        });


        #endregion

        modelBuilder.Entity<Zookeeper>(ez =>
        {
            ez.Property(z => z.FirstName).IsRequired();
            ez.HasKey(z => z.Id);
        });

        modelBuilder.Entity<Cell>().Property(c => c.Name).IsRequired();

        modelBuilder.Entity<Meal>().Property(c => c.Name).IsRequired();

        base.OnModelCreating(modelBuilder);

    }
}