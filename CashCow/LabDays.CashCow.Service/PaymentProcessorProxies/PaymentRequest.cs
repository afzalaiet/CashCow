using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabDays.CashCow.Service.PaymentProcessorProxies
{
    public class PaymentRequest
    {
        public string Token { get; set; }
        public decimal Amount { get; set; }
    }
}
