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
var sortedByYear = movies.OrderBy(m => m.Year);
PrintLines();
PrintMovies(sortedByYear);
// Sorteer de films op basis van hun beoordeling (Rating) in aflopende volgorde.
var orderedByRating = movies.OrderByDescending(m => m.Rating);
PrintLines();
PrintMovies(orderedByRating);
// Haal de top 5 best beoordeelde films op.
var top5Rated = movies.OrderByDescending(m => m.Rating).Take(5);
PrintLines();
PrintMovies(top5Rated);
// Geef een lijst van de films gesorteerd op regisseur en vervolgens op jaar.
var sortedByDirectorAndYear = movies.OrderBy(m => m.Director).ThenBy(m => m.Year);
PrintLines();
PrintMovies(sortedByDirectorAndYear);
// Selecteer de nieuwste film in de dataset.
var newestMovie = movies.OrderByDescending(m => m.Year).FirstOrDefault();
PrintLines();
PrintMovie(newestMovie);
//3. Aggregaties en tellingen //

// Tel het aantal films in de dataset.
var numOfMovies = movies.Count();
PrintLines();
Console.WriteLine($"Aantal movies = {numOfMovies}");
// Bepaal de gemiddelde beoordeling (Rating) van alle films.
var averageRating = movies.Average(m => m.Rating);
PrintLines();
Console.WriteLine($"Average rating = {averageRating}");
// Bepaal de oudste film in de dataset.
var oldestMovie = movies.FirstOrDefault(m => m.Year == movies.Min(m => m.Year));
// Geef de film met de hoogste beoordeling terug.
var highestRated = movies.FirstOrDefault(m => m.Rating == movies.Max(m => m.Rating));
// Bepaal de totale inkomsten (BoxOffice) van alle films samen (convert naar double).
var totalBoxOffice = movies.Sum(m => 
{
    //strip first and last character
    var boxOffice = m.BoxOffice.Substring(1, (m.BoxOffice.Length - 2));
    //parse to double
    var boxOfficeDouble = double.Parse(boxOffice, CultureInfo.InvariantCulture);
    //check if B => * 1000
    if (m.BoxOffice.Last().Equals('B'))
    {
        boxOfficeDouble *= 1000;
    }
    return boxOfficeDouble;
});
PrintLines();
Console.WriteLine($"Total BoxOffice = ${totalBoxOffice}M");
// 4.Groeperen en samenvoegen //

// Groepeer de films per regisseur en toon hoeveel films elke regisseur heeft gemaakt.
var groupedByDirector = movies.GroupBy(m => m.Director);
foreach(var group in groupedByDirector)
{
    Console.WriteLine($"{group.Key}:{group.Count()}");
}
// Groepeer de films op decennium (bijv. 1990-1999, 2000-2009, etc.).
var groupedByDecade = movies.GroupBy(m => (m.Year / 10) * 10).OrderBy(m =>m.Key);
foreach(var group in groupedByDecade)
{
    PrintLines();
    Console.WriteLine($"{group.Key}");
    foreach(var movie in group)
    {
        PrintMovie(movie);
    }  
}
// Geef een overzicht van het gemiddelde IMDb-cijfer per genre.
var groupedByGenreAvgRating = movies
    .SelectMany(m => m.Genre, (movie, genre) => (movie.Rating, genre))
    .GroupBy(g => g.genre);
foreach(var group in groupedByGenreAvgRating)
{
    Console.WriteLine($"{group.Key}:{group.Average(g => g.Rating)}");
}

// Groepeer de films op land en toon het aantal films per land.
var groupedByCountry = movies.GroupBy(m => m.Country).OrderBy(g => g.Key);
foreach(var group in groupedByCountry)
{
    Console.WriteLine($"{group.Key}:{group.Count()}");
}
// Geef een lijst van alle regisseurs en de films die ze hebben gemaakt, netjes gegroepeerd.
var groupedByDirectors = movies.GroupBy(m => m.Director).OrderBy(g => g.Key);
foreach(var group in groupedByDirectors)
{
    PrintLines();
    Console.WriteLine($"{group.Key}");
    foreach(var movie in group)
    {
        PrintMovie(movie);
    }
}



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

