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
    public class EditModel : PageModel
    {
        private readonly ClassLibraryFilmovi.DataAccess.FilmContext _context;
        public EditModel(ClassLibraryFilmovi.DataAccess.FilmContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Film film { get; set; }
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(film).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!filmExists(film.Id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            return RedirectToPage("/Index");
        }

        private bool filmExists(int id)
        {
            throw new NotImplementedException();
        }
    }

}
