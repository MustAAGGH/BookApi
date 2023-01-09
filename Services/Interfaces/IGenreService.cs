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
        public List<Genres> GetGenres();
        public GenreModel GetGenre(int Id);
        public bool Create(GenreModel model);
        public bool Update(GenreModel model, int Id);
        public bool Delete(int Id);
    }
}
