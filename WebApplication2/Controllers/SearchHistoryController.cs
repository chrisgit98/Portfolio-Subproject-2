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

        [HttpGet]
        public IActionResult GetSearchHistory()
        {
            var searchHistory = _dataService.GetSearchHistory();
            var model = searchHistory.Select(CreateSearchHistoryViewModel);
            return Ok(model);
        }

        //[HttpGet("{id}", Name = nameof(GetSearchHistory))]
        //public IActionResult GetSearchHistory(int id)
        //{
        //    var category = _dataService.GetCategory(id);

        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    var model = CreateCategoryViewModel(category);

        //    return Ok(model);
        //}

        //[HttpPost]
        //public IActionResult CreateCategory(CreateCategoryViewModel model)
        //{
        //    var category = _mapper.Map<Category>(model);

        //    _dataService.CreateCategory(category);

        //    return Created(GetUrl(category), CreateCategoryViewModel(category));
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteCategory(int id)
        //{
        //    if (!_dataService.DeleteCategory(id))
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}

        //[HttpPut("{id}")]
        //public IActionResult UpdateCategory(int id, CreateCategoryViewModel model)
        //{
        //    var category = _mapper.Map<Category>(model);
        //    category.Id = id;

        //    if (!_dataService.UpdateCategory(category))
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}


        private SearchHistoryViewModel CreateSearchHistoryViewModel(SearchHistory searchHistory)
        {
            var model = _mapper.Map<SearchHistoryViewModel>(searchHistory);
            model.Url = GetUrl(searchHistory);
            return model;
        }

        private string GetUrl(SearchHistory searchHistory)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetSearchHistory), new { searchHistory.UserId });
        }
    }
}