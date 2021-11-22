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
        [HttpGet("{userId}", Name = nameof(GetBookmarkPeopleByUserId))]
        public IActionResult GetBookmarkPeopleByUserId(int userId)
        {
           
            var bookmarkPeople = _dataService.GetBookmarkPeopleByUserId(userId);
            if (bookmarkPeople == null)
            {
                return NotFound();
            }
            return Ok(bookmarkPeople.Select(GetBookmarkPeopleViewModel));
        }


        [HttpDelete("{userId}/{personId}")]
        public IActionResult DeleteBookmarkPeople(int userId, string personId)
        {
           _dataService.DeleteBookmarkPeople(userId, personId);
            
            
            return NoContent();

        }

        [HttpPost("{post}")]

        public IActionResult CreateBookmarkPeople(BookmarkPeopleViewModel model)
        {
            var bookmarkPeople = _mapper.Map<BookmarkPeople>(model);

            _dataService.CreateBookmarkPeople(bookmarkPeople);

            return Created(GetUrl(bookmarkPeople), GetBookmarkPeopleViewModel(bookmarkPeople));
        }



        private BookmarkPeopleViewModel GetBookmarkPeopleViewModel(BookmarkPeople bookmarkPeople)
        {
            var model = _mapper.Map<BookmarkPeopleViewModel>(bookmarkPeople);
            model.Url = GetUrl(bookmarkPeople);
            model.PersonId = bookmarkPeople.PersonId;
            model.UserId = bookmarkPeople.UserId;
            return model;
        }
        private string GetUrl(BookmarkPeople bookmarkPeople)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(BookmarkPeople), new { bookmarkPeople.PersonId });
        }
    }

}
