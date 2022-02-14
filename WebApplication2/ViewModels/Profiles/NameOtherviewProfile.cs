using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EfEx.Domain;

namespace WebService.ViewModels.Profiles
{
    public class NameOtherviewProfile : Profile

    {
        public NameOtherviewProfile()
        {
            CreateMap<NameOtherview, NameOtherviewViewModel>();
            //CreateMap<CreateBookmarkPeopleViewModel, BookmarkPeople>();
        }
    }
}
