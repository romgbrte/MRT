using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRT.Models
{
    public class WCRate
    {
        public int Id { get; set; }

        [Required]
        public int CarrierId { get; set; }
        public Carrier Carrier { get; set; }

        [Required]
        public int StateId { get; set; }
        public State State { get; set; }

        [Required]
        public int CodeId { get; set; }
        public Code Code { get; set; }

        [Required]
        public DateTime EffectiveDate { get; set; }

        [Required]
        [Range(0.01, 100.00)]
        public float Rate { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}