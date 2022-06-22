using Microsoft.EntityFrameworkCore;

namespace Летняя_Практика_ООП_2_Курс
{
    public class LibraryDB : DbContext
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
            modelBuilder.Entity<Book>(b =>
            {
                b.HasKey(x=>x.BookID);
                b.HasMany(x => x.KeyWords).WithMany(x => x.Books);
            });
            modelBuilder.Entity<KeyWord>(x =>
            {
                x.HasKey(z => z.Id);
                x.Property(z => z.Name).IsRequired();
                x.HasData(new KeyWord[]
                {
                    new KeyWord {Id = 1, Name="Выживание"},
                    new KeyWord {Id = 2, Name="Война"},
                    new KeyWord {Id = 3, Name="Монстры"},
                    new KeyWord {Id = 4, Name="Магия"},
                    new KeyWord {Id = 5, Name="Волшебство"},
                    new KeyWord {Id = 6, Name="Любовь"},
                    new KeyWord {Id = 7, Name="Героизм"},
                    new KeyWord {Id = 8, Name="Взросление"},
                    new KeyWord {Id = 9, Name="Приключения"},
                    new KeyWord {Id = 10, Name="Охота"},
                    new KeyWord {Id = 11, Name="Средневековье"},
                    new KeyWord {Id = 12, Name="Темные силы"},
                    new KeyWord {Id = 13, Name="Смерть"},
                    new KeyWord {Id = 14, Name="Миф"},
                    new KeyWord {Id = 15, Name="Пророчества"},
                    new KeyWord {Id = 16, Name="Месть"},
                    new KeyWord {Id = 17, Name="Интрига"},
                    new KeyWord {Id = 18, Name="Легенда"},
                    new KeyWord {Id = 19, Name="Власть"},
                    new KeyWord {Id = 20, Name="Города"},
                    new KeyWord {Id = 21, Name="Морское"},
                    new KeyWord {Id = 22, Name = "Наука"},
                    new KeyWord {Id = 23, Name = "Техника"},
                    new KeyWord {Id = 24, Name = "Исследования"},
                    new KeyWord {Id = 25, Name = "Медицина"},
                });
            });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<KeyWord> KeyWords { get; set; }
    }
}
