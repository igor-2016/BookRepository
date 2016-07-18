namespace BookRepository.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookRepsitoryFromLocalDb : DbContext, IBookRepositoryDb
    {
        public BookRepsitoryFromLocalDb()
            : base("name=BookRepsitoryFromLocalDb")
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Genre)
                .WillCascadeOnDelete(false);
        }


        public void UpdateBook(Book book)
        {
            Entry(book).State = EntityState.Modified;
        }

        public void UpdateGenre(Genre genre)
        {
            Entry(genre).State = EntityState.Modified;
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
