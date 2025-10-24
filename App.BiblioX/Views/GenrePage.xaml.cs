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
}