namespace BizLand.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Icon { get; set; }
    }
}
