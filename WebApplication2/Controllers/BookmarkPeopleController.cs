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
using System.Collections.Generic;



namespace WebService.Controllers
{
    [ApiController]
    [Route("api/BookmarkPeople")]
    public class BookmarkPeopleController : Controller
    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public BookmarkPeopleController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }
        [HttpGet("{userId}/{personId}", Name = nameof(GetBookmarkPeopleByUserId))]
        public IActionResult GetBookmarkPeopleByUserId(int userId,string personId)
        {
            //if (userId == null)
            //{
            //    return NotFound();
            //}
            //BookmarkPeople bookmarkPeople = new BookmarkPeople()
            //{
            //    UserId = userId
            //};
            //BookmarkPeopleViewModel model = GetBookmarkPeopleViewModel(bookmarkPeople);

            //return Ok(model);

            var bookmarkPeople = _dataService.GetBookmarkPeopleByUserId(userId,personId);
            if (bookmarkPeople == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<BookmarkPeopleViewModel>(bookmarkPeople));
        }


        [HttpPost]

        public IActionResult CreateBookmarkPeople(CreateBookmarkPeopleViewModel model)
        {
            var bookmarkPeople = _mapper.Map<BookmarkPeople>(model);
            _dataService.CreateBookmarkPeople(bookmarkPeople);
            return Created("", bookmarkPeople);
        }



        private BookmarkPeopleViewModel GetBookmarkPeopleViewModel(BookmarkPeople bookmarkPeople)
        {
            var model = _mapper.Map<BookmarkPeopleViewModel>(bookmarkPeople);
            model.URL = GetUrl(bookmarkPeople);
            return model;
        }
        private string GetUrl(BookmarkPeople bookmarkPeople)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(BookmarkPeople), new { bookmarkPeople.UserId });
        }
    }
}
