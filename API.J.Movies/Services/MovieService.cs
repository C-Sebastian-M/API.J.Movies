using API.J.Movies.DAL.Models;
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
        public async Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto movieCreateDto)
        {
            if (!MovieDurationIsValid(movieCreateDto.Duration))
            {
                throw new ArgumentException("La duración de la película no es válida.");
            }
            var movieExists = await _movieRepository.MovieExistsByNameAsync(movieCreateDto.Name);

            if (movieExists)
            {
                throw new InvalidOperationException($"Ya existe una película con el nombre de '{movieCreateDto.Name}'");
            }

            var movie = _mapper.Map<Movie>(movieCreateDto);

            var movieCreated = await _movieRepository.CreateMovieAsync(movie);

            if (!movieCreated)
            {
                throw new Exception("Ocurrió un error al crear la película.");
            }

            //Mapear la entidad creada a DTO
            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movieExists = await _movieRepository.GetMovieAsync(id);
            if (movieExists == null)
            {
                throw new InvalidOperationException($"No se encontró la película con ID {id}.");
            }
            var movieDeleted = await _movieRepository.DeleteMovieAsync(id);
            if (!movieDeleted)
            {
                throw new Exception("Ocurrió un error al eliminar la película.");
            }
            return movieDeleted;
        }

        public async Task<MovieDto> GetMovieAsync(int id)
        {
            var movie = await _movieRepository.GetMovieAsync(id);

            if (movie == null)
            {
                throw new InvalidOperationException($"No se encontró la película con ID {id}.");
            }

            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();
            return _mapper.Map<ICollection<MovieDto>>(movies);
        }

        public async Task<MovieDto> UpdateMovieAsync(int id, MovieCreateUpdateDto movie)
        {
            if (!MovieDurationIsValid(movie.Duration))
            {
                throw new ArgumentException("La duración de la película no es válida. (Tiene que ser mayor a 0)");
            }
            var movieExists = await _movieRepository.GetMovieAsync(id);
            if (movieExists == null)
            {
                throw new KeyNotFoundException($"No se encontró la película con ID {id}.");
            }
            var nameExists = await _movieRepository.MovieExistsByNameAsync(movie.Name);
            if (nameExists)
            {
                throw new InvalidOperationException($"Ya existe una película con el nombre de '{movie.Name}'");
            }
            _mapper.Map(movie, movieExists);
            var updated = await _movieRepository.UpdateMovieAsync(movieExists);
            if (!updated)
            {
                throw new Exception("Ocurrió un error al actualizar la película.");
            }
            return _mapper.Map<MovieDto>(movieExists);
        }

        private bool MovieDurationIsValid(int duration)
        {
            return duration > 0;
        }
    }
}
