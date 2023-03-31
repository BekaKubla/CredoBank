using IdentityServer4.Models;
using KredoBank.Application.Common;
using KredoBank.Domain.SeedWork;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KredoBank.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResultModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResultModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetSingleAsync(x => x.PersonalNumber == request.PersonalNumber || x.UserName.ToUpper() == request.UserName.ToUpper(), cancellationToken);
            if (user != null)
            {
                throw new Exception("მსგავსი მომხარებელი უკვე არსებობს");
            }

            try
            {
                var entity = Domain.Entity.User.Users.RegisterUser(request.FirstName,
                                                                    request.LastName,
                                                                    request.PersonalNumber,
                                                                    request.BirthDate,
                                                                    request.UserName,
                                                                    request.Password.Sha512());

                await _unitOfWork.UserRepository.AddAsync(entity, cancellationToken);
                await _unitOfWork.SaveChangeAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("შეცდომა მომხარებლის დამატებისას");
            } 

            return new ResultModel
            {
                ResultMessage = "პიროვნება წარმატებით დაემატა"
            };

        }
    }
}
