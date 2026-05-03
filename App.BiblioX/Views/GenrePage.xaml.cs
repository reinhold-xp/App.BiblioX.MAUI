using System;
using Microsoft.Extensions.DependencyInjection;
using App.BiblioX.Domain.Models;
using App.BiblioX.Domain.Interfaces;
using App.BiblioX.ViewModels;
using App.BiblioX.Domain.Services;

namespace App.BiblioX.Views;

public partial class GenrePage : ContentPage
{
    // Injection des services via le constructeur pour éviter
    // d'accéder à Application.Current.Services
    public GenrePage(GenresViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}