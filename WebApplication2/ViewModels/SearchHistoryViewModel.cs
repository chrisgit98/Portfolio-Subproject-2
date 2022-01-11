using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebService.ViewModels
{
    public class SearchHistoryViewModel
    {
        public string Url { get; set; }
        
        public string UserId { get; set; }
        public string FilmId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
    }
}