using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfEx;
using EfEx.Domain;

namespace EfEx.Domain
{
    public class NameOtherview
    {
        public string PersonId { get; set; }
        public string Name { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public string KnownForTitles { get; set; }
    }
}
