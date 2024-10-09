using MovieLibrary.Controllers;
using MovieLibrary.Exceptions;
using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplicationWithDLL.Presentation
{
    public static class MovieMenu
    {
        public static void ShowMenu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Welcome To Movie Management System : ");
                Console.WriteLine("1. Display Movies");
                Console.WriteLine("2. Add Movie");
                Console.WriteLine("3. Edit Movie");
                Console.WriteLine("4. Find Movie By Id");
                Console.WriteLine("5. Find Movie By Name");
                Console.WriteLine("6. Remove Movie By Id");
                Console.WriteLine("7. Remove Movie By Name");
                Console.WriteLine("8. Clear All Movies");
                Console.WriteLine("9. Exit");


                Console.Write("Enter your Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        try
                        {
                            var movies = MovieManager.GetAllMovies();
                            foreach (var movie in movies)
                            {
                                Console.WriteLine(movie.ToString());
                            }
                        }
                        catch (NoMoviesAvailableException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "2":
                        AddMovie();
                        break;

                    case "3":
                        EditMovie();
                        break;

                    case "4":
                        FindMovieById();
                        break;

                    case "5":
                        FindMovieByName();
                        break;

                    case "6":
                        RemoveMovieById();
                        break;

                    case "7":
                        RemoveMovieByName();
                        break;

                    case "8":
                        ClearAllMovies();
                        break;

                    case "9":
                        MovieManager.ExitApp();
                        running = false;
                        break;
                }
            }
        }

        private static void AddMovie()
        {
            try
            {
                var movie = new Movie();
                Console.WriteLine("Enter Movie Id: ");
                movie.Id = int.Parse(Console.ReadLine());
                Console.Write("Enter Movie Title: ");
                movie.Title = Console.ReadLine();
                Console.Write("Enter Movie Director: ");
                movie.Director = Console.ReadLine();
                Console.Write("Enter Release Year: ");
                movie.ReleaseYear = int.Parse(Console.ReadLine());
                MovieManager.AddMovie(movie);
                Console.WriteLine("Movie added successfully!");
            }
            catch (DuplicateMovieException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void EditMovie()
        {
            try
            {
                Console.Write("Enter Movie ID to edit: ");
                int movieId = int.Parse(Console.ReadLine());
                var updatedMovie = new Movie();
                Console.Write("Enter new Title: ");
                updatedMovie.Title = Console.ReadLine();
                Console.Write("Enter new Director: ");
                updatedMovie.Director = Console.ReadLine();
                Console.Write("Enter new Release Year: ");
                updatedMovie.ReleaseYear = int.Parse(Console.ReadLine());

                MovieManager.EditMovie(movieId, updatedMovie);
                Console.WriteLine("Movie updated successfully!");
            }
            catch (MovieNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void FindMovieById()
        {
            try
            {
                Console.Write("Enter Movie ID: ");
                int movieId = int.Parse(Console.ReadLine());
                var movie = MovieManager.FindMovieById(movieId);
                Console.WriteLine(movie.ToString());
            }
            catch (MovieNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void FindMovieByName()
        {
            try
            {
                Console.Write("Enter Movie Title: ");
                string title = Console.ReadLine();
                var movie = MovieManager.FindMovieByName(title);
                Console.WriteLine(movie.ToString());
            }
            catch (MovieNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void RemoveMovieById()
        {
            try
            {
                Console.Write("Enter Movie ID: ");
                int movieId = int.Parse(Console.ReadLine());
                MovieManager.RemoveMovieById(movieId);
                Console.WriteLine("Movie removed successfully!");
            }
            catch (MovieNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void RemoveMovieByName()
        {
            try
            {
                Console.Write("Enter Movie Title: ");
                string title = Console.ReadLine();
                MovieManager.RemoveMovieByName(title);
                Console.WriteLine("Movie removed successfully!");
            }
            catch (MovieNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ClearAllMovies()
        {
            try
            {
                MovieManager.ClearAllMovies();
                Console.WriteLine("All movies cleared successfully.");
            }
            catch (NoMoviesAvailableException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
