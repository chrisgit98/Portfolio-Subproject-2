using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EfEx.Domain;

namespace WebService.ViewModels.Profiles
{
    public class MovieRatingProfile : Profile

    {
        public MovieRatingProfile()
        {
            CreateMap<MovieRating, MovieRatingViewModel>();
            CreateMap<CreateMovieRatingViewModel, BookmarkPeople>();
        }
    }
}
