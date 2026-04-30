using App.BiblioX.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BiblioX.Domain.Interfaces
{
    public interface IGenreService
    {
        Task<List<Genre>> GetGenresAsync();
        Task<List<Livre>> GetLivresByGenreAsync(int genreId);
    }
}
