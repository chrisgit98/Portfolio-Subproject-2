using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using EfEx;
using EfEx.Domain;

namespace WebService.ViewModels
{
    public class TitleOtherViewViewModel
    {
        public string Url { get; set; }
        public string FilmId { get; set; }
        public string Title { get; set; }
        public string TitleType { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        public int? Lenght { get; set; }
        public string Poster { get; set; }
        public string Plot { get; set; }
        public string Awards { get; set; }
        public int? Rating { get; set; }
        public string Genre { get; set; }
    }
}
