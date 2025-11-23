using API.J.Movies.DAL.Models.Dto;
using API.J.Movies.Repository;
using API.J.Movies.Repository.IRepository;
using API.J.Movies.Services.IServices;
using AutoMapper;

namespace API.J.Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto movie)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMovieAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieDto> GetMovieAsync(int id)
        {
            var category = await _movieRepository.GetMovieAsync(id);

            if (category == null)
            {
                throw new InvalidOperationException($"No se encontró la película con ID {id}.");
            }

            return _mapper.Map<MovieDto>(category);
        }

        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();
            return _mapper.Map<ICollection<MovieDto>>(movies);
        }

        public Task<MovieDto> UpdateMovieAsync(int id, MovieCreateUpdateDto movie)
        {
            throw new NotImplementedException();
        }
    }
}
