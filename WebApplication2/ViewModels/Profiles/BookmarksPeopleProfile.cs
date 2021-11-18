using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;


namespace WebService.ViewModels.Profiles
{
    public class BookmarkPeopleProfile : Profile

    {
        public BookmarkPeopleProfile()
        {
            CreateMap<BookmarkPeopleProfile,BookmarkPeopleViewModel> ();
            CreateMap<CreateBookmarkPeopleViewModel, BookmarkPeopleProfile>();
        }
    }
}
