using KredoBank.Application.Common;
using KredoBank.Application.Services.UserContext;
using KredoBank.Domain.SeedWork;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KredoBank.Application.Statements.Commands.UpdateStatement
{
    public class UpdateStatementCommandHandler : IRequestHandler<UpdateStatementCommand, ResultModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserContextService _userContextService;
        public UpdateStatementCommandHandler(IUnitOfWork unitOfWork,
                                             UserContextService userContextService)
        {
            _unitOfWork = unitOfWork;
            _userContextService = userContextService;
        }
        public async Task<ResultModel> Handle(UpdateStatementCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _userContextService.GetCurrentUserId();
            var currentStatement = await _unitOfWork.StatementRepository.GetSingleAsync(x => x.Id == request.Id &&
                                                                                        x.IsActive &&
                                                                                        !x.IsDeleted &&
                                                                                        x.UserId == currentUser.Id,
                                                                                        cancellationToken);

            if (currentStatement == null)
            {
                throw new Exception("განცხადება ვერ მოიძებნა");
            }

            if (currentStatement.StatementStatus == Domain.Enum.StatementStatus.Approved ||
                currentStatement.StatementStatus == Domain.Enum.StatementStatus.Rejected)
            {
                throw new Exception("განცხადების განახლება შეუძლებელია");
            }

            currentStatement.UpdateStatement(request.LoanType,
                                             request.Amount,
                                             request.Currency,
                                             request.Periodus,
                                             request.StatementStatus);
            _unitOfWork.StatementRepository.Update(currentStatement);
            await _unitOfWork.SaveChangeAsync();

            return new ResultModel
            {
                ResultMessage = "განცხადება წარმატებით განახლდა"
            };
        }
    }
}
