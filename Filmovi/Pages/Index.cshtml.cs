using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibraryFilmovi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Filmovi.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ClassLibraryFilmovi.DataAccess.FilmContext _context;
        public IndexModel(ClassLibraryFilmovi.DataAccess.FilmContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }
        public List<Film> Filmovi { get; set; }



        public async Task OnGetAsync()
        {
            Filmovi = await _context.Film.ToListAsync();
        }
    }
}
