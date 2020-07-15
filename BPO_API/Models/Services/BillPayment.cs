using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BPO_API.Models
{
    public class BillPaymentRequest
    {

        [MaxLength(4)]
        public string txnType { get; set; }

        [MaxLength(4)]
        public string bankChannel { get; set; }
        
        [MaxLength(15)]
        public string bankRef { get; set; }

        [NotMapped]
        [MaxLength(17)]
        public string timestamp { get; set; }

        [NotMapped]
        [MaxLength(3)]
        public string bankCode { get; set; }

        [NotMapped]
        [MaxLength(16)]
        public string accountNo { get; set; }

        [NotMapped]
        [MaxLength(3)]
        public string paymentSource { get; set; }  

        [NotMapped]
        [MaxLength(16)]
        public string payerAccNo { get; set; }

        [NotMapped]
        [MaxLength(20)]
        public string chequeInfo { get; set; } 

        [NotMapped]
        [MaxLength(3)]
        public string bankPayment { get; set; }

        [NotMapped]
        [MaxLength(4)]
        public string branchCode { get; set; }

        [NotMapped]
        [MaxLength(6)]
        public string tellerId { get; set; }

        [Key]
        [Required]
        [MaxLength(20)]
        public string refNo1 { get; set; }

        [Required]
        [MaxLength(20)]
        public string refNo2 { get; set; }

        [Required]
        public decimal amount { get; set; }

        [MaxLength(15)]
        public string partnerRef { get; set; }

    }

    public class BillPaymentResponse
    {

        [MaxLength(4)]
        public string txnType { get; set; }
        
        [MaxLength(15)]
        public string bankRef { get; set; }

        [Required]
        [MaxLength(20)]
        public string refNo1 { get; set; }

        [Required]
        [MaxLength(20)]
        public string refNo2 { get; set; }

        [Required]
        public decimal amount { get; set; }

        [MaxLength(15)]
        public string partnerRef { get; set; }

        [Key]
        [MaxLength(2)]
        public string ReasonCode { get; set; }

        [MaxLength(18)]
        public string ReasonDescription { get; set; }

    }
}
