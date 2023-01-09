using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Services.Interfaces
{
    public interface IBookService
    {
        public List<Books> GetBooks();
        public BookModel GetBook(int Id);
        public bool Create(BookModel model);
        public bool Update(BookModel model, int Id);
        public bool Delete(int Id);
    }
}
