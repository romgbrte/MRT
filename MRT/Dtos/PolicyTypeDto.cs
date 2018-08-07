using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRT.Dtos
{
    public class PolicyTypeDto
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}