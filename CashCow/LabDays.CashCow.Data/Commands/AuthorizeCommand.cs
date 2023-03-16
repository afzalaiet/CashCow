using LabDays.CashCow.Data.Dto;
using MediatR;

namespace LabDays.CashCow.Data.Commands
{
    public class AuthorizeCommand : IRequest<AuthorizeResponse>
    {
        public int UserId { get; set; }
        public string TokenIdentifier { get; set; }
        public decimal? Amount { get; set; }
    }
}
