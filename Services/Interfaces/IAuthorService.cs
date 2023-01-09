using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Services.Interfaces
{
    public interface IAuthorService
    {
        public List<Authors> GetAuthors();
        public AuthorModel GetAuthor(int Id);
        public bool Create(AuthorModel model);
        public bool Update(AuthorModel model, int Id);
        public bool Delete(int Id);
    }
}
