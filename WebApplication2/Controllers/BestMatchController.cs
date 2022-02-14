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
    [Route("api/bestmatch")]
    public class BestMatchController : Controller

    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;


        public BestMatchController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [Authorization]
        [HttpGet("{s}", Name = nameof(BestMatch))]

        public IActionResult BestMatch(string s, [FromQuery] QueryString queryString)
        {
            try
            {
                var user = Request.HttpContext.Items["User"] as User;
                var bestMatchSearch = _dataService.BestMatchSearch(s).Skip(queryString.Page * queryString.PageSize).Take(queryString.PageSize);
                var searchHisttory = new SearchHistory(user.UserId, s, DateTime.Now);
                _dataService.CreateSearchHistory(searchHisttory);

                var movies = bestMatchSearch.Select(CreateBestMatchSearchListViewModel);


                if (bestMatchSearch == null)
                {
                    return NotFound();
                }
                return Ok(CreateResultModel(queryString, _dataService.BestMatchSearchCount(s), movies, s));
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        private object CreateResultModel(QueryString queryString, int total, IEnumerable<BestMatchSearchViewModel> model, string s)
        {
            return new
            {
                total,
                prev = CreateNextPageLink(queryString, s),
                cur = CreateCurrentPageLink(queryString, s),
                next = CreateNextPageLink(queryString, total, s),
                movies = model
            };
        }

        private string CreateNextPageLink(QueryString queryString, int total, string s)
        {
            var lastPage = GetLastPage(queryString.PageSize, total);
            return queryString.Page >= lastPage ? null : GetBestMatchSearchUrl(queryString.Page + 1, queryString.PageSize, queryString.OrderBy, s);
        }


        private string CreateCurrentPageLink(QueryString queryString, string s)
        {
            return GetBestMatchSearchUrl(queryString.Page, queryString.PageSize, queryString.OrderBy, s);
        }

        private string CreateNextPageLink(QueryString queryString, string s)
        {
            return queryString.Page <= 0 ? null : GetBestMatchSearchUrl(queryString.Page - 1, queryString.PageSize, queryString.OrderBy, s);
        }

        private string GetBestMatchSearchUrl(int page, int pageSize, string orderBy, string s)
        {
            
            return _linkGenerator.GetUriByName(
                HttpContext,
                nameof(BestMatch),
                new { page, pageSize, orderBy, s });
        }

        private static int GetLastPage(int pageSize, int total)
        {
            return (int)Math.Ceiling(total / (double)pageSize) - 1;
        }

        private BestMatchSearchViewModel CreateBestMatchSearchViewModel(BestMatchSearch bestMatchSearch)
        {
            var model = _mapper.Map<BestMatchSearchViewModel>(bestMatchSearch);
            model.Url = GetBestMatchSearchUrl(bestMatchSearch);
            return model;
        }




        private BestMatchSearchViewModel CreateBestMatchSearchListViewModel(BestMatchSearch bestMatchSearch)
        {
            var model = _mapper.Map<BestMatchSearchViewModel>(bestMatchSearch);
            model.Url = GetBestMatchSearchUrl(bestMatchSearch);
            return model;
        }

        private string GetBestMatchSearchUrl(BestMatchSearch bestMatchSearch)
        {

            //var test = _linkGenerator.GetUriByName(HttpContext, nameof(TitleBasicsController.GetMovie), new { bestMatchSearch.FilmId });
            return "http://localhost:5000/api/moviedetails/" + bestMatchSearch.FilmId;
        }
    }



}

