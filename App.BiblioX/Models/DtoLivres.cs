using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BiblioX.Models
{
    public class DtoLivre
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public int Pages { get; set; }
        public string Image { get; set; }
        public string Resume { get; set; }
        public string Auteur { get; set; }
        public List<string> Genres { get; set; }
    }
}
