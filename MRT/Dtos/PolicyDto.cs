using System;
using System.ComponentModel.DataAnnotations;

namespace MRT.Dtos
{
    public class PolicyDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Number { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        [Required]
        public byte PolicyTypeId { get; set; }

        public PolicyTypeDto PolicyType { get; set; }

        [Required]
        [Range(0.001, 100.000)]
        public float FundingRate { get; set; }

        [Required]
        [Range(0.001, 100.000)]
        public float CollateralRate { get; set; }

        [Required]
        [Range(0.001, 100.000)]
        public float LossRate { get; set; }

        /*
         * public string StartDateString
        {
            get { return StartDate == null ? "--" : StartDate.ToShortDateString(); }
        }

        public string EndDateString
        {
            get { return EndDate == null ? "--" : EndDate.ToShortDateString(); }
        }
        */
    }
}