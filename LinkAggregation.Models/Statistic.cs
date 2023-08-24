using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkAggregation.Models
{
    public class Statistic
    {
        [Key]
        public int Id { get; set; }
        public string HyperLinkName { get; set; }
        public string IpNumber { get; set; }
        public string? Localization { get; set; }
        public string Referrer { get; set; }
        public string DateVisit { get; set; }
        public string TimeVisit { get; set; }

        [Display(Name = "Hyper Link")]
        public int HyperLinkId { get; set; }

        [ForeignKey("HyperLinkId")]
        public HyperLink Hyperlink { get; set; }
    }
}
