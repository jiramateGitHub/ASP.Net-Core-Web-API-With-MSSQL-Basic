using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BPO_API.Models;

namespace BPO_API.Data
{
    public class BillPaymentContext : DbContext
    {
        public BillPaymentContext (DbContextOptions<BillPaymentContext> options)
            : base(options)
        {
        }

        public DbSet<BPO_API.Models.BillPaymentResponse> BillPaymentResponse { get; set; }
        public DbSet<BPO_API.Models.BillPaymentRequest> BillPaymentRequest { get; set; }
    }
}
