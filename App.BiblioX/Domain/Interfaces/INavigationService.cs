using App.BiblioX.Domain.Models;
using App.BiblioX.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BiblioX.Domain.Interfaces
{
   public interface INavigationService
    {
        Task NavigateToGenrePage(Genre selectedGenre);
        Task NavigateToResumePage(Livre selectedBook);
    }
}
