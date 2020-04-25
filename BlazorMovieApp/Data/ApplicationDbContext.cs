using System;
using System.Collections.Generic;
using System.Text;
using BlazorMovieApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorMovieApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 10,
                    Title = "The Sound Of Music",
                    ReleaseDate = new DateTime(2012, 3, 2),
                    Genre = "Musical Drama",
                    Director = "Robert Wise",
                    RunningTime = 175
                },
                new Movie
                {
                    Id = 20,
                    Title = "Hatari",
                    ReleaseDate = new DateTime(2002, 4, 22),
                    Genre = "Adventure",
                    Director = "Howard Hawks",
                    RunningTime = 155
                },
                new Movie
                {
                    Id = 30,
                    Title = "Back to the Future",
                    ReleaseDate = new DateTime(2019, 12, 15),
                    Genre = "Science Fiction",
                    Director = "Robert Zemeckis",
                    RunningTime = 116
                });
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
