using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.ViewModels
{
    public class SearchHistoryViewModel
    {
        public string Url { get; set; }
        
        public string UserId { get; set; }
        public string FilmId { get; set; }
        public DateTime Date { get; set; }
    }
}