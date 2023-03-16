using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabDays.CashCow.Service.PaymentProcessorProxies
{
    public class PaymentResponse
    {
        public string TransactionId { get; set; }
        public bool IsSuccess { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public decimal Amount { get; set; }
    }
}
