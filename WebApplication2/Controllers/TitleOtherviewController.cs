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

        [HttpGet("{filmId}", Name = nameof(GetMovieDetails))]
        public IActionResult GetMovieDetails(string s)
        {
            var titleOtherview = _dataService.GetTitleOtherview(s);

            if (titleOtherview == null)
            {
                return NotFound();
            }

            return Ok(titleOtherview.Select(CreateTitleOtherviewModel));
        }

        private TitleOtherViewViewModel CreateTitleOtherviewModel(TitleOtherview titleOtherview)
        {
            var model = _mapper.Map<TitleOtherViewViewModel>(titleOtherview);
            model.Url = GetUrl(titleOtherview); ;
            return model;
        }
        private string GetUrl(TitleOtherview titleOtherview)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetMovieDetails), new { titleOtherview.Title });
        }
    }
}
