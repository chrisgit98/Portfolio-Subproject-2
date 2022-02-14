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
    [Route("api/SimilarMovies")]
    public class SimilarMoviesController : Controller

    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;


        public SimilarMoviesController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet("{filmId}", Name = nameof(SimilarMovies))]


        public IActionResult SimilarMovies(string filmId)
        {
            var similarMovies = _dataService.SimilarMovies(filmId);
            if (similarMovies == null)
            {
                return NotFound();
            }
            return Ok(similarMovies.Select(CreateSimilarMoviesViewModel));
        }

        private SimilarMoviesViewModel CreateSimilarMoviesViewModel(SimilarMovies similarMovies)
        {
            var model = _mapper.Map<SimilarMoviesViewModel>(similarMovies);
            model.Url = GetUrl(similarMovies); ;
            return model;
        }
        private string GetUrl(SimilarMovies similarMovies)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(SimilarMovies), new { similarMovies.Title });
        }
    }
}
