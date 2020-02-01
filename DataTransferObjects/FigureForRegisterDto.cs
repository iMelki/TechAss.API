using System.ComponentModel.DataAnnotations;

namespace TechAss.API.DataTransferObjects
{
    public class FigureForRegisterDto
    {
        [Required]
        public string Name { get; set; }
    }
}