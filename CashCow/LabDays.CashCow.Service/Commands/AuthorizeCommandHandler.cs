using LabDays.CashCow.Data.Commands;
using LabDays.CashCow.Data.Dto;
using LabDays.CashCow.Data.Repositories.Contract;
using LabDays.CashCow.Service.PaymentProcessorProxies;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LabDays.CashCow.Service.Commands
{
    public class AuthorizeCommandHandler : IRequestHandler<AuthorizeCommand, AuthorizeResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPaymentProcessorProxy _paymentProcessorProxy;

        public AuthorizeCommandHandler(IUserRepository userRepository, IPaymentProcessorProxy paymentProcessorProxy)
        {
            _userRepository = userRepository;
            _paymentProcessorProxy = paymentProcessorProxy;
        }

        public async Task<AuthorizeResponse> Handle(AuthorizeCommand request, CancellationToken cancellationToken)
        {
            bool validated = await _userRepository.ValidateUserTokenAsync(request.UserId, request.TokenIdentifier);
            if (validated)
            {
                var paymentRequest = new PaymentRequest() { Amount = await GetAmount(request), Token = request.TokenIdentifier };

                var paymentResponse = await _paymentProcessorProxy.DoPaymentAsync(paymentRequest);

                var response = new AuthorizeResponse()
                {
                    Amount = paymentResponse.Amount,
                    ErrorMessage = paymentResponse.ErrorMessage,
                    IsSuccess = paymentResponse.IsSuccess,
                    SuccessMessage = paymentResponse.SuccessMessage,
                    TransactionId = paymentResponse.TransactionId
                };
                return response;
            }
            else
            {
                return null; 
            }
        }

        private async Task<decimal> GetAmount(AuthorizeCommand request)
        {
            if (request.Amount == null || request.Amount == default(decimal))
            {
                var existingUser = await _userRepository.GetUserByIdAsync(request.UserId);
                return existingUser.SubscriptionAmount;
            }
            else
            {
                return request.Amount.Value;
            }
        }
    }
}
