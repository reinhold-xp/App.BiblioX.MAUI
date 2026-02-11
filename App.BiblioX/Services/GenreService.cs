using App.BiblioX.Interfaces;
using App.BiblioX.Models;

namespace App.BiblioX.Services
{
    public class GenreService : IGenreService
    {
        private readonly RestApiService _api;

        public GenreService(RestApiService api)
        {
            _api = api;
        }

        public async Task<List<Genre>> GetGenresAsync()
        {
            var endpoint = "genres";
            return await _api.GetAsync<List<Genre>>(endpoint)  ?? new List<Genre>();
        }

        public async Task<List<Livre>> GetLivresByGenreAsync(int genreId)
        {
            var endpoint = $"genres/{genreId}/livres";
            return await _api.GetAsync<List<Livre>>(endpoint) ?? new List<Livre>();
        }
    }

}
