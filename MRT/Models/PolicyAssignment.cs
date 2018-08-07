using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRT.Models
{
    public class PolicyAssignment
    {
        public int Id { get; set; }

        [Required]
        public int PolicyId { get; set; }

        public Policy Policy { get; set; }

        [Required]
        public int CarrierId { get; set; }

        public Carrier Carrier { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}