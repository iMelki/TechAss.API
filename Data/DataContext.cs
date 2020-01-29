using System.Diagnostics.CodeAnalysis;
using TechAss.API.Models;
using Microsoft.EntityFrameworkCore;

namespace TechAss.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext([NotNullAttribute] DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Figure> Figures { get; set; }
    }
}