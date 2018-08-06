using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MRT.Models;

namespace MRT.Dtos
{
    public class StateCoverageDto
    {
        public int Id { get; set; }

        [Required]
        public int CarrierId { get; set; }

        [Required]
        public int StateId { get; set; }

        public State State { get; set; }
    }
}