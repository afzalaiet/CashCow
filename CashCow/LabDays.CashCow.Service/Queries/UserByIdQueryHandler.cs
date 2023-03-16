using LabDays.CashCow.Data.Dto;
using LabDays.CashCow.Data.Queries;
using LabDays.CashCow.Data.Repositories.Contract;
using MediatR;
using QRCoder;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace LabDays.CashCow.Service.Queries
{
    public class UserByIdQueryHandler : IRequestHandler<UserByIdQuery, UserByIdResponse>
    {
        private readonly IUserRepository _userRepository;

        public UserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserByIdResponse> Handle(UserByIdQuery request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(request.UserId);
            if (existingUser == null)
            {
                return null;
            }
            UserByIdResponse response = new UserByIdResponse()
            {
                Id = existingUser.Id,
                JoiningDate = existingUser.JoiningDate,
                Name = existingUser.Name,
                Phone = existingUser.Phone
            };

            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();

                QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(existingUser.TokenIdentifier, QRCodeGenerator.ECCLevel.Q);
                QRCode qRCode = new QRCode(qRCodeData);
                using (System.Drawing.Bitmap bitMap = qRCode.GetGraphic(20))
                {
                    bitMap.Save(ms, ImageFormat.Png);
                    response.CashCowCode = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return response;
        }
    }
}
