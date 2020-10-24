using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ClassLibraryFilmovi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Filmovi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmoviController : ControllerBase
    {
        private readonly ILogger<FilmoviController> _logger;
        private readonly ClassLibraryFilmovi.DataAccess.FilmContext context;
        public FilmoviController(ILogger<FilmoviController> logger, ClassLibraryFilmovi.DataAccess.FilmContext _context)
        {
            _logger = logger;
            context = _context;
        }

        public List<Film> filmovi{get; set;}

        [HttpGet]
        public string Get()
        {
            filmovi = context.Film.ToList();
            var json = JsonSerializer.Serialize<List<Film>>(filmovi);
            return json;
        }
    
    }

}
