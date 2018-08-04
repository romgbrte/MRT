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

        [Required]
        public int StateId { get; set; }

        [Required]
        public int CodeId { get; set; }

        public DateTime EffectiveDate { get; set; }

        public float Rate { get; set; }

        public bool IsActive { get; set; }
    }
}