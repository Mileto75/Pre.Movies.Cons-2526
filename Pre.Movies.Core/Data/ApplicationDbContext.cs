using Microsoft.EntityFrameworkCore;
using Pre.Movies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Movies.Core.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionstring = "Server=(localdb)\\mssqllocaldb;Database=MoviesDb;Trusted_Connection=True;";
            //optionsBuilder.UseInMemoryDatabase("MoviesDb");
            optionsBuilder.UseSqlServer(connectionstring);
            optionsBuilder.LogTo(m => Debug.WriteLine(m));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var movies = new Movie[]
                {
                    new Movie { Id = 1, Title = "The Shawshank Redemption", Year = 1994, Genre = new List<string>{"Drama"}, Rating = 9.3, Director = "Frank Darabont", Actors = new List<string>{"Tim Robbins", "Morgan Freeman"}, Awards = "7 Oscar Nominations", Country = "USA", BoxOffice = "$28.3M" },
                    new Movie { Id = 2, Title = "The Godfather", Year = 1972, Genre = new List<string>{"Crime", "Drama"}, Rating = 9.2, Director = "Francis Ford Coppola", Actors = new List<string>{"Marlon Brando", "Al Pacino"}, Awards = "3 Oscars", Country = "USA", BoxOffice = "$134.97M" },
                    new Movie { Id = 3, Title = "The Dark Knight", Year = 2008, Genre = new List<string>{"Action", "Crime", "Drama"}, Rating = 9.0, Director = "Christopher Nolan", Actors = new List<string>{"Christian Bale", "Heath Ledger"}, Awards = "2 Oscars", Country = "USA", BoxOffice = "$534.86M" },
                    new Movie { Id = 4, Title = "Pulp Fiction", Year = 1994, Genre = new List<string>{"Crime", "Drama"}, Rating = 8.9, Director = "Quentin Tarantino", Actors = new List<string>{"John Travolta", "Uma Thurman"}, Awards = "1 Oscar", Country = "USA", BoxOffice = "$213.9M" },
                    new Movie { Id = 5, Title = "The Lord of the Rings: The Return of the King", Year = 2003, Genre = new List<string>{"Action", "Adventure", "Drama"}, Rating = 9.0, Director = "Peter Jackson", Actors = new List<string>{"Elijah Wood", "Viggo Mortensen"}, Awards = "11 Oscars", Country = "USA", BoxOffice = "$1.15B" },
                    new Movie { Id = 6, Title = "Forrest Gump", Year = 1994, Genre = new List<string>{"Drama", "Romance"}, Rating = 8.8, Director = "Robert Zemeckis", Actors = new List<string>{"Tom Hanks", "Robin Wright"}, Awards = "6 Oscars", Country = "USA", BoxOffice = "$678.2M" },
                    new Movie { Id = 7, Title = "Inception", Year = 2010, Genre = new List<string>{"Action", "Adventure", "Sci-Fi"}, Rating = 8.8, Director = "Christopher Nolan", Actors = new List<string>{"Leonardo DiCaprio", "Joseph Gordon-Levitt"}, Awards = "4 Oscars", Country = "USA", BoxOffice = "$829.9M" },
                    new Movie { Id = 8, Title = "Fight Club", Year = 1999, Genre = new List<string>{"Drama"}, Rating = 8.8, Director = "David Fincher", Actors = new List<string>{"Brad Pitt", "Edward Norton"}, Awards = "1 Oscar Nomination", Country = "USA", BoxOffice = "$101.2M" },
                    new Movie { Id = 9, Title = "Interstellar", Year = 2014, Genre = new List<string>{"Adventure", "Drama", "Sci-Fi"}, Rating = 8.7, Director = "Christopher Nolan", Actors = new List<string>{"Matthew McConaughey", "Anne Hathaway"}, Awards = "1 Oscar", Country = "USA", BoxOffice = "$773.7M" },
                    new Movie { Id = 10, Title = "The Matrix", Year = 1999, Genre = new List<string>{"Action", "Sci-Fi"}, Rating = 8.7, Director = "Lana Wachowski, Lilly Wachowski", Actors = new List<string>{"Keanu Reeves", "Laurence Fishburne"}, Awards = "4 Oscars", Country = "USA", BoxOffice = "$463.5M" },
                    new Movie { Id = 11, Title = "Goodfellas", Year = 1990, Genre = new List<string>{"Biography", "Crime", "Drama"}, Rating = 8.7, Director = "Martin Scorsese", Actors = new List<string>{"Robert De Niro", "Ray Liotta"}, Awards = "1 Oscar", Country = "USA", BoxOffice = "$46.8M" },
                    new Movie { Id = 12, Title = "Se7en", Year = 1995, Genre = new List<string>{"Crime", "Drama", "Mystery"}, Rating = 8.6, Director = "David Fincher", Actors = new List<string>{"Morgan Freeman", "Brad Pitt"}, Awards = "1 Oscar Nomination", Country = "USA", BoxOffice = "$327.3M" },
                    new Movie { Id = 13, Title = "The Silence of the Lambs", Year = 1991, Genre = new List<string>{"Crime", "Drama", "Thriller"}, Rating = 8.6, Director = "Jonathan Demme", Actors = new List<string>{"Jodie Foster", "Anthony Hopkins"}, Awards = "5 Oscars", Country = "USA", BoxOffice = "$272.7M" },
                    new Movie { Id = 14, Title = "Saving Private Ryan", Year = 1998, Genre = new List<string>{"Drama", "War"}, Rating = 8.6, Director = "Steven Spielberg", Actors = new List<string>{"Tom Hanks", "Matt Damon"}, Awards = "5 Oscars", Country = "USA", BoxOffice = "$482.3M" },
                    new Movie { Id = 15, Title = "The Green Mile", Year = 1999, Genre = new List<string>{"Crime", "Drama", "Fantasy"}, Rating = 8.6, Director = "Frank Darabont", Actors = new List<string>{"Tom Hanks", "Michael Clarke Duncan"}, Awards = "4 Oscar Nominations", Country = "USA", BoxOffice = "$286.8M" },
                    new Movie { Id = 16, Title = "Gladiator", Year = 2000, Genre = new List<string>{"Action", "Drama"}, Rating = 8.5, Director = "Ridley Scott", Actors = new List<string>{"Russell Crowe", "Joaquin Phoenix"}, Awards = "5 Oscars", Country = "USA", BoxOffice = "$460.5M" },
                    new Movie { Id = 17, Title = "The Departed", Year = 2006, Genre = new List<string>{"Crime", "Drama", "Thriller"}, Rating = 8.5, Director = "Martin Scorsese", Actors = new List<string>{"Leonardo DiCaprio", "Matt Damon"}, Awards = "4 Oscars", Country = "USA", BoxOffice = "$291.5M" },
                    new Movie { Id = 18, Title = "Whiplash", Year = 2014, Genre = new List<string>{"Drama", "Music"}, Rating = 8.5, Director = "Damien Chazelle", Actors = new List<string>{"Miles Teller", "J.K. Simmons"}, Awards = "3 Oscars", Country = "USA", BoxOffice = "$49.5M" },
                    new Movie { Id = 19, Title = "The Prestige", Year = 2006, Genre = new List<string>{"Drama", "Mystery", "Sci-Fi"}, Rating = 8.5, Director = "Christopher Nolan", Actors = new List<string>{"Christian Bale", "Hugh Jackman"}, Awards = "2 Oscar Nominations", Country = "USA", BoxOffice = "$109.7M" },
                    new Movie { Id = 20, Title = "The Lion King", Year = 1994, Genre = new List<string>{"Animation", "Adventure", "Drama"}, Rating = 8.5, Director = "Roger Allers, Rob Minkoff", Actors = new List<string>{"Matthew Broderick", "Jeremy Irons"}, Awards = "2 Oscars", Country = "USA", BoxOffice = "$968.5M" },
                    new Movie { Id = 21, Title = "The Usual Suspects", Year = 1995, Genre = new List<string>{"Crime", "Drama", "Mystery"}, Rating = 8.5, Director = "Bryan Singer", Actors = new List<string>{"Kevin Spacey", "Gabriel Byrne"}, Awards = "2 Oscars", Country = "USA", BoxOffice = "$23.3M" }
                };
            modelBuilder.Entity<Movie>().HasData(movies);
            base.OnModelCreating(modelBuilder);
        }
    }
}
