using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabDays.CashCow.Service.PaymentProcessorProxies
{
    public interface IPaymentProcessorProxy
    {
        Task<PaymentResponse> DoPaymentAsync(PaymentRequest paymentRequest);
    }
}
