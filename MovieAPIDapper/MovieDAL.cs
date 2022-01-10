using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPIDapper
{
    public class MovieDAL
    {
        public List<Movie> GetAllMovies()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = "select * from movies";
                connect.Open();
                List<Movie> movie = connect.Query<Movie>(sql).ToList();
                connect.Close();
                return movie;
            }
        }

        public List<string> GetGenres()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                List<string> genre = new List<string>();
                string sql = $"select * from movies where genre = '{genre}'";
                connect.Open();
                List<Movie> movies = connect.Query<Movie>(sql).ToList();
                connect.Close();
                foreach (var movie in movies)
                {
                    genre.Add(movie.Genre);
                }
                return genre;
            }
        }

        public Movie GetTitle(string title)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                List<string> genre = new List<string>();
                string sql = $"select * from movies where title = '{title}'";
                connect.Open();
                Movie movie = connect.Query<Movie>(sql).ToList().First();
                connect.Close();                
                return movie;
            }
        }

        public Movie GetRandomMovie()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = "select * from movies";
                connect.Open();
                List<Movie> movies = connect.Query<Movie>(sql).ToList();
                
                Random r = new Random();
                int rNum = r.Next(0, movies.Count);
                connect.Close();

                return movies[rNum];
            }
        }

        public Movie GetRandomGenre(string genre)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"select * from movies where genre = '{genre}'";
                try
                {
                    connect.Open();
                    List<Movie> movies = connect.Query<Movie>(sql).ToList();
                    Random r = new Random();
                    int rNum = r.Next(0, movies.Count);
                    connect.Close();
                    return movies[rNum];
                }
                catch (InvalidOperationException)
                {
                    Movie error = new Movie();
                    error.Title = $"Coudldn't find genre \"{genre}\". Try again'";
                    return error;
                }
            }
        }

        public Movie GetRandomTitle(string title)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"select * from movies where title = '{title}'";
                try
                {
                    connect.Open();
                    List<Movie> movies = connect.Query<Movie>(sql).ToList();
                    Random r = new Random();
                    int rNum = r.Next(0, movies.Count);
                    connect.Close();
                    return movies[rNum];
                }
                catch (InvalidOperationException)
                {
                    Movie error = new Movie();
                    error.Title = $"Coudldn't find \"{title}\" as a movie. Try again'";
                    return error;
                }
            }
        }

    }
}
