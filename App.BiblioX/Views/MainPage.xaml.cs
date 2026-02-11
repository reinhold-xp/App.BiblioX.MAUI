using App.BiblioX.Interfaces;
using App.BiblioX.Models;
using App.BiblioX.ViewModels;

namespace App.BiblioX.Views;

public partial class MainPage : ContentPage
{
    private GenresViewModel _genresVM;
    public MainPage(GenresViewModel genres)
	{
		InitializeComponent();

        _genresVM = genres;
        BindingContext = _genresVM;

        // Charger les genres au démarrage de la page...
        _genresVM.LoadGenres();
    }

    private async void lv_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var selectedGenre = (Genre)e.SelectedItem;
        await Navigation.PushAsync(new GenrePage(selectedGenre, _genresVM));
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        Shell.Current.DisplayAlert("Login", "Ecran non disponible pour l'instant", "OK");

    }
}