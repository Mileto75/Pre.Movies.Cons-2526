// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Pre.Movies.Core;
using Pre.Movies.Core.Data;
using Pre.Movies.Core.Entities;
using System.Diagnostics.Contracts;
using System.Globalization;

var movieRepository = new MovieRepository();
var movies = await movieRepository.GetMovies();

Console.WriteLine("Movies loaded!");
//PrintMovies(movies);

// Oefeningen //
//1. Basis Linq //

// Selecteer alle filmtitels uit de lijst.
var movieTitles = movies.Select(m => m.Title);
//foreach(var title in movieTitles)
//{
//    Console.Write(title);
//}
//string.Join
Console.WriteLine(string.Join(",", movieTitles));
// Filter de films die na het jaar 2000 zijn uitgebracht.
var moviesAfter2000 = movies.Where(m => m.Year > 2000);
PrintMovies(moviesAfter2000);
// Geef een lijst van alle unieke genres die in de dataset voorkomen.
//SelectMany => flattening => Distinct
var uniqueMovieGenres = movies.SelectMany(m => m.Genre);
Console.WriteLine(string.Join(",", uniqueMovieGenres));

// Selecteer alle films van een specifieke regisseur (bijv. "Christopher Nolan").
var moviesFromNolan = movies.Where(m => m.Director.Contains("Nolan"));
PrintLines();
PrintMovies(moviesFromNolan);
// Haal alle films op waarin een specifieke acteur meespeelt (bijv. "Leonardo DiCaprio").
var moviesFromLeo = movies.Where(m => m.Actors.Contains("Leonardo Di Caprio"));
//haal de eerste film op
PrintLines();
var firstMovie = movies.FirstOrDefault();
//haal de laatste film op
PrintLines();
var lastMovie = movies.LastOrDefault();
//haal de eerste drie films op
var firstThreeMovies = movies.Take(3);
PrintLines();
PrintMovies(firstThreeMovies);
//haal films op positie 3 tem 5
PrintLines();
var sliced = movies.Skip(2).Take(3);
PrintMovies(sliced);
//haal de eerste film op met het woord 'Fiction' in de titel
var firstFictionMovie = movies.FirstOrDefault(m => m.Title.Contains("Fiction"));
PrintLines();
PrintMovie(firstFictionMovie);
//2. Sorteren en ordenen //

// Sorteer de films op jaartal, van oud naar nieuw.

// Sorteer de films op basis van hun beoordeling (Rating) in aflopende volgorde.

// Haal de top 5 best beoordeelde films op.

// Geef een lijst van de films gesorteerd op regisseur en vervolgens op jaar.

// Selecteer de nieuwste film in de dataset.

//3. Aggregaties en tellingen //

// Tel het aantal films in de dataset.

// Bepaal de gemiddelde beoordeling (Rating) van alle films.

// Bepaal de oudste film in de dataset.

// Geef de film met de hoogste beoordeling terug.

// Bepaal de totale inkomsten (BoxOffice) van alle films samen (convert naar double).

// 4.Groeperen en samenvoegen //

// Groepeer de films per regisseur en toon hoeveel films elke regisseur heeft gemaakt.

// Groepeer de films op decennium (bijv. 1990-1999, 2000-2009, etc.).

// Geef een overzicht van het gemiddelde IMDb-cijfer per genre.

// Groepeer de films op land en toon het aantal films per land.

// Geef een lijst van alle regisseurs en de films die ze hebben gemaakt, netjes gegroepeerd.




//helper methods
void PrintLines()
{
    Console.WriteLine("----------------------------------");
    Console.WriteLine("----------------------------------");
}
void PrintMovies(IEnumerable<Movie> movies)
{
    foreach (var movie in movies)
    {
        PrintLines();
        PrintMovie(movie);
    }
}
void PrintMovie(Movie movie)
{
    Console.WriteLine($"Title: {movie.Title}");
    Console.Write($"Genre: ");
    foreach (var genre in movie.Genre)
    {
        Console.Write($"{genre} ");
    }
    Console.WriteLine();
    Console.WriteLine($"Director: {movie.Director}");
    Console.WriteLine($"Year: {movie.Year}");
    foreach (var actor in movie.Actors)
    {
        Console.Write($"{actor} ");
    }
    Console.WriteLine();
    Console.WriteLine($"Country: {movie.Country}");
    Console.WriteLine($"BoxOffice: {movie.BoxOffice}");
    Console.WriteLine($"Rating: {movie.Rating}");
}

