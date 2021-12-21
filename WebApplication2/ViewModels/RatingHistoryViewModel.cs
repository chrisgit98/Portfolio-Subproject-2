using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.ViewModels
{
    public class RatingHistoryViewModel
    {
        public string Url { get; set; }

        public int? UserId { get; set; }
        public string FilmId { get; set; }
        public float? Rating { get; set; }
        public int? Date { get; set; }
    }
}
