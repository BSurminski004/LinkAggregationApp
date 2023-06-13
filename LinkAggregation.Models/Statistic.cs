using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkAggregation.Models
{
    public class Statistic
    {
        [Key]
        public int Id { get; set; }
        public string IpNumber { get; set; }
        public DateTime DateVisit { get; set; }
        public DateTime TimeVisit { get; set; }
        [Display(Name = "Hyper Link")]
        public int HyperLinkId { get; set; }
        [ForeignKey("HyperLinkId")]
        public HyperLink Hyperlink { get; set; }
    }
}
