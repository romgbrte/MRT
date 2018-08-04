using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRT.Models
{
    public class Carrier
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Carrier Name")]
        public string Name { get; set; }

        [Required]
        [Range(0.001, 100.000)]
        [Display(Name = "Carrier Base Rate")]
        public float BaseRate { get; set; }

        [Display(Name = "Current Policy")]
        public int? CurrentPolicyId { get; set; }

        //public Policy CurrentPolicy { get; set; }

        [Display(Name = "States Covered")]
        public IEnumerable<StateCoverage> StatesCovered { get; set; }
    }
}