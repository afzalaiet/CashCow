using LabDays.CashCow.Data.Entities;
using LabDays.CashCow.Data.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabDays.CashCow.Data.Repositories.Concrete
{
    /// <summary>
    /// A dummy respository which keeps the dummy data in memory, used for the sake of simplcity and demo. In real project this will point some DB.
    /// </summary>
    public class UserRepositoryInMemory : IUserRepository
    {
        private List<User> _users = new();
        public UserRepositoryInMemory()
        {
            _users.AddRange(new User[]
            {
                new User()
                {
                    Id = 1,
                    JoiningDate = DateTime.UtcNow.AddDays(-30),
                    Name = "Nick Fiama",
                    Phone = "01533239382",
                    TokenIdentifier = "F06BC1D7-38C9-4150-AE1D-EA796DF096B5",
                    SubscriptionAmount = 30
                },
                new User()
                {
                    Id = 2,
                    JoiningDate = DateTime.UtcNow.AddDays(-300),
                    Name = "Fury Hack",
                    Phone = "01634563002",
                    TokenIdentifier = "AF4BEF7C-77DA-4BFE-A573-2CE3ACC4497E",
                    SubscriptionAmount = 45
                }
            });
        }
        public Task<User> GetUserByIdAsync(int userId)
        {
            var existingUser = _users.Where(x => x.Id == userId).FirstOrDefault();

            return Task.FromResult(existingUser);
        }

        public Task<bool> ValidateUserTokenAsync(int userId, string tokenIdentifier)
        {
            return Task.FromResult(_users.Any(x => x.TokenIdentifier == tokenIdentifier && x.Id == userId));
        }
    }
}
