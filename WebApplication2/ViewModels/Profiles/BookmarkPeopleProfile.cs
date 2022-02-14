using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EfEx.Domain;

namespace WebService.ViewModels.Profiles
{
    public class BookmarkPeopleProfile : Profile

    {
        public BookmarkPeopleProfile()
        {
            CreateMap<BookmarkPeople,BookmarkPeopleViewModel> ();
            CreateMap<CreateBookmarkPeopleViewModel, BookmarkPeople>();
        }
    }
}
