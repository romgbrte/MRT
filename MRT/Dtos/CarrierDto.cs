using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public List<StateCoverageDto> StatesCovered { get; set; }

        public string StatesCoveredString
        {
            get
            {
                return String.Join(", ", StatesCovered.Select(s => s.State.Abbreviation));
            }
        }
    }
}