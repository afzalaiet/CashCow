using LabDays.CashCow.Data.Entities;
using System.Threading.Tasks;

namespace LabDays.CashCow.Data.Repositories.Contract
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<bool> ValidateUserTokenAsync(int userId, string tokenIdentifier);
    }
}
