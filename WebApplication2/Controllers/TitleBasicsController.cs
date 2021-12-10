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
    [Route("api/titlebasics")]
    public class TitleBasicsController : Controller

    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;


        public TitleBasicsController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet("{filmId}", Name = nameof(GetMovie))]
        public IActionResult GetMovie(string filmId)
        {
            var movie = _dataService.GetMovie(filmId);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(CreateTitleBasicsModel(movie));
        }

        private TitleBasicsViewModel CreateTitleBasicsModel(TitleBasics titleBasics)
        {
            var model = _mapper.Map<TitleBasicsViewModel>(titleBasics);
            model.Url = GetUrl(titleBasics); ;
            return model;
        }
        private string GetUrl(TitleBasics titleBasics)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetMovie), new { titleBasics.FilmId });
        }
    }
}
