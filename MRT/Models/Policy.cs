using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRT.Models
{
    public class Policy
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Policy Number")]
        public string Number { get; set; }

        [Required]
        [Display(Name = "Carrier")]
        public int CarrierId { get; set; }

        public Carrier Carrier { get; set; }

        [Display(Name = "Effective Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Effective Until")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Policy Type")]
        public byte Type { get; set; }

        [Required]
        [Range(0.001, 100.000)]
        [Display(Name = "Funding Rate")]
        public float FundingRate { get; set; }

        [Required]
        [Range(0.001, 100.000)]
        [Display(Name = "Collateral Rate")]
        public float CollateralRate { get; set; }

        [Required]
        [Range(0.001, 100.000)]
        [Display(Name = "Loss Rate")]
        public float LossRate { get; set; }
    }
}