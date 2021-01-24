using System.ComponentModel.DataAnnotations;

namespace OhMyPops.Models
{
    public class Pop
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int FigurineNumber { get; set; }

        [Required]
        public string Collection { get; set; }

        [Required]
        public string Label { get; set; }
    }
}