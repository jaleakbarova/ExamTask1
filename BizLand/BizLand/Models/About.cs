using System.ComponentModel.DataAnnotations.Schema;

namespace BizLand.Models
{
    public class About
    {
        public int Id { get; set; }
        public string MainTitle { get; set; } = null!;
        public string Title { get; set; } 
        public string? Description { get; set; }
        public string MainDescription { get; set; }
        public string? Icon { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
