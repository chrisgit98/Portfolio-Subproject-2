using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfEx;
using EfEx.Domain;

namespace EfEx.Domain
{
    public class BestMatchSearch
    {
        public string FilmId { get; set; }
        public float? Ranking { get; set; }
        public string Title { get; set; }
    }
}
