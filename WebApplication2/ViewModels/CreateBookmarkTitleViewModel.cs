using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.ViewModels
{
    public class CreateBookmarkTitleViewModel
    {
        public int UserId { get; set; }
        public string FilmId { get; set; }
        public string Title { get; set; }

    }
}
