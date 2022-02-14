using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EfEx;
using EfEx.Domain;


namespace WebService.ViewModels.Profiles
{
    public class NameSearchProfile : Profile
    {
        public NameSearchProfile()
        {
            CreateMap<NameSearch, NameSearchViewModel>();
            //CreateMap<CreateSimilarMoviesViewModel, SimilarMovies>();
        }
    }
}
