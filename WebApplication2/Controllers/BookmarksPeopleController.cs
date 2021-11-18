using System.Linq;
using AutoMapper;
using EfEx;
using EfEx.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WebService.ViewModels;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using WebService.ViewModels.Profiles;
//using WebApplication2.ViewModels;

namespace WebService.Controllers
{
    [ApiController]
    [Route ("api/BookmarkPeople")]
    public class BookmarkPeopleController : Controller
    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public BookmarkPeopleController (IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }
        [HttpGet("{userId}",Name =nameof (GetBookmarkPeople))]

        public IActionResult GetBookmarkPeople(string userId)
        {
            if (userId == null)
            {
                return NotFound();
            }
            BookmarkPeople bookmarkPeople = new BookmarkPeople()
            {
                UserId = userId
            };
            BookmarkPeopleViewModel model = GetBookmarkPeopleViewModel(bookmarkPeople);

            return Ok(model);
        }


        private BookmarkPeopleViewModel GetBookmarkPeopleViewModel(BookmarkPeople bookmarkPeople)
        {
            var model = _mapper.Map<BookmarkPeopleViewModel>(bookmarkPeople);
            model.URL = GetUrl(bookmarkPeople);
            return model;
        }
        private string GetUrl(BookmarkPeople bookmarkPeople)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetBookmarkPeople), new { bookmarkPeople.UserId });
        }
    }
}
