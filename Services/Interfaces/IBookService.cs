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
        public BookModel GetBook(int Id);
        public Books Create(BookModel model);
        public Books Update(BookModel model, int Id);
        public bool Delete(int Id);
    }
}
