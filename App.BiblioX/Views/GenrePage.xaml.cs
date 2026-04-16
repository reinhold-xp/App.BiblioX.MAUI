using App.BiblioX.Domain.Models;
using App.BiblioX.Domain.Interfaces;
using App.BiblioX.ViewModels;

namespace App.BiblioX.Views;

public partial class GenrePage : ContentPage
{
     
    public GenrePage(Genre genre, GenresViewModel vm)
	{
		InitializeComponent();

        Title = genre.Nom;
        BindingContext = vm;

        vm.LoadBooks(genre.Id);
    }
}