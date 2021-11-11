using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfEx;
using EfEx.Domain;



namespace EfEx.Domain
{

    public class OmdbData
    {
        public char FilmId { get; set; }
        public char? Poster { get; set; }
        public char? Award { get; set; }
        public char? Plot { get; set; }


    }

}