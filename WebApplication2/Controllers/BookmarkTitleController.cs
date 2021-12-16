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
    [Route("api/BookmarkTitle")]
    public class BookmarkTitleController : Controller
    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public BookmarkTitleController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBookmarksTitle()
        {
            var bookmarkTitle = _dataService.GetBookmarksTitle();
            var model = bookmarkTitle.Select(CreateBookmarkTitleViewModel);
            return Ok(model);
        }

        [HttpGet("{userId}", Name = nameof(GetBookmarkTitleByUserId))]
        public IActionResult GetBookmarkTitleByUserId(int userId)
        {

            var bookmarkTitle = _dataService.GetBookmarkTitleByUserId(userId);
            if (bookmarkTitle == null)
            {
                return NotFound();
            }
            return Ok(bookmarkTitle.Select(CreateBookmarkTitleViewModel));
        }

        [Authorization]
        [HttpDelete("{filmId}")]
        public IActionResult DeleteBookmarkTitle(string filmId)
        {
            try
            {
                var user = Request.HttpContext.Items["User"] as User;
                _dataService.DeleteBookmarkTitle(user.UserId, filmId.Trim());


                return NoContent();
            }
            catch(Exception)
            {
                return Unauthorized();
            }

        }

        [Authorization]
        [HttpPost]

        public IActionResult CreateBookmarkTitle(CreateBookmarkTitleViewModel model)
        {
            try
            {
                var user = Request.HttpContext.Items["User"] as User;
                model.UserId = user.UserId;
                var bookmarkTitle = _mapper.Map<BookmarkTitle>(model);
                Console.WriteLine("here" + bookmarkTitle);
                _dataService.CreateBookmarkTitle(bookmarkTitle);

                return Created(GetUrl(bookmarkTitle), CreateBookmarkTitleViewModel(bookmarkTitle));

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return Unauthorized();
            }
        }



        private BookmarkTitleViewModel CreateBookmarkTitleViewModel(BookmarkTitle bookmarkTitle)
        {
            var model = _mapper.Map<BookmarkTitleViewModel>(bookmarkTitle);
            model.Url = GetUrl(bookmarkTitle);
            model.FilmId = bookmarkTitle.FilmId;
            model.UserId = bookmarkTitle.UserId;
            return model;
        }
        private string GetUrl(BookmarkTitle bookmarkTitle)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetBookmarkTitleByUserId), new { bookmarkTitle.UserId });
        }
    }

}
