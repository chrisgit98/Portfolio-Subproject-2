using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EfEx;
using EfEx.Domain;


namespace WebService.ViewModels.Profiles
{
    public class SimilarMoviesProfile :Profile
    {
        public SimilarMoviesProfile()
        {
            CreateMap<SimilarMovies,SimilarMoviesViewModel>();
            CreateMap<CreateSimilarMoviesViewModel, SimilarMovies>();
        }
    }
}
