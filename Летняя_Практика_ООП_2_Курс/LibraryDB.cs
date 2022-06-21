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
            });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
    }
}
