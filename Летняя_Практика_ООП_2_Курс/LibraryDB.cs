using Microsoft.EntityFrameworkCore;

namespace Летняя_Практика_ООП_2_Курс
{
    class LibraryDB : DbContext
    {
        public LibraryDB()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = LibraryDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reader>(r =>
            {
                r.HasKey(x => x.ReaderID);
                r.HasAlternateKey(x => x.Name);
                r.HasMany(x => x.onHandsBooks).WithOne(x => x.CurrentReader).HasForeignKey(x => x.CurrentReaderId).IsRequired(false);
                r.HasMany(x => x.familiarizedBooks).WithMany(x => x.PreviousReaders).UsingEntity(x => x.ToTable("PreviousReaderBook"));
            });


            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
    }
}
