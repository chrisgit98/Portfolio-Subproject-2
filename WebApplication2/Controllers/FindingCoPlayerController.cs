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
    [Route("api/FindingCoPlayer")]
    public class FindingCoPlayerController : Controller

    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;


        public FindingCoPlayerController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet("{s}")]


        public IActionResult FindingCoPlayers(string s)
        {
            var findingCoPlayers = _dataService.FindingCoPlayers(s);
            if (findingCoPlayers == null)
            {
                return NotFound();
            }
            return Ok(findingCoPlayers);
        }
    }
}
