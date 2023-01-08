using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Services.Interfaces
{
    public interface IDataService
    {
        public Task ReadAndSave(List<BookModel> list);
    }
}
