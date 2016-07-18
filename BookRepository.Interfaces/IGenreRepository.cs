using BookRepository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRepository.Interfaces
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> SelectAll();
        Genre SelectById(int id);
        void Insert(Genre genre);
        void Update(Genre genre);
        void Delete(int id);
        void Save();
        int BooksUsage(int genreId);
        int TotalGenres();
    }
}
