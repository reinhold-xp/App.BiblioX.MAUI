using App.BiblioX.Domain.Interfaces;
using App.BiblioX.Domain.Models;
using App.BiblioX.ViewModels;
using App.BiblioX.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.BiblioX.Domain.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;


        // Injection de IServiceProvider pour résoudre les dépendances à la volée
        public NavigationService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task NavigateToGenrePage(Genre selectedGenre)
        {

            // NOUVEAU ViewModel grâce à l'injection de dépendances,
            // on peut résoudre le GenresViewModel à la volée
            var vm = _serviceProvider.GetRequiredService<GenresViewModel>();

     
            // Navigation via Shell : on utilise la pile de navigation gérée par Shell.Current.
            // Shell garantit une pile stable et toujours disponible, contrairement à l’ancienne
            // navigation basée sur Application.Current.MainPage (iNavigation) 
            //
            // Ici, on empile (PushAsync) une nouvelle page GenrePage 
        
            // Ce mécanisme déclenche l’affichage de la page tout en conservant l’historique
            // de navigation pour permettre un retour arrière (PopAsync).
            await Shell.Current.Navigation.PushAsync(new GenrePage(selectedGenre, vm));
        }

        public async Task NavigateToResumePage(Livre selectedBook)
        {              
            await Shell.Current.Navigation.PushAsync(new ResumePage(selectedBook));
        }
    }
}
