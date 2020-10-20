using ClassLibraryFilmovi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryFilmovi.DataAccess
{
    public class FilmContext : DbContext
    {
        public FilmContext(DbContextOptions options) : base(options) {}
        public DbSet<Film> Film { get; set; }
    }
}
