using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechAss.API.Models;
using Microsoft.EntityFrameworkCore;

namespace TechAss.API.Data
{
    public class FiguresRepository : IFiguresRepository
    {
        private readonly DataContext _context;

        public FiguresRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Figure> Register(Figure figure)
        {
            await _context.Figures.AddAsync(figure);
            await _context.SaveChangesAsync();

            return figure;
        }

        public async Task<List<Figure>> GetFigures()
        {
            List<Figure> figures = await _context.Figures.ToListAsync();

            return figures;
        }
    }
}