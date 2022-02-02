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

        [Authorization]
        [HttpGet(Name = nameof(GetRatingHistoryByUserId))]
        public IActionResult GetRatingHistoryByUserId()
        {
            try { 
                var user = Request.HttpContext.Items["User"] as User;
                var movieRating = _dataService.GetRatingHistoryByUserId(user.UserId);
                if (movieRating == null)
                {
                    return NotFound();
                }
                return Ok(movieRating.Select(CreateMovieRatingViewModel));

            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        private RatingHistoryViewModel CreateMovieRatingViewModel(RatingHistory ratingHistory)
        {
            var model = _mapper.Map<RatingHistoryViewModel>(ratingHistory);
            model.Url = GetUrl(ratingHistory);
            model.FilmId = ratingHistory.FilmId;
            model.UserId = ratingHistory.UserId;
            model.Rating = ratingHistory.Rating;
            return model;
        }
        private string GetUrl(RatingHistory ratingHistory)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetRatingHistoryByUserId), new { ratingHistory.UserId });
        }
    }
}
