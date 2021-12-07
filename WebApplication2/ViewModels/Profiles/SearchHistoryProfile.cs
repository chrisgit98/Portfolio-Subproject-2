using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EfEx;
using EfEx.Domain;

namespace WebService.ViewModels.Profiles
{
    public class SearchHistoryProfile : Profile
    {
        public SearchHistoryProfile()
        {
            CreateMap<SearchHistory, SearchHistoryViewModel>();
            CreateMap<CreateSearchHistoryViewModel, SearchHistory>();
        }
    }
}