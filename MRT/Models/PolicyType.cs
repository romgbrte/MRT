using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRT.Models
{
    public class PolicyType
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}