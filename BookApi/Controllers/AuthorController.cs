using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Interfaces;
using ViewModels;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService authorService;
        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }
        [HttpGet("AllAuthors")]
        public List<Authors> GetAuthors()
        {
            return authorService.GetAuthors();
        }
        [HttpGet]
        public string GetAuthor(int Id)
        {
            return JsonConvert.SerializeObject(authorService.GetAuthor(Id));
        }
        [HttpPost]
        public bool Create(AuthorModel model)
        {
            return authorService.Create(model);
        }
        [HttpPut]
        public bool Update(AuthorModel model, int Id)
        {
           return authorService.Update(model , Id);
        }
        [HttpDelete]
        public bool Delete(int Id)
        {
            return authorService.Delete(Id);
        }
    }
}
