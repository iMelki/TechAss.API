using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechAss.API.Data;
using TechAss.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TechAss.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FiguresController : ControllerBase
    {
        private readonly DataContext _context;
        public FiguresController(DataContext context)
        {
            _context = context;

        }
        // GET api/figures
        [HttpGet]
        public async Task<IActionResult> GetFigures()
        {
            List<Figure> figures = await _context.Figures.ToListAsync();
            return Ok(figures);
        }

        // PUT api/figures/Beyonce
        [HttpPut("{name}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
