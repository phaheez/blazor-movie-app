using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorMovieApp.Data;
using BlazorMovieApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorMovieApp.Services
{
    public class MovieDbService : IMovieDbService
    {
        private readonly ApplicationDbContext _context;

        public MovieDbService(ApplicationDbContext context)
        {
            _context = context;
        }
          
        public async Task<List<Movie>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<Movie> AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> EditMovie(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
    }
}
