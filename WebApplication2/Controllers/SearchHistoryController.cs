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
    [Route("api/searchhistory")]
    public class SearchHistoryController : Controller
    {



        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;



        public SearchHistoryController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }


        
        [HttpGet("{userId}")]
        public IActionResult GetSearchHistoryByUserId(int userId)
        {
            var searchHistory = _dataService.GetSearchHistoryByUserId(userId);
            if (searchHistory == null)
            {
                return NotFound();
            }
            return Ok(searchHistory.Select(CreateSearchHistoryViewModel));
        }



        [HttpDelete("{userId}")]
        public IActionResult DeleteSearchHistory(int userId)
        {
            if (!_dataService.DeleteSearchHistory(userId))
            {
                return NotFound();
            }

            return NoContent();

        }

        private SearchHistoryViewModel CreateSearchHistoryViewModel(SearchHistory searchHistory)
        {
            return new SearchHistoryViewModel
            {
                Url = Url.Link(nameof(GetSearchHistoryByUserId), new { filmId = searchHistory.FilmId }),
                FilmId = searchHistory.FilmId,
                Date = searchHistory.Date
            };

        }   
        


        private string GetUrl(SearchHistory searchHistory)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(SearchHistory), new { searchHistory.UserId });
        }



    }
}