using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EfEx.Domain;

namespace WebService.ViewModels.Profiles
{
    public class BookmarkTitleProfile : Profile

    {
        public BookmarkTitleProfile()
        {
            CreateMap<BookmarkTitle, BookmarkTitleViewModel>();
            //CreateMap<CreateBookmarkPeopleViewModel, BookmarkPeople>();
        }
    }
}
