﻿using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

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
        
        public List<StateDto> StatesCovered { get; set; }

        public List<StateDto> StatesNotCovered { get; set; }

        // Concatenates and returns State.Abbreviations of States covered by the Carrier, if any
        public string StatesCoveredString
        {
            get
            {
                return StatesCovered == null ? "--" : string.Join(", ", StatesCovered.Select(s => s.Abbreviation));
            }
        }
    }
}