using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pre.Movies.Core.Data;
using Pre.Movies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pre.Movies.Core
{
    public class MovieRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public MovieRepository()
        {
            _applicationDbContext = new();
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var createDb = await _applicationDbContext.Database.EnsureCreatedAsync();
            var movies = await _applicationDbContext.Movies.ToListAsync();
            await _applicationDbContext.DisposeAsync();
            return movies;
        }
    }
}
