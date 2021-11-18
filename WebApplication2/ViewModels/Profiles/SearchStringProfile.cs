using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfEx.Domain;
using AutoMapper;
using EfEx;

namespace WebService.ViewModels.Profiles
{
    public class SearchStringProfile : Profile
    {
        public SearchStringProfile()
        {
            CreateMap<StringSearch, SearchStringViewModel>();
            CreateMap<CreateSearchStringViewModel, StringSearch>();
        }
    }
}
