using App.BiblioX.Domain.Models;
using App.BiblioX.Domain.Interfaces;
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

        _genresVM.LoadGenres();
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        Shell.Current.DisplayAlert("Login", "Ecran non disponible pour l'instant", "OK");

    }
}