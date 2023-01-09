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
    public class GenreService : IGenreService
    {
        public readonly DataContext DataContext;
        public GenreService(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public bool Create(GenreModel model)
        {
            Genres genre = new Genres()
            {
                Name = model.Name,
            };
            DataContext.Genres.Add(genre);
            DataContext.SaveChanges();
            return true;
        }

        public bool Delete(int Id)
        {
            Genres? genre = DataContext.Genres.Find(Id);
            if (genre == null)
            {
                return false;
            }
            DataContext.Genres.Remove(genre);
            DataContext.SaveChanges();
            return true;
        }
        public List<Genres> GetGenres()
        {
            return DataContext.Genres.ToList();
        }
        public GenreModel GetGenre(int Id)
        {
            Genres? genre = DataContext.Genres.Find(Id);
            GenreModel model = new GenreModel();
            if (genre == null)
            {
                return model;
            }
            model.Name = genre.Name;
            return model;
        }

        public bool Update(GenreModel model, int Id)
        {
            Genres? genre = DataContext.Genres.Find(Id);
            if (genre == null)
            {
                return false;
            }
            genre.Name = model.Name;
            DataContext.SaveChanges();
            return true;
        }
    }
}
