using BookRepository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRepository.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> SelectAll();
        Book SelectById(int id);
        void Insert(Book book);
        void Update(Book book);
        void Delete(int id);
        IEnumerable<Genre> GenreList();
        void Save();
        int TotalBooks();
    }
}
