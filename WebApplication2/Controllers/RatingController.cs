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
using WebService.Models;
using WebService.Middleware;
using WebService.Attributes;


namespace WebService.Controllers
{
    [ApiController]
    [Route("api/ratingfunction")]
    public class RatingController : Controller
    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public RatingController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }


        //[Authorization]
        [HttpGet("{userId}/{t_id}/{u_rating}")]
        public IActionResult RateAMovie(int userId, string t_id, float u_rating)
        {
            var user = Request.HttpContext.Items["User"] as User;
            _dataService.RateAMovie(userId, t_id, u_rating);

            return Ok();
        }
    }
}
