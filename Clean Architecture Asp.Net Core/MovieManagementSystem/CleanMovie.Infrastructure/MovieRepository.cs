using CleanMovie.Application;
using CleanMovie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Infrastructure
{
    public class MovieRepository : IMovieRepository
    {
        public static List<Movie> movies = new List<Movie>()
        {
            new Movie{Id=1, Name = "Tetris", Cost= 3},
            new Movie{Id=2, Name = "Ant-Man and the wasp", Cost= 4},
            new Movie{Id=3, Name = "The Last Kingdom", Cost= 2}
        };
        public List<Movie> GetAllMovies()
        {
            return movies;
        }
    }
}
