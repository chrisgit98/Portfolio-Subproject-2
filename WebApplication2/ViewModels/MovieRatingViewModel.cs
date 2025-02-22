﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.ViewModels
{
    public class MovieRatingViewModel
    {
        public string Url { get; set; }
        public int UserId { get; set; }
        public string FilmId { get; set; }
        public float? GivenRate { get; set; }
    }
}
