using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EfEx.Domain;

namespace WebService.ViewModels.Profiles
{
    public class RatingHistoryProfile : Profile

    {
        public RatingHistoryProfile()
        {
            CreateMap<RatingHistory, RatingHistoryViewModel>();
        }
    }
}