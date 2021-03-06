﻿using System.ComponentModel.DataAnnotations;

namespace MRT.Dtos
{
    public class CodeDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(7)]
        public string Number { get; set; }

        [Required]
        [StringLength(255)]
        public string JobDescription { get; set; }
    }
}