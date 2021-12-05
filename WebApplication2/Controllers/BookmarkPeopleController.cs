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
        [HttpGet]
        public IActionResult GetBookmarksPeople()
        {
            var bookmarkPeople = _dataService.GetBookmarksPeople();
            var model = bookmarkPeople.Select(CreateBookmarkPeopleViewModel);
            return Ok(model);
        }

        [HttpGet("{userId}", Name = nameof(GetBookmarkPeopleByUserId))]
        public IActionResult GetBookmarkPeopleByUserId(int userId)
        {
           
            var bookmarkPeople = _dataService.GetBookmarkPeopleByUserId(userId);
            if (bookmarkPeople == null)
            {
                return NotFound();
            }
            return Ok(bookmarkPeople.Select(CreateBookmarkPeopleViewModel));
        }


        [HttpDelete("{userId}/{personId}")]
        public IActionResult DeleteBookmarkPeople(int userId, string personId)
        {
           //_dataService.DeleteBookmarkPeople(userId, personId);

            if (!_dataService.DeleteBookmarkPeople(userId, personId)) return NotFound() ;
            
            return NoContent();

        }

        [HttpPost("{post}")]

        public IActionResult CreateBookmarkPeople(BookmarkPeopleViewModel model)
        {
            var bookmarkPeople = _mapper.Map<BookmarkPeople>(model);

            _dataService.CreateBookmarkPeople(bookmarkPeople);

            return Created(GetUrl(bookmarkPeople), CreateBookmarkPeopleViewModel(bookmarkPeople));
        }



        private BookmarkPeopleViewModel CreateBookmarkPeopleViewModel(BookmarkPeople bookmarkPeople)
        {
            var model = _mapper.Map<BookmarkPeopleViewModel>(bookmarkPeople);
            model.Url = GetUrl(bookmarkPeople);
            //model.PersonId = bookmarkPeople.PersonId;
            //model.UserId = bookmarkPeople.UserId;
            return model;
        }
        private string GetUrl(BookmarkPeople bookmarkPeople)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetBookmarkPeopleByUserId),  new {  bookmarkPeople.UserId } );
        }
    }

}
