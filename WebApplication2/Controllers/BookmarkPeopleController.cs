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
using WebService.Attributes;


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
        [Authorization]
        [HttpGet]
        public IActionResult GetBookmarksPeople()
        {
            try
            {
                var user = Request.HttpContext.Items["User"] as User;

                var bookmarkPeople = _dataService.GetBookmarkPeopleByUserId(user.UserId);
                var model = bookmarkPeople.Select(CreateBookmarkPeopleViewModel);
                return Ok(model);

            }
            catch(Exception)
            {
                return Unauthorized();
            }
        }

        [Authorization]
        [HttpGet("{userId}", Name = nameof(GetBookmarkPeopleByUserId))]
        public IActionResult GetBookmarkPeopleByUserId()
        {
            try {
                var user = Request.HttpContext.Items["User"] as User;
                var bookmarkPeople = _dataService.GetBookmarkPeopleByUserId(user.UserId);
                if (bookmarkPeople == null)
                {
                    return NotFound();
                }
                return Ok(bookmarkPeople.Select(CreateBookmarkPeopleViewModel));
            }
            catch(Exception)
            {
                return Unauthorized();
            }
        }

        [Authorization]
        [HttpDelete("{personId}")]
        public IActionResult DeleteBookmarkPeople( string personId)
        {
            try
            {
                var user = Request.HttpContext.Items["User"] as User;
                _dataService.DeleteBookmarkPeople(user.UserId, personId);

                return NoContent();
            }
            catch(Exception)
            {
                 return Unauthorized();
            }
        }

        [Authorization]
        [HttpPost]
        public IActionResult CreateBookmarkPeople(CreateBookmarkPeopleViewModel model)
        {
            try
            {
                var user = Request.HttpContext.Items["User"] as User;
                model.UserId = user.UserId;
                var bookmarkPeople = _mapper.Map<BookmarkPeople>(model);

                _dataService.CreateBookmarkPeople(bookmarkPeople);

                return Created(GetUrl(bookmarkPeople), CreateBookmarkPeopleViewModel(bookmarkPeople));

            }
            catch(Exception)
            {
                return Unauthorized();
            }
        }



        private BookmarkPeopleViewModel CreateBookmarkPeopleViewModel(BookmarkPeople bookmarkPeople)
        {
            var model = _mapper.Map<BookmarkPeopleViewModel>(bookmarkPeople);
            model.Url = GetUrl(bookmarkPeople);
            model.PersonId = bookmarkPeople.PersonId;
            model.UserId = bookmarkPeople.UserId;
            return model;
        }
        private string GetUrl(BookmarkPeople bookmarkPeople)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetBookmarkPeopleByUserId),  new {  bookmarkPeople.UserId } );
        }
    }

}
