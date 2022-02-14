using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using EfEx;
using EfEx.Domain;
namespace WebService.ViewModels
{
    public class NameOtherviewViewModel
    {
        public string Url { get; set; }

        public string PersonId { get; set; }
        public string Name { get; set; }
        public string BirthYear { get; set; }
        public string DeathYear { get; set; }
        public string KnownForTitles { get; set; }

    }
}
