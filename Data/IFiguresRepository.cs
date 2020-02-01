using System.Collections.Generic;
using System.Threading.Tasks;
using TechAss.API.Models;

namespace TechAss.API.Data
{
    public interface IFiguresRepository
    {
         Task<Figure> Register (Figure figure);
         Task<List<Figure>> GetFigures();
    }
}