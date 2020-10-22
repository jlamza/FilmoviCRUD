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
    public class DeleteModel : PageModel
    {
        private readonly ClassLibraryFilmovi.DataAccess.FilmContext _context;
        public DeleteModel(ClassLibraryFilmovi.DataAccess.FilmContext context){
        _context = context;
        }

        [BindProperty]
        public Film film{ get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            film = await _context.Film.FirstOrDefaultAsync(m => m.Id == id);
            
            if(film == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            film = await _context.Film.FindAsync(id);
            _context.Film.Remove(film);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
