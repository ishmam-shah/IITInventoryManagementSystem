using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IITInventoryManagementSystem.Models
{
    public class RequisitionSlip
    {
        public int Id { get; set; }
        public string Purpose { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime RecommendationDate { get; set; }
        public DateTime VerificationDate { get; set; }

        public string ApplicantId { get; set; }
        public string RecommenderId { get; set; }
        public string VerifierId { get; set; }
        public string RejectionCause { get; set; }

        public virtual IEnumerable<RequisedItem> ItemsArrival { get; set; }

    }
}