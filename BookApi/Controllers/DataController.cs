using ArchiveBookModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using ViewModels;

namespace LibratyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        public readonly IDataService dataService;
        public DataController(IDataService dataService)
        {
            this.dataService = dataService;
        }
        [HttpPost]
        public Task ChekNewEntries()
        {
            List<BookModel> list = Archive.ArchiveList;
            return dataService.ReadAndSave(list);
        }
    }
}
