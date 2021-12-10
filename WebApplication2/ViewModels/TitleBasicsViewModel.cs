using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.ViewModels
{
    public class TitleBasicsViewModel
    {
        public string Url { get; set; }
        public string FilmId { get; set; }
        public string TitleType { get; set; }
        public string OriginalTitle { get; set; }
        public string YearRelease { get; set; }
        public int RuntimeMinutes { get; set; }
    }
}
