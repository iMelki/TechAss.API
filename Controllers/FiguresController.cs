using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechAss.API.Data;
using TechAss.API.DataTransferObjects;
using TechAss.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TechAss.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FiguresController : ControllerBase
    {
        private readonly IFiguresRepository _figRep;
        public FiguresController(IFiguresRepository figRep)
        {
            _figRep = figRep;
        }

        // GET api/figures
        [HttpGet]
        public async Task<IActionResult> GetFigures()
        {
            List<Figure> figures = await _figRep.GetFigures();
            figures.Reverse();
            return Ok(figures);
        }

        // POST api/figures/register{'Beyonce', 'http:..'}

        [HttpPost("register")]
        public async Task<IActionResult> LookupAndRegister(FigureForRegisterDto figureForRegisterDto)
        {
            //TODO: lookup for instagram link
            string url = "http://beyonce.instagram.com/";
            //TODO: validate it
            var figureToCreate = new Figure
            {
                Name = figureForRegisterDto.Name,
                Url = url
            };

            var createdFigure = await _figRep.Register(figureToCreate);

            return Ok(new{
                url = createdFigure.Url
            });
        }
    }
}
