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
using WebService.Attributes;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/movierating")]
    public class MovieRatingController : Controller

    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;


        public MovieRatingController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet("{userId}", Name = nameof(GetRatingHistoryByUserId))]
        public IActionResult GetRatingHistoryByUserId(int userId)
        {

            var ratingHistory = _dataService.GetRatingHistoryByUserId(userId);
            if (ratingHistory == null)
            {
                return NotFound();
            }
            return Ok(ratingHistory);
        }

        [Authorization]
        [HttpPost]
        public IActionResult RateAMovie(MovieRating data)
        {
            var user = Request.HttpContext.Items["User"] as User;
            data.UserId = user.UserId;
            _dataService.RateAMovie(data);
            
            return Ok();
        }

        private MovieRatingViewModel CreateMovieRatingViewModel(MovieRating movieRating)
        {
            var model = _mapper.Map<MovieRatingViewModel>(movieRating);
            //model.Url = GetUrl(movieRating);
            //model.FilmId = movieRating.FilmId;
            //model.UserId = movieRating.UserId;
            return model;
        }
        private string GetUrl(RatingHistory ratingHistory)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetRatingHistoryByUserId), new { ratingHistory.UserId });
        }
    }
}
