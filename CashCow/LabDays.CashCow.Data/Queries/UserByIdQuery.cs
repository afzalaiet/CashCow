using LabDays.CashCow.Data.Dto;
using MediatR;

namespace LabDays.CashCow.Data.Queries
{
    public class UserByIdQuery : IRequest<UserByIdResponse>
    {
        public int UserId { get; set; }
    }
}
