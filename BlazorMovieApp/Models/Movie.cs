using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovieApp.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Movie Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Released Date is required")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Movie Genre is required")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Movie Director is required")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Running Time is required")]
        public int RunningTime { get; set; }
    }
}
