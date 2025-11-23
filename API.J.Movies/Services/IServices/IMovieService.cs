using API.J.Movies.DAL.Models.Dto;

namespace API.J.Movies.Services.IServices
{
    public interface IMovieService
    {
        Task<ICollection<MovieDto>> GetMoviesAsync();
        Task<MovieDto> GetMovieAsync(int id);
        Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto movie);
        Task<MovieDto> UpdateMovieAsync(int id, MovieCreateUpdateDto movie);
        Task<bool> DeleteMovieAsync(int id);
    }
}
