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
    public class AuthorService : IAuthorService
    {
        public readonly DataContext DataContext;
        public AuthorService(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public Authors Create(AuthorModel model)
        {
            Authors author = new Authors()
            {
                Name = model.Name,
            };
            DataContext.Autors.Add(author);
            DataContext.SaveChanges();
            return author;
        }

        public bool Delete(int Id)
        {
            Authors? author = DataContext.Autors.Find(Id);
            if (author == null)
            {
                return false;
            }
            DataContext.Autors.Remove(author);
            DataContext.SaveChanges();
            return true;
        }

        public AuthorModel GetAuthor(int Id)
        {
            Authors? author = DataContext.Autors.Find(Id);
            AuthorModel model = new AuthorModel();
            if (author == null)
            {
                return model;
            }
            model.Name = author.Name;
            return model;
        }
        public Authors Update(AuthorModel model, int Id)
        {
            Authors? author = DataContext.Autors.Find(Id);
            if (author == null)
            {
                author = new Authors();
                return author;
            }
            author.Name = model.Name;
            DataContext.SaveChanges();
            return author;
        }
    }
}
