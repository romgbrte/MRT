using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MRT.Models;

namespace MRT.ViewModels
{
    public class PolicyAssignmentViewModel
    {
        public int Id { get; set; }

        [Required]
        public int PolicyId { get; set; }

        public Policy Policy { get; set; }

        [Required]
        [Display(Name = "Carrier Name")]
        public int CarrierId { get; set; }

        public IEnumerable<Carrier> Carriers { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public PolicyAssignmentViewModel()
        {
            Id = 0;
            CarrierId = 0;
            IsActive = true;
        }

        public PolicyAssignmentViewModel(PolicyAssignment policyAssignment)
        {
            Id = policyAssignment.Id;
            PolicyId = policyAssignment.PolicyId;
            Policy = policyAssignment.Policy;
            CarrierId = policyAssignment.CarrierId;
            IsActive = policyAssignment.IsActive;
        }

        public string Title
        {
            get { return "Assign Policy to Carrier"; }
        }
    }
}