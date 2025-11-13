using API.J.Movies.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace API.J.Movies.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        //Seccion para crear el dbset de las entidades o modelos
        public DbSet<Category> Categories { get; set; }
    }
}
