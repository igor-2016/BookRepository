using BookRepository.Database;
using BookRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRepository.Entities
{
    public class GenreRepository : IGenreRepository
    {

        IBookRepositoryDb RepositoryContext;

        public GenreRepository(IBookRepositoryDb db)
        {
            RepositoryContext = db;
        }
        public IEnumerable<Genre> SelectAll()
        {
            return RepositoryContext.Genres;
        }

        public Genre SelectById(int id)
        {
            return RepositoryContext.Genres.Find(id);
        }

        public void Insert(Genre genre)
        {
            RepositoryContext.Genres.Add(genre);
        }
        public void Delete(int id)
        {
            var value = RepositoryContext.Genres.Where(i => i.Id == id).FirstOrDefault();
            if (value != null && BooksUsage(id) == 0)
            {
                RepositoryContext.Genres.Remove(value);
            }
        }
        public void Save()
        {
            RepositoryContext.SaveChanges();
        }

        public void Update(Genre genre)
        {
            RepositoryContext.UpdateGenre(genre);
        }

        public int BooksUsage(int genreId)
        {
            return RepositoryContext.Books.Where(x => x.GenreId == genreId).Count();
        }

        public int TotalGenres()
        {
            return RepositoryContext.Genres.Count();
        }

    }
}
