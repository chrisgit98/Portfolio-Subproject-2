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
    [Route("api/StringSearch")]
    public class StringSearchController : Controller

    { 
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;


        public StringSearchController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        //[HttpGet("{id}", Name = nameof(GetMovie))]
        //public IActionResult GetMovie(string id)
        //{
        //    var movie = _dataService.GetMovie(id);

        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(TitleBasicsViewModel(movie));
        //}

        [HttpGet("{s}", Name = nameof(StringSearch1))]

        public IActionResult StringSearch1(string s, [FromQuery] QueryString queryString)
        {
            var stringSearch = _dataService.StringSearch(s);
            //var searchHisttory = new SearchHistory(12345678, s, DateTime.Now);
            //_dataService.CreateSearchHistory(searchHisttory);

            var movies = stringSearch.Select(CreateStringSearchListViewModel);


            if (stringSearch == null)
            {
                return NotFound();
            }
            return Ok(CreateResultModel(queryString, _dataService.StringSearchCount(s), movies, s));
        }

        private object CreateResultModel(QueryString queryString, int total, IEnumerable<StringSearchViewModel> model, string s)
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
            return queryString.Page >= lastPage ? null : GetStringSearchUrl(queryString.Page + 1, queryString.PageSize, queryString.OrderBy,  s);
        }


        private string CreateCurrentPageLink(QueryString queryString, string s)
        {
            return GetStringSearchUrl(queryString.Page, queryString.PageSize, queryString.OrderBy, s);
        }

        private string CreateNextPageLink(QueryString queryString, string s)
        {
            return queryString.Page <= 0 ? null : GetStringSearchUrl(queryString.Page - 1, queryString.PageSize, queryString.OrderBy,  s);
        }

        private string GetStringSearchUrl(int page, int pageSize, string orderBy, string s)
        {
            return "http://localhost:5000/api/StringSearch/" + s +"?page=" + page + "&pageSize=" +pageSize;
            //return _linkGenerator.GetUriByName(
            //    HttpContext,
            //    nameof(StringSearch1),
            //    new { page, pageSize, orderBy });
        }

        private static int GetLastPage(int pageSize, int total)
        {
            return (int)Math.Ceiling(total / (double)pageSize) - 1;
        }

        private StringSearchViewModel CreateStringSearchViewModel(StringSearch stringSearch)
        {
            var model = _mapper.Map<StringSearchViewModel>(stringSearch);
            model.Url = GetStringSearchUrl(stringSearch);
            return model;
        }




        private StringSearchViewModel CreateStringSearchListViewModel( StringSearch stringSearch)
        {
            var model = _mapper.Map<StringSearchViewModel>(stringSearch);
            model.Url = GetStringSearchUrl(stringSearch);
            return model;
        }

        private string GetStringSearchUrl(StringSearch stringSearch)
        {
        
            //var test = _linkGenerator.GetUriByName(HttpContext, nameof(TitleBasicsController.GetMovie), new { stringSearch.Tconst });
            return "http://localhost:5000/api/titlebasics/" +stringSearch.Tconst;
        }
    }



}
