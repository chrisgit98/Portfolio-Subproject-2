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

        [Authorization]
        [HttpGet]
        public IActionResult GetSearchHistory()
        {
            var searchHistory = _dataService.GetSearchHistory();
            var model = searchHistory.Select(CreateSearchHistoryViewModel);
            return Ok(model);
        }

        [Authorization]
        [HttpGet("{userId}", Name = nameof(GetSearchHistoryByUserId))]
        public IActionResult GetSearchHistoryByUserId(int userId)
        {
            try {
                var user = Request.HttpContext.Items["User"] as User;
                var searchHistory = _dataService.GetSearchHistoryByUserId(user.UserId);
                if (searchHistory == null)
                {
                    return NotFound();
                }
                return Ok(searchHistory.Select(CreateSearchHistoryViewModel));
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }



        [HttpDelete("{userId}/{filmId}")]
        public IActionResult DeleteSearchHistory(int userId, string filmId)
        {
            if (!_dataService.DeleteSearchHistory(userId, filmId))
            {
                return NotFound();
            }

            return NoContent();
        }


        private SearchHistoryViewModel CreateSearchHistoryViewModel(SearchHistory searchHistory)
        {
            var model = _mapper.Map<SearchHistoryViewModel>(searchHistory);
            model.Url = GetUrl(searchHistory);          
            return model;

        }   
        
        private string GetUrl(SearchHistory searchHistory)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetSearchHistoryByUserId), new { searchHistory.UserId });
        }



    }
}