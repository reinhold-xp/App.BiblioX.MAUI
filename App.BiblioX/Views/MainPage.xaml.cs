using App.BiblioX.Interfaces;
using App.BiblioX.Models;
using App.BiblioX.ViewModels;

namespace App.BiblioX.Views;

public partial class MainPage : ContentPage
{
    private GenresViewModel _genres;
    public MainPage(GenresViewModel genres)
	{
		InitializeComponent();

        _genres = genres;
        BindingContext = _genres;

        _= _genres.LoadGenres();
    }

    private async void lv_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var selectedGenre = (DtoGenre)e.SelectedItem;
        await Navigation.PushAsync(new GenrePage(selectedGenre, _genres));
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {

    }
}