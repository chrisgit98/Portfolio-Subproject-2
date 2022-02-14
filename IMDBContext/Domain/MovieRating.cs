using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfEx;

namespace EfEx.Domain
{
    public class MovieRating
    {
        public int UserId { get; set; }
        public string FilmId { get; set; }
        public float? GivenRate { get; set; }
    }
}
