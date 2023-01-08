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
        public Books Create(BookModel model)
        {
            Authors? author = DataContext.Autors.Where(a => a.Name == model.Author).FirstOrDefault();
            Genres? genre = DataContext.Genres.Where(g => g.Name == model.Genre).FirstOrDefault();
            if(author == null)
            {
                Authors newA = new Authors()
                {
                    Name = model.Author
                };
                DataContext.Autors.Add(newA);
                DataContext.SaveChanges();
            }
            if (genre == null)
            {
                Genres newG = new Genres()
                {
                    Name = model.Genre
                };
                DataContext.Genres.Add(newG);
                DataContext.SaveChanges();
            }

            author = DataContext.Autors.Where(a => a.Name == model.Author).FirstOrDefault();
            genre = DataContext.Genres.Where(g => g.Name == model.Genre).FirstOrDefault();


            Books book = new Books()
            {
                Title = model.Title,
                PublishingYear = model.PublishingYear,
                AuthorId = author.Id,
                GenreId = genre.Id
            };

            DataContext.Books.Add(book);
            DataContext.SaveChanges();

            Books result = DataContext.Books.Where(b => b.Title == model.Title).FirstOrDefault();
            return result;
        }

        public bool Delete(int Id)
        {
            Books? book = DataContext.Books.Find(Id);
            if(book == null)
            {
                return false;
            }
            DataContext.Books.Remove(book);
            DataContext.SaveChanges();
            return true;
        }

        public BookModel GetBook(int Id)
        {
            Books? book = DataContext.Books.Find(Id);
            BookModel model = new BookModel();
            if( book == null)
            {
                return model;
            }
            Authors? author = DataContext.Autors.Where(a => a.Id == book.AuthorId).FirstOrDefault();
            Genres? genre = DataContext.Genres.Where(g => g.Id == book.GenreId).FirstOrDefault();
            model.Title = book.Title;
            model.PublishingYear = book.PublishingYear;
            if(author != null)
            {
                model.Author = author.Name;
            }
            if(genre != null)
            {
                model.Genre = genre.Name;
            }
            return model;
        }

        public Books Update(BookModel model, int Id)
        {
            Books? book = DataContext.Books.Find(Id);
            if (book == null)
            {
                book = new Books();
                return book;
            }
            Authors? author = DataContext.Autors.Where(a => a.Name == model.Author).FirstOrDefault();
            Genres? genre = DataContext.Genres.Where(g => g.Name == model.Genre).FirstOrDefault();
            book.Title = model.Title;
            book.PublishingYear = model.PublishingYear;
            if(author != null)
            {
                book.AuthorId = author.Id;
            }
            if(genre != null)
            {
                book.GenreId = genre.Id;
            }
            DataContext.SaveChanges();
            return book;
        }
    }
}