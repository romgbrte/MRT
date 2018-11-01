using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MRT.Models;

namespace MRT.ViewModels
{
    public class CarrierFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [StringLength(50)]
        [Display(Name = "Carrier Name")]
        public string Name { get; set; }

        [Range(0.001, 100.000)]
        [Display(Name = "Carrier Base Rate")]
        public float BaseRate { get; set; }
        
        [Display(Name = "States Covered")]
        public List<State> StatesCovered { get; set; }

        [Display(Name = "States Not Covered")]
        public List<State> StatesNotCovered { get; set; }
        
        public string Title
        {
            get { return Id == 0 ? "New Carrier" : "Edit Carrier"; }
        }

        public CarrierFormViewModel()
        {
            Id = 0;
            StatesCovered = new List<State>();
            StatesNotCovered = new List<State>();
        }

        public CarrierFormViewModel(Carrier carrier)
        {
            Id = carrier.Id;
            Name = carrier.Name;
            BaseRate = carrier.BaseRate;
        }
    }
}