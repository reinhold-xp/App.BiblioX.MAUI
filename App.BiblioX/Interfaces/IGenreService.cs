using App.BiblioX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BiblioX.Interfaces
{
    public interface IGenreService
    {
        Task<List<DtoGenre>> GetGenresAsync();
        Task<List<DtoLivre>> GetLivresByGenreAsync(int genreId);
    }
}
