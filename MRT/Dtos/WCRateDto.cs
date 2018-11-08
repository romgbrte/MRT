using System;
using System.ComponentModel.DataAnnotations;

namespace MRT.Dtos
{
    public class WCRateDto
    {
        public int Id { get; set; }

        [Required]
        public int CarrierId { get; set; }
        public string CarrierName { get; set; }

        [Required]
        public int StateId { get; set; }
        public string StateName { get; set; }

        [Required]
        public int CodeId { get; set; }
        public string CodeNumber { get; set; }

        [Required]
        public DateTime EffectiveDate { get; set; }

        [Required]
        [Range(0.001, 100.000)]
        public float Rate { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}