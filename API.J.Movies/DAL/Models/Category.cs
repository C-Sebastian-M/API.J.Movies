using System.ComponentModel.DataAnnotations;

namespace API.J.Movies.DAL.Models
{
    public class Category : AuditBase
    {
        [Required] // Ensures that the Name property must have a value
        [Display(Name = "Nombre de la categoria")] // Me sirve para poner un nombre amigable en las validaciones
        public string Name { get; set; }
    }
}
