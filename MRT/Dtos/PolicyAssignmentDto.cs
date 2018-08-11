using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRT.Dtos
{
    public class PolicyAssignmentDto
    {
        public int Id { get; set; }

        [Required]
        public int PolicyId { get; set; }

        public PolicyDto Policy { get; set; }

        [Required]
        public int CarrierId { get; set; }

        public CarrierDto Carrier { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}