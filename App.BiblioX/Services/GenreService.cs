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

        public async Task<List<DtoGenre>> GetGenresAsync()
        {
            var endpoint = "genres";
            return await _api.GetAsync<List<DtoGenre>>(endpoint)  ?? new List<DtoGenre>();
        }

        public async Task<List<DtoLivre>> GetLivresByGenreAsync(int genreId)
        {
            var endpoint = $"genres/{genreId}/livres";
            return await _api.GetAsync<List<DtoLivre>>(endpoint) ?? new List<DtoLivre>();
        }
    }

}
