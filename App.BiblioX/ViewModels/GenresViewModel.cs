using App.BiblioX.Interfaces;
using App.BiblioX.Models;
using App.BiblioX.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;



namespace App.BiblioX.ViewModels
{
    public partial class GenresViewModel: ObservableObject
    {
        private readonly IGenreService _genreService;

        [ObservableProperty]
        private ObservableCollection<Genre> ?genresItems;

        [ObservableProperty]
        private ObservableCollection<Livre> ?livresItems;

        public GenresViewModel(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public async Task LoadGenres()
        {
            try
            {
                var genres = await _genreService.GetGenresAsync();
                GenresItems = new ObservableCollection<Genre>(genres);
            }
            catch (Exception ex)    
            {
                Console.WriteLine($"Erreur lors du chargement des genres : {ex.Message}");
            }
        }
        public async Task LoadBooks(int genreId)
        {
            try
            {
                var livres = await _genreService.GetLivresByGenreAsync(genreId);
                LivresItems = new ObservableCollection<Livre>(livres);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du chargement des livres pour le genre {genreId} : {ex.Message}");
            }
        }
    }
}
