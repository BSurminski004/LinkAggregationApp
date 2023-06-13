using System.ComponentModel.DataAnnotations;

namespace LinkAggregation.Models
{
    public class HyperLink
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        public string? HashCode { get; set; }
        public DateTime? ValidFrom { get; set; } = DateTime.Now;
        public DateTime? ValidTo { get; set; }
    }
}
