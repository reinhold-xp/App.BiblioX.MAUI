using App.BiblioX.Interfaces;
using App.BiblioX.Models;
using App.BiblioX.ViewModels;

namespace App.BiblioX.Views;

public partial class GenrePage : ContentPage
{
	public GenrePage(DtoGenre genre, GenresViewModel vm)
	{
		InitializeComponent();

        Title = genre.Nom;
        BindingContext = vm;
        
        _= vm.LoadBooks(genre.Id);
    }

    private async void lv_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var selectedBook = (DtoLivre)e.SelectedItem;
        await Navigation.PushAsync(new ResumePage(selectedBook));
    }
}