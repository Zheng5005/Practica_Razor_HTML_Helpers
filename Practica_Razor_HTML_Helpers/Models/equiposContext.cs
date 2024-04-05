using Microsoft.EntityFrameworkCore;

namespace Practica_Razor_HTML_Helpers.Models
{
    public class equiposContext : DbContext
    {
        public equiposContext(DbContextOptions<equiposContext> options) : base(options)
        {

        }

        public DbSet<marcas> marcas { get; set; }
        public DbSet<equipos> equipos { get; set; }
        public DbSet<usuarios> usuarios { get; set; }
    }
}
