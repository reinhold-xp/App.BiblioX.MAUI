using App.BiblioX.Domain.Interfaces;
using App.BiblioX.Domain.Models;
using App.BiblioX.Domain.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;



namespace App.BiblioX.ViewModels
{
    public partial class GenresViewModel: ObservableObject
    {
        private readonly IGenreService _genreService;
        private readonly INavigationService _navigationService;
   
        public ICommand OnItemSelectedCommand {get;}

        [ObservableProperty]
        private ObservableCollection<Genre> ?genresItems;

        [ObservableProperty]
        private ObservableCollection<Livre> ?livresItems;
               
        [ObservableProperty]
        private Genre selectedGenre;

        [ObservableProperty]
        private Livre selectedBook;

        public GenresViewModel(IGenreService genreService, INavigationService navigationService)
        {
            _genreService = genreService;
            _navigationService = navigationService;
     
        }

        // Méthode partielle appelée automatiquement par le setter généré (framework CommunityToolkit.Mvvm)
        // Elle joue le rôle de "hook" : elle réagit au changement de SelectedGenre(grâce à l'attribut [ObservableProperty])
        partial void OnSelectedGenreChanged(Genre value) 
        {
            if (value != null)
                SelectGenreAsync(value);
        }
        partial void OnSelectedBookChanged(Livre value)
        {
            if (value != null)
                SelectBookAsync(value);
        }
        private async Task SelectGenreAsync(Genre genre)
        {
            await _navigationService.NavigateToGenrePage(genre);
        }

        private async Task SelectBookAsync(Livre book)
        {
            await _navigationService.NavigateToResumePage(book);
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
