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

        //[Authorization]
        //[HttpGet]
        //public IActionResult GetSearchHistory()
        //{
        //    var searchHistory = _dataService.GetSearchHistory();
        //    var model = searchHistory.Select(CreateSearchHistoryViewModel);
        //    return Ok(model);
        //}

        [Authorization]
        [HttpGet( Name = nameof(GetSearchHistoryByUserId))]
        public IActionResult GetSearchHistoryByUserId([FromQuery] QueryString queryString)
        {
            try {
                var user = Request.HttpContext.Items["User"] as User;
                var searchHistory = _dataService.GetSearchHistoryByUserId(user.UserId).Skip(queryString.Page * queryString.PageSize).Take(queryString.PageSize);
                var searches = searchHistory.Select(CreateSearchHistoryViewModel);
                if (searchHistory == null)
                {
                    return NotFound();
                }
                return Ok((CreateResultModel(queryString, _dataService.SearchHistoryCount(user.UserId), searches)));
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }


        
        [HttpDelete]
        public IActionResult DeleteSearchHistory()
        {
           
                var user = Request.HttpContext.Items["User"] as User;
                
                _dataService.DeleteSearchHistory(user.UserId);
               
                return NoContent();
            
        }


        

        private object CreateResultModel(QueryString queryString, int total, IEnumerable<SearchHistoryViewModel> model)
        {
            return new
            {
                total,
                prev = CreateNextPageLink(queryString),
                cur = CreateCurrentPageLink(queryString),
                next = CreateNextPageLink(queryString, total),
                searches = model
            };
        }

        private string CreateNextPageLink(QueryString queryString, int total)
        {
            var lastPage = GetLastPage(queryString.PageSize, total);
            return queryString.Page >= lastPage ? null : GetBestMatchSearchUrl(queryString.Page + 1, queryString.PageSize, queryString.OrderBy);
        }


        private string CreateCurrentPageLink(QueryString queryString)
        {
            return GetBestMatchSearchUrl(queryString.Page, queryString.PageSize, queryString.OrderBy);
        }

        private string CreateNextPageLink(QueryString queryString)
        {
            return queryString.Page <= 0 ? null : GetBestMatchSearchUrl(queryString.Page - 1, queryString.PageSize, queryString.OrderBy);
        }

        private string GetBestMatchSearchUrl(int page, int pageSize, string orderBy)
        {

            return _linkGenerator.GetUriByName(
                HttpContext,
                nameof(GetSearchHistoryByUserId),
                new { page, pageSize, orderBy });
        }

        private static int GetLastPage(int pageSize, int total)
        {
            return (int)Math.Ceiling(total / (double)pageSize) - 1;
        }

        private SearchHistoryViewModel CreateBestMatchSearchViewModel(SearchHistory searchHistory)
        {
            var model = _mapper.Map<SearchHistoryViewModel>(searchHistory);
            model.Url = GetSearchHistoryUrl(searchHistory);
            return model;
        }




        private SearchHistoryViewModel CreateSearchHistoryViewModel(SearchHistory searchHistory)
        {
            var model = _mapper.Map<SearchHistoryViewModel>(searchHistory);
            model.Url = GetSearchHistoryUrl(searchHistory);
            return model;

        }

        private string GetSearchHistoryUrl(SearchHistory searchHistory)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetSearchHistoryByUserId), new { searchHistory.FilmId });
        }

    }
}