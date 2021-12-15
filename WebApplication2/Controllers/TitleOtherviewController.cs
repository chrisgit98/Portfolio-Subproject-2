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
    [Route("api/moviedetails")]
    public class TitleOtherviewController : Controller

    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;


        public TitleOtherviewController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet("{s}", Name = nameof(GetMovieDetails))]
        public IActionResult GetMovieDetails(string s)
        {
            var titleOtherview = _dataService.GetTitleOtherview(s);

            if (titleOtherview == null)
            {
                return NotFound();
            }

            return Ok(titleOtherview);
        }

    }
}
