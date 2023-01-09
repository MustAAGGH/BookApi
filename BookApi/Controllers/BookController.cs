using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Interfaces;
using ViewModels;

namespace LibratyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public readonly IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        [HttpGet("AllBooks")]
        public List<Books> GetBooks()
        {
            return bookService.GetBooks();
        }
        [HttpGet]
        public string GetBook(int Id)
        {
            return JsonConvert.SerializeObject(bookService.GetBook(Id));
        }
        [HttpPost]
        public bool Create(BookModel model)
        {
            return bookService.Create(model);
        }
        [HttpPut]
        public bool Update(BookModel model, int Id)
        {
            return bookService.Update(model, Id);
        }
        [HttpDelete]
        public bool Delete(int Id)
        {
            return bookService.Delete(Id);
        }

    }
}
