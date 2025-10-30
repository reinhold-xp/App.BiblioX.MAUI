using App.BiblioX.Models;
using App.BiblioX.ViewModels;
using System.Runtime.CompilerServices;

namespace App.BiblioX.Views;

public partial class ResumePage : ContentPage
{
    public ResumePage(DtoLivre book)
	{
		InitializeComponent();
        BindingContext = book;
    }
}