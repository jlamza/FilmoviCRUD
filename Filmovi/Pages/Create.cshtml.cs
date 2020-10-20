using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibraryFilmovi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace Filmovi.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ClassLibraryFilmovi.DataAccess.FilmContext _context;
        public CreateModel(ClassLibraryFilmovi.DataAccess.FilmContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Film film { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Film.Add(film);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
