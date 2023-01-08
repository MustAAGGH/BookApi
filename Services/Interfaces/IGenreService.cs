using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Services.Interfaces
{
    public interface IGenreService
    {
        public GenreModel GetGenre(int Id);
        public Genres Create(GenreModel model);
        public Genres Update(GenreModel model, int Id);
        public bool Delete(int Id);
    }
}
