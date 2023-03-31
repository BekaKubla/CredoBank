using IdentityModel;
using KredoBank.Application.Services.JWTService;
using KredoBank.Domain.SeedWork;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KredoBank.Application.Users.Queries.LogInUser
{
    public class LogInUserQueryHandler : IRequestHandler<LogInUserQuery, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;
        public LogInUserQueryHandler(IUnitOfWork unitOfWork,
                                     IJwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }
        public async Task<string> Handle(LogInUserQuery request, CancellationToken cancellationToken)
        {
            var getUser = await _unitOfWork.UserRepository.GetSingleAsync(x => x.UserName == request.UserName, cancellationToken);

            if (getUser == null || !(request.UserName == getUser.UserName && request.Password.ToSha512() == getUser.Password))
            {
                throw new Exception("მომხარებლის ინფორმაცია არასწორია");
            }

            var userToken = _jwtService.GenerateUserToken(getUser.UserName, getUser.Id);


            return userToken;
        }
    }
}
