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
    [Route("api/namedetails")]
    public class NameOtherviewController : Controller

    {
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;


        public NameOtherviewController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet("{personId}", Name = nameof(GetNameDetails))]
        public IActionResult GetNameDetails(string personId)
        {
            var nameOtherview = _dataService.GetNameOtherview(personId);

            if (nameOtherview == null)
            {
                return NotFound();
            }

            var model = CreateNameOtherViewViewModel(nameOtherview);
            return Ok(model);
        }

        private NameOtherviewViewModel CreateNameOtherViewViewModel(NameOtherview nameOtherview)
        {
            var model = _mapper.Map<NameOtherviewViewModel>(nameOtherview);
            model.Url = GetUrl(nameOtherview);
            return model;
        }

        private string GetUrl(NameOtherview nameOtherview)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(GetNameDetails), new { nameOtherview.PersonId });
        }
    }
}
