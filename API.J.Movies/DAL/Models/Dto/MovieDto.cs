using System.ComponentModel.DataAnnotations;

namespace API.J.Movies.DAL.Models.Dto
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El número maximo de carecteres es de 100.")] 
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Required(ErrorMessage = "La duración es obligatoria.")]
        public string Duration { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "La clasificación es obligatoria.")]
        [MaxLength(10, ErrorMessage = "El número maximo de carecteres es de 10.")]
        public string Classification { get; set; }
    }
}
