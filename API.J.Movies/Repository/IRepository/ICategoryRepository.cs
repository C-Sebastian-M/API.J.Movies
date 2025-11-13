using API.J.Movies.DAL.Models;

namespace API.J.Movies.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetCategoriesAsync(); //Me retorna una lista de categorias
        Task<Category> GetCategoryByIdAsync(int id); //Me retorna Una categoria por ID
        Task<bool> CategoryExistsByIdAsync(int id); //Me dice si existe una categoria por ID
        Task<bool> CategoryExistsByNameAsync(string name); //Me dice si existe una categoria por Nombre
        Task<bool> CreateCategoryAsync(Category category); //Crea una categoria
        Task<bool> UpdateCategoryAsync(Category category); // Actualiza una categoria --nombre y fecha
        Task<bool> DeleteCategoryAsync(int id); //Me elimina una categoria
    }
}
