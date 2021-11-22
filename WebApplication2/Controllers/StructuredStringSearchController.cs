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

        [HttpGet("{s}/{s1}/{s2}/{s3}")]


        public IActionResult StructuredStringSearch(string s,string s1,string s2, string s3)
        {
            var structuredString = _dataService.StructuredStringSearches(s,s1,s2,s3);
            if (structuredString == null)
            {
                return NotFound();
            }
            return Ok(structuredString);
        }
    }
}
