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
    [Route("api/sss")]
    public class StructuredStringSearchController : Controller

    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;


        public StructuredStringSearchController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet("{s}/{s1}/{s2}/{s3}", Name = nameof(StructuredStringSearch))]


        public IActionResult StructuredStringSearch(string s,string s1,string s2, string s3)
        {
            var structuredString = _dataService.StructuredStringSearches(s, s1, s2, s3).Select(CreateStructuredStringViewModel);
            if (structuredString == null)
            {
                return NotFound();
            }

            var result = new
            {
                items = structuredString
            };

            return Ok(result);

        }

        private StructuresStringSearchViewModel CreateStructuredStringViewModel(StructuredStringSearch structuredStringSearch)
        {
            var model = _mapper.Map<StructuresStringSearchViewModel>(structuredStringSearch);
            model.Url = GetUrl(structuredStringSearch); ;
            return model;
        }
        private string GetUrl(StructuredStringSearch structuredStringSearch)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(StructuredStringSearch), new { structuredStringSearch.Title });
        }
    }
}
