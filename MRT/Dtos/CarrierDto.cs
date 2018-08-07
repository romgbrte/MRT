using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MRT.Models;

namespace MRT.Dtos
{
    public class CarrierDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(0.001, 100.000)]
        public float BaseRate { get; set; }
        
        public List<StateCoverage> StatesCovered { get; set; }
    }
}