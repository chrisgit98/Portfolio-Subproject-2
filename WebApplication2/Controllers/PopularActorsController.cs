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
    [Route("api/PopularActors")]
    public class PopularActorsController : Controller

    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;


        public PopularActorsController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet("{filmId}")]


        public IActionResult PopularActors(string filmId)
        {
            var popularActors = _dataService.PopularActors(filmId);
            if (popularActors == null)
            {
                return NotFound();
            }
            return Ok(popularActors.Select(CreatePopularsActorsViewModel));
        }

        private PopularActorsViewModel CreatePopularsActorsViewModel(PopularActors popularActors)
        {
            var model = _mapper.Map<PopularActorsViewModel>(popularActors);
            model.Url = GetUrl(popularActors);
            return model;
        }

        private string GetUrl(PopularActors popularActors)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(PopularActors), new { popularActors.Name});
        }
    }
}
