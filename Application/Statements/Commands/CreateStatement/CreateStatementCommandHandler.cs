using KredoBank.Application.Common;
using KredoBank.Application.Services.UserContext;
using KredoBank.Domain.SeedWork;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KredoBank.Application.Statements.Commands.CreateStatement
{
    public class CreateStatementCommandHandler : IRequestHandler<CreateStatementCommand, ResultModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserContextService _userContextService;
        public CreateStatementCommandHandler(IUnitOfWork unitOfWork,
                                             UserContextService userContextService)
        {
            _unitOfWork = unitOfWork;
            _userContextService = userContextService;
        }

        public async Task<ResultModel> Handle(CreateStatementCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var currentUserIdentifier = _userContextService.GetCurrentUserId();

                var statement = Domain.Entity.Statement.Statements.CreateStatement(request.LoanType,
                                                          request.Amount,
                                                          request.Currency,
                                                          request.Periodus,
                                                          request.StatementStatus);
                var currentUser = await _userContextService.GetCurrentUserId();
                currentUser.AddStatement(statement);

                await _unitOfWork.StatementRepository.AddAsync(statement, cancellationToken);
                await _unitOfWork.SaveChangeAsync();

                return new ResultModel
                {
                    ResultMessage = "განცხადება წარმატებით დაემატა"
                };

            }
            catch (Exception ex)
            {
                throw new Exception("შეცდომა განცხადების დამატებისას");
            }
        }
    }
}
