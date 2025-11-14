using System.ComponentModel.DataAnnotations;

namespace API.J.Movies.DAL.Models.Dto
{
    public class CategoryCreateDto
    {
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El número maximo de carecteres es de 100.")]
        public string Name { get; set; }
    }
}
