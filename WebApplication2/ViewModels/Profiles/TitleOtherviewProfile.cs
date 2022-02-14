using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EfEx.Domain;

namespace WebService.ViewModels.Profiles
{
    public class TitleOtherviewProfile : Profile

    {
        public TitleOtherviewProfile()
        {
            CreateMap<TitleOtherview, TitleOtherViewViewModel>();
            //CreateMap<CreateBookmarkPeopleViewModel, BookmarkPeople>();
        }
    }
}
