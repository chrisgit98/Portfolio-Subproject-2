﻿using System.Linq;
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
using WebService.Models;
using WebService.Middleware;
using WebService.Attributes;
namespace WebService.Controllers
{
    [ApiController]
    [Route("api/namesearch")]
    public class NameSearchController : Controller

    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;


        public NameSearchController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [Authorization]
        [HttpGet("{s}", Name = nameof(SearchNames))]

        public IActionResult SearchNames(string s, [FromQuery] QueryString queryString)
        {
            try {
                var user = Request.HttpContext.Items["User"] as User;
                var nameSearch = _dataService.NameSearch(s).Skip(queryString.Page * queryString.PageSize).Take(queryString.PageSize);
                var searchHisttory = new SearchHistory(user.UserId, s, DateTime.Now);
                _dataService.CreateSearchHistory(searchHisttory);

                var names = nameSearch.Select(CreateNameSearchListViewModel);


            if (nameSearch == null)
            {
                return NotFound();
            }
            return Ok(CreateResultModel(queryString, _dataService.NameSearchCount(s), names, s));
            }

            catch(Exception)
            {
                return Unauthorized();
            }

        }


        private object CreateResultModel(QueryString queryString, int total, IEnumerable<NameSearchViewModel> model, string s)
        {
            return new
            {
                total,
                prev = CreateNextPageLink(queryString, s),
                cur = CreateCurrentPageLink(queryString, s),
                next = CreateNextPageLink(queryString, total, s),
                names = model
            };
        }

        private string CreateNextPageLink(QueryString queryString, int total, string s)
        {
            var lastPage = GetLastPage(queryString.PageSize, total);
            return queryString.Page >= lastPage ? null : GetNameSearchUrl(queryString.Page + 1, queryString.PageSize, queryString.OrderBy, s);
        }


        private string CreateCurrentPageLink(QueryString queryString, string s)
        {
            return GetNameSearchUrl(queryString.Page, queryString.PageSize, queryString.OrderBy, s);
        }

        private string CreateNextPageLink(QueryString queryString, string s)
        {
            return queryString.Page <= 0 ? null : GetNameSearchUrl(queryString.Page - 1, queryString.PageSize, queryString.OrderBy, s);
        }

        private string GetNameSearchUrl(int page, int pageSize, string orderBy, string s)
        {

            return _linkGenerator.GetUriByName(
                HttpContext,
                nameof(SearchNames),
                new { page, pageSize, orderBy, s });
        }

        private static int GetLastPage(int pageSize, int total)
        {
            return (int)Math.Ceiling(total / (double)pageSize) - 1;
        }

        private NameSearchViewModel CreateNameSearchViewModel(NameSearch nameSearch)
        {
            var model = _mapper.Map<NameSearchViewModel>(nameSearch);
            model.Url = GetNameSearchUrl(nameSearch);
            return model;
        }




        private NameSearchViewModel CreateNameSearchListViewModel(NameSearch nameSearch)
        {
            var model = _mapper.Map<NameSearchViewModel>(nameSearch);
            model.Url = GetNameSearchUrl(nameSearch);
            return model;
        }

        private string GetNameSearchUrl(NameSearch nameSearch)
        {

            //var test = _linkGenerator.GetUriByName(HttpContext, nameof(TitleBasicsController.GetMovie), new { stringSearch.Tconst });
            return "http://localhost:5000/api/namedetails/" + nameSearch.PersonId;
        }
    }



}

