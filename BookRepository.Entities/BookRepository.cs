using BookRepository.Database;
using BookRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRepository.Entities
{
    public class BookRepository : IBookRepository
    {

        IBookRepositoryDb RepositoryContext;

        public BookRepository(IBookRepositoryDb db)
        {
            RepositoryContext = db;
        }
        public IEnumerable<Book> SelectAll()
        {
            return RepositoryContext.Books;
        }

        public Book SelectById(int id)
        {
            return RepositoryContext.Books.Find(id);
        }

        public void Insert(Book obj)
        {
            RepositoryContext.Books.Add(obj);
        }
        public void Delete(int id)
        {
            var value = RepositoryContext.Books.Where(i => i.Id == id).FirstOrDefault();
            RepositoryContext.Books.Remove(value);
        }
        public void Save()
        {
            RepositoryContext.SaveChanges();
        }

        public void Update(Book book)
        {
            RepositoryContext.UpdateBook(book);
        }

        public IEnumerable<Genre> GenreList()
        {
            return RepositoryContext.Genres;
        }

        public int TotalBooks()
        {
            return RepositoryContext.Books.Count();
        }
    }
}
