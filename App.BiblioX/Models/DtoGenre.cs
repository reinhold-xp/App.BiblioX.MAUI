using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BiblioX.Models
{
    public class DtoGenre
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public int NbLivres { get; set; }

    }
}
