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
    public class GenreController : ControllerBase
    {
        public readonly IGenreService genreService;
        public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;
        }
        [HttpGet("AllGenres")]
        public List<Genres> GetGenres()
        {
            return genreService.GetGenres();
        }
        [HttpGet]
        public string GetGenre(int Id)
        {
            return JsonConvert.SerializeObject(genreService.GetGenre(Id));
        }
        [HttpPost]
        public bool Create(GenreModel model)
        {
            return genreService.Create(model);
        }
        [HttpPut]
        public bool Update(GenreModel model, int Id)
        {
            return genreService.Update(model, Id);
        }
        [HttpDelete]
        public bool Delete(int Id)
        {
            return genreService.Delete(Id);
        }
    }
}
