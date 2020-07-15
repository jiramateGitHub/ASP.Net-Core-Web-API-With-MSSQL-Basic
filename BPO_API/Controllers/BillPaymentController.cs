using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BPO_API.Data;
using BPO_API.Models;

namespace BPO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillPaymentController : ControllerBase
    {
        private readonly BillPaymentContext _context;

        public BillPaymentController(BillPaymentContext context)
        {
            _context = context;
        }

        // GET: api/BillPayment/inquiry/
        [HttpGet("inquiry")]
        //[HttpGet("inquiry/{txnType} {bankChannel} {bankRef} {timestamp} {bankCode} {accountNo} {refNo1} {refNo2} {amount}")]
        public async Task<ActionResult<IEnumerable<BillPaymentResponse>>>
            Inquiry(
                string txnType,
                string bankChannel,
                string bankRef,
                string timestamp,
                string bankCode,
                string accountNo,
                string paymentSource,
                string payerAccNo,
                string chequeInfo,
                string bankPayment,
                string branchCode,
                string tellerId,
                string refNo1, 
                string refNo2, 
                decimal amount,
                string partnerRef
            )
        {
            FormattableString sql_query = 
                @$"EXECUTE dbo.sp_SOP120_CheckQRCodeInformation 
                {txnType},
                {bankChannel},
                {bankRef},
                {timestamp},
                {bankCode},
                {accountNo},
                {paymentSource},
                {payerAccNo},
                {chequeInfo},
                {bankPayment},
                {branchCode},
                {tellerId},
                {refNo1}, 
                {refNo2},
                {amount},
                {partnerRef}";
            var context = _context.BillPaymentResponse.FromSqlInterpolated(sql_query).ToListAsync();
            return await context;
        }


        // POST: api/BillPayment/confirm
        [HttpPost("confirm")]
        public async Task<ActionResult<IEnumerable<BillPaymentResponse>>> 
            Confirm(
                BillPaymentRequest billpaymentrequest
            )
        {
            FormattableString sql_query =
                @$"EXECUTE dbo.sp_SOS070_InsertPayment 
                {billpaymentrequest.txnType},
                {billpaymentrequest.bankChannel},
                {billpaymentrequest.bankRef},
                {billpaymentrequest.timestamp},
                {billpaymentrequest.bankCode},
                {billpaymentrequest.accountNo},
                {billpaymentrequest.paymentSource},
                {billpaymentrequest.payerAccNo},
                {billpaymentrequest.chequeInfo},
                {billpaymentrequest.bankPayment},
                {billpaymentrequest.branchCode},
                {billpaymentrequest.tellerId},
                {billpaymentrequest.refNo1}, 
                {billpaymentrequest.refNo2},
                {billpaymentrequest.amount},
                {billpaymentrequest.partnerRef}";
            var context = _context.BillPaymentResponse.FromSqlInterpolated(sql_query).ToListAsync();
            await _context.SaveChangesAsync();

            return await context;
        }


    }
}
