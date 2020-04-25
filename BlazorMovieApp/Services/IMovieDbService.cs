using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorMovieApp.Models;

namespace BlazorMovieApp.Services
{
    public interface IMovieDbService
    {
        Task<List<Movie>> GetMovies();
        Task<Movie> GetMovieById(int id);
        Task<Movie> AddMovie(Movie movie);
        Task<Movie> EditMovie(Movie movie);
        Task<Movie> DeleteMovie(int id);
    }
}
