﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.ViewModels
{
    public class BestMatchSearchViewModel
    {
        public string Url { get; set; }

        public string FilmId { get; set; }
        public float Ranking { get; set; }
        public string Title { get; set; }
    }
}
