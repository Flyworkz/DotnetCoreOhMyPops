using System.ComponentModel.DataAnnotations;

namespace OhMyPops.Dtos
{
    public class PopCreateDto
    {
        [Required]
        public int FigurineNumber { get; set; }

        [Required]
        public string Collection { get; set; }

        [Required]
        public string Label { get; set; }
    }
}