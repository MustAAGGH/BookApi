using Data;
using Services.Interfaces;
using ViewModels;

namespace Services
{
    public class BookService : IBookService
    {
        public readonly DataContext DataContext;
        public BookService(DataContext dataContext)
        {
            DataContext = dataContext;
        }
        public bool Create(BookModel model)
        {
            Authors? author = DataContext.Autors.Where(a => a.Name == model.Author).FirstOrDefault();
            Genres? genre = DataContext.Genres.Where(g => g.Name == model.Genre).FirstOrDefault();
            if (author == null)
            {
                return false;
            }
            if (genre == null)
            {
                return false;
            }

            Books book = new Books()
            {
                Title = model.Title,
                PublishingYear = model.PublishingYear,
                AuthorId = author.Id,
                GenreId = genre.Id
            };

            DataContext.Books.Add(book);
            DataContext.SaveChanges();
            return true;
        }

        public bool Delete(int Id)
        {
            Books? book = DataContext.Books.Find(Id);
            if (book == null)
            {
                return false;
            }
            DataContext.Books.Remove(book);
            DataContext.SaveChanges();
            return true;
        }
        public List<Books> GetBooks()
        {
            return DataContext.Books.ToList();
        }
        public BookModel GetBook(int Id)
        {
            Books? book = DataContext.Books.Find(Id);
            BookModel model = new BookModel();
            if (book == null)
            {
                return model;
            }
            Authors? author = DataContext.Autors.Where(a => a.Id == book.AuthorId).FirstOrDefault();
            Genres? genre = DataContext.Genres.Where(g => g.Id == book.GenreId).FirstOrDefault();
            model.Title = book.Title;
            model.PublishingYear = book.PublishingYear;
            if (author != null)
            {
                model.Author = author.Name;
            }
            if (genre != null)
            {
                model.Genre = genre.Name;
            }
            return model;
        }

        public bool Update(BookModel model, int Id)
        {
            Books? book = DataContext.Books.Find(Id);
            if (book == null)
            {
                book = new Books();
                return false;
            }

            Authors? author = DataContext.Autors.Where(a => a.Name == model.Author).FirstOrDefault();
            Genres? genre = DataContext.Genres.Where(g => g.Name == model.Genre).FirstOrDefault();
            if (author == null)
            {
                return false;
            }
            if (genre == null)
            {
                return false;
            }

            book.Title = model.Title;
            book.PublishingYear = model.PublishingYear;
            book.AuthorId = author.Id;
            book.GenreId = genre.Id;
            DataContext.SaveChanges();
            return true;
        }
    }
}