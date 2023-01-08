using Data;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Services
{
    public class DataService : IDataService
    {
        public readonly DataContext DataContext;
        public DataService(DataContext dataContext)
        {
            DataContext = dataContext;
        }
        public async Task ReadAndSave(List<BookModel> list)
        {
            foreach (BookModel bookModel in list)
            {
                if (!DataContext.Genres.Select(g => g.Name).Contains(bookModel.Genre))
                {
                    Genres dataGenre = new Genres()
                    {
                        Name = bookModel.Genre
                    };
                    await DataContext.Genres.AddAsync(dataGenre);
                    await DataContext.SaveChangesAsync();
                }
                if (!DataContext.Autors.Select(a => a.Name).Contains(bookModel.Author))
                {
                    Authors dataAuthor = new Authors()
                    {
                        Name = bookModel.Author
                    };
                    await DataContext.Autors.AddAsync(dataAuthor);
                    await DataContext.SaveChangesAsync();
                }
                if (!DataContext.Books.Select(b => b.Title).Contains(bookModel.Title))
                {
                    Books dataBook = new Books()
                    {
                        Title = bookModel.Title,
                        PublishingYear = bookModel.PublishingYear
                    };
                    Authors? author = DataContext.Autors.Where(a => a.Name == bookModel.Author).FirstOrDefault();
                    Genres? genre = DataContext.Genres.Where(g => g.Name == bookModel.Genre).FirstOrDefault();
                    if (author != null)
                    {
                        dataBook.AuthorId = author.Id;
                    }
                    if (genre != null)
                    {
                        dataBook.GenreId = genre.Id;
                    }
                    await DataContext.Books.AddAsync(dataBook);
                    await DataContext.SaveChangesAsync();
                }
            }
        }
    }
}
