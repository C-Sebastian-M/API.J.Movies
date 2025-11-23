using System.ComponentModel.DataAnnotations;

namespace API.J.Movies.DAL.Models
{
    public class Movie : AuditBase
    {
        [Required]
        [Display(Name = "Título de la película")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Duración en minutos")]
        public int Duration { get; set; } 
        public string? Description { get; set; }
        [Required]
        public string Classification { get; set; }
    }
}
