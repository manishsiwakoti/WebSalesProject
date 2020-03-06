using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebSalesProject.Models
    {
    public class Request
        {
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Description { get; set; }
        [StringLength(50)]
        [Required]
        public string Justification { get; set; }
        [StringLength(50)]
        [Required]
        public string RejectionReason { get; set; }
        [StringLength(50)]
        [Required]
        public string DeliveryMode { get; set; } = "Pickup";
        [StringLength(50)]
        [Required]
        public string Status { get; set; } = "NEW";
        public decimal Total { get; set; } = 0;
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual IEnumerable<RequestLine> RequestLines { get; set; }
        

        public Request() { }
        }
    }
