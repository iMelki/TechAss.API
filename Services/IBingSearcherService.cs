using System.Threading.Tasks;

namespace TechAss.API.Services
{
    public interface IBingSearcherService
    {
         public Task<string> Lookup (string searchItem);
    }
}