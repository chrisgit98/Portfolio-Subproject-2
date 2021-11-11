using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfEx;
using EfEx.Domain;



namespace EfEx.Domain
{

    public class TitleEpisode
    {
        public char FilmId { get; set; }
        public char? ParentTconst { get; set; }
        public int? SeasonNumber { get; set; }
        public int? EpisodeNumber { get; set; }
        public string EpisodeName { get; set; }


    }

}