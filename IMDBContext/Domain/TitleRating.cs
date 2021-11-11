using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfEx;
using EfEx.Domain;



namespace EfEx.Domain
{

    public class TitleRating
    {
        public char FilmId { get; set; }
        public int? AverageRating { get; set; }
        public int? NumVotes { get; set; }

    }

}