using System;
using System.Threading.Tasks;

namespace LabDays.CashCow.Service.PaymentProcessorProxies
{
    /// <summary>
    /// A dummy proxy mimicing the real payment processor, this is here is just for demo purpose.
    /// </summary>
    public class DummyPaymentProcessorProxy : IPaymentProcessorProxy
    {
        public Task<PaymentResponse> DoPaymentAsync(PaymentRequest paymentRequest)
        {
            var response = new PaymentResponse()
            {

                Amount = paymentRequest.Amount,
                IsSuccess = true,
                SuccessMessage = "Approved",
                TransactionId = Guid.NewGuid().ToString().ToUpper()
            };
            return Task.FromResult(response);
        }
    }
}
