using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MRT.Models;
using MRT.ViewModels.Utilities;

namespace MRT.ViewModels
{
    public class PolicyFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Policy Number")]
        public string Number { get; set; }
        
        [IsStartDateWithinTheNextYear]
        [Display(Name = "Effective Date (YYYY-MM-DD)")]
        public DateTime StartDate { get; set; }
        
        [IsEndDateWithinTheNextTwoYears]
        [Display(Name = "Effective Until (YYYY-MM-DD)")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Policy Type")]
        public byte PolicyTypeId { get; set; }

        public IEnumerable<PolicyType> PolicyTypes { get; set; }

        [Required]
        [Range(0.001, 100.000)]
        [Display(Name = "Funding Rate")]
        public float FundingRate { get; set; }

        [Required]
        [Range(0.001, 100.000)]
        [Display(Name = "Collateral Rate")]
        public float CollateralRate { get; set; }

        [Required]
        [Range(0.001, 100.000)]
        [Display(Name = "Loss Rate")]
        public float LossRate { get; set; }

        public PolicyFormViewModel()
        {
            Id = 0;
            StartDate = DateTime.Today;
            EndDate = DateTime.Today.AddYears(1);
        }

        public PolicyFormViewModel(Policy policy)
        {
            Id = policy.Id;
            Number = policy.Number;
            StartDate = policy.StartDate;
            EndDate = policy.EndDate;
            PolicyTypeId = policy.PolicyTypeId;
            FundingRate = policy.FundingRate;
            CollateralRate = policy.CollateralRate;
            LossRate = policy.LossRate;
        }

        public string Title
        {
            get { return Id == 0 ? "New Policy" : "Edit Policy"; }
        }
    }
}