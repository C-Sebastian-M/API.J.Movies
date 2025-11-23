using API.J.Movies.DAL.Models;

namespace API.J.Movies.Repository.IRepository
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>> GetMoviesAsync(); //Me retorna UNA LISTA DE PELICULAS
        Task<Movie> GetMovieAsync(int id); //Me retorna UNA PELICULA POR ID
        Task<bool> CreateMovieAsync(Movie movie); //Me crea una pelicula
        Task<bool> MovieExistsByNameAsync(string name); //Me dice si existe una pelicula por Nombre
        Task<bool> UpdateMovieAsync(Movie movie); //Me crea una pelicula --puedo actualizar el nombre, duracion, descripcion, clasificacion y la fecha de actualizacion
        Task<bool> DeleteMovieAsync(int id); //Me elimina una pelicula
    }
}
