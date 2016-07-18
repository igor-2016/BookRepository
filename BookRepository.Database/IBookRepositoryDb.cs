using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRepository.Database
{
    public interface IBookRepositoryDb
    {
        System.Data.Entity.DbSet<Book> Books { get; set; }
        System.Data.Entity.DbSet<Genre> Genres { get; set; }
        void UpdateBook(Book book);
        void UpdateGenre(Genre genre);
        int SaveChanges();
    }
}
